using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HF.Repository.Repository.Context
{
    public class EntityFrameworkWrapper : IGenericRepository, IDbContextAdapter
    {
        private DbContext dbContext;

        public EntityFrameworkWrapper(DbContext dbContext)
        {
            this.dbContext = dbContext;

            bool entityFrameworkEnableLog;
            if (bool.TryParse(ConfigurationManager.AppSettings["EntityFrameworkEnableLog"], out entityFrameworkEnableLog))
            {
                if (entityFrameworkEnableLog)
                    this.dbContext.Database.Log = this.Log;
            }
        }

        DbContext IDbContextAdapter.DbContext
        {
            get { return this.dbContext; }
        }

        public void Insert(object entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Added;
        }

        public void Update(object entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public TEntity Get<TEntity>(params object[] ids)
            where TEntity : class
        {
            return this.dbContext.Set<TEntity>().Find(ids);
        }

        public IQueryable<TEntity> Query<TEntity>()
            where TEntity : class
        {
            return this.dbContext.Set<TEntity>();
        }

        public void SaveChanges()
        {
            try
            {
                this.dbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException("Entity Validation Failed - errors follow:\n" + sb.ToString(), ex);
            }
        }

        public void UndoChanges()
        {
            foreach (DbEntityEntry entry in this.dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
        }

        public TResult[] ExecuteQuery<TResult>(string commandName, TypeCommand typeCommand, params Parameter[] parameterList) where TResult : new()
        {
            List<SqlParameter> sqlParameterList = this.CreateSqlParameters(parameterList);
            string sqlCommand = this.CreateSqlCommand(commandName, typeCommand, sqlParameterList);

            return this.dbContext.Database.SqlQuery<TResult>(sqlCommand, sqlParameterList.ToArray()).ToArray<TResult>();
        }

        public TResult ExecuteScalar<TResult>(string commandName, TypeCommand typeCommand, params Parameter[] parameterList) where TResult : struct
        {
            List<SqlParameter> sqlParameterList = this.CreateSqlParameters(parameterList);
            string sqlCommand = this.CreateSqlCommand(commandName, typeCommand, sqlParameterList);

            return this.dbContext.Database.SqlQuery<TResult>(sqlCommand, sqlParameterList.ToArray()).ToArray<TResult>().FirstOrDefault();
        }

        public int Execute(string commandName, TypeCommand typeCommand, params Parameter[] parameterList)
        {
            List<SqlParameter> sqlParameterList = this.CreateSqlParameters(parameterList);
            string sqlCommand = this.CreateSqlCommand(commandName, typeCommand, sqlParameterList);

            return this.dbContext.Database.ExecuteSqlCommand(sqlCommand, sqlParameterList.ToArray());
        }

        private List<SqlParameter> CreateSqlParameters(Parameter[] parameterList)
        {
            List<SqlParameter> sqlParameterList = new List<SqlParameter>();

            foreach (Parameter parameter in parameterList)
            {
                sqlParameterList.Add(
                    new SqlParameter
                    {
                        ParameterName = String.Format("@{0}", parameter.Name),
                        Value = !this.IsNullParameter(parameter) ? parameter.Value : DBNull.Value,
                    }
                );
            }

            return sqlParameterList;
        }

        private bool IsNullParameter(Parameter parameter)
        {
            object obj = parameter.Value;

            if (obj == null)
                return true;

            Type type = obj.GetType();
            if (Nullable.GetUnderlyingType(type) != null)
            {
                PropertyInfo propertyInfo = type.GetProperty("Value");
                if (propertyInfo != null && propertyInfo.GetValue(obj) == null)
                    return true;
            }

            return false;
        }

        private string CreateSqlCommand(string commandName, TypeCommand typeCommand, List<SqlParameter> sqlParameters)
        {
            StringBuilder sb = new StringBuilder();

            if (typeCommand == TypeCommand.Function)
                sb.Append("SELECT ");

            sb.Append(commandName);

            if (typeCommand == TypeCommand.Function)
                sb.Append("(");

            for (int i = 0; i < sqlParameters.Count; i++)
            {
                sb.Append(" " + sqlParameters[i].ParameterName);

                if (i < (sqlParameters.Count - 1))
                    sb.Append(",");
            }

            if (typeCommand == TypeCommand.Function)
                sb.Append(")");

            return sb.ToString();
        }

        private void Log(string sql)
        {
            string baseDirectory = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(String.Format("{0}\\eflog.txt", baseDirectory), true))
            {
                file.WriteLine(sql);
            }
        }



        /// <summary>
        /// Sincroniza um relacionamento de um objeto de dominio.
        /// </summary>
        /// <typeparam name="TEntidade">O tipo do objeto de domínio.</typeparam>
        /// <typeparam name="TItemLista">O tipo do item da lista de objetos que vêm da tela.</typeparam>
        /// <typeparam name="TItemListaDominio">O tipo do item da lista que faz o relacionamento com o objeto de domínio.</typeparam>
        /// <param name="entidade">O objeto de domínio.</param>
        /// <param name="listaEntidade">A lista que representa a relação no objeto de domínio. Ex.: instituicao.Usuarios.</param>
        /// <param name="listaTela">A lista que contém os dados que vem da tela.</param>
        /// <param name="traduzir">O método que traduz um objeto da tela para um objeto de domínio.</param>   
        /// <param name="ObterChaveItemDominio">O seletor da pk tabela de item de dominio</param>
        /// <param name="ObterChaveItemTela">O seletor da pk da tabela de item de tela</param>
        public void SyncOneToMany<TEntidade, TItemLista, TItemListaDominio>(TEntidade entidade,
            ICollection<TItemListaDominio> listaEntidade, ICollection<TItemLista> listaTela,
            Func<TItemListaDominio, int> ObterChaveItemDominio, Func<TItemLista, int> ObterChaveItemTela,
            Action<TItemLista, TItemListaDominio> traduzir = null)
            where TEntidade : class
            where TItemLista : class
            where TItemListaDominio : class, new()
        {
            var idTela = listaTela.Select(ObterChaveItemTela).ToArray();
            var idsItensExcluidos = listaEntidade.Select(ObterChaveItemDominio).Where(e => !idTela.Contains(e)).ToArray();

            // Exclui
            foreach (var idItemExcluir in idsItensExcluidos)
            {
                var itemExcluir = this.Get<TItemListaDominio>(idItemExcluir);
                this.Delete(itemExcluir);
            }

            // Atualiza
            foreach (var item in listaTela.Where(t => ObterChaveItemTela(t) != 0))
            {
                var itemBanco = this.Get<TItemListaDominio>(ObterChaveItemTela(item));
                if (traduzir != null)
                {
                    traduzir(item, itemBanco);
                }
                Update(itemBanco);
            }

            // Inclui
            foreach (var item in listaTela.Where(t => ObterChaveItemTela(t) == 0))
            {
                var novoItem = new TItemListaDominio();
                if (traduzir != null)
                {
                    traduzir(item, novoItem);
                }
                listaEntidade.Add(novoItem);
                Insert(novoItem);
            }
        }

        /// <summary>
        /// Sincroniza um relacionamento de um objeto de dominio.
        /// </summary>
        /// <typeparam name="TEntidade">O tipo do objeto de domínio.</typeparam>
        /// <typeparam name="TItemLista">O tipo do item da lista de objetos que vêm da tela.</typeparam>
        /// <typeparam name="TItemListaDominio">O tipo do item da lista que faz o relacionamento com o objeto de domínio.</typeparam>
        /// <param name="entidade">O objeto de domínio.</param>
        /// <param name="listaEntidade">A lista que representa a relação no objeto de domínio. Ex.: instituicao.Usuarios.</param>
        /// <param name="listaTela">A lista que contém os dados que vem da tela.</param>
        /// <param name="traduzir">O método que traduz um objeto da tela para um objeto de domínio.</param>   
        /// <param name="ObterChaveItemDominio">O seletor da pk tabela de item de dominio</param>
        /// <param name="ObterChaveItemTela">O seletor da pk da tabela de item de tela</param>
        public void SyncManyToMany<TEntidade, TItemLista, TItemListaDominio>(TEntidade entidade,
            ICollection<TItemListaDominio> listaEntidade, ICollection<TItemLista> listaTela,
            Func<TItemListaDominio, int> ObterChaveItemDominio, Func<TItemLista, int> ObterChaveItemTela,
            Action<TItemLista, TItemListaDominio> traduzir = null)
            where TEntidade : class
            where TItemLista : class
            where TItemListaDominio : class, new()
        {
            var idsTela = listaTela.Select(ObterChaveItemTela).ToArray();
            var idsListaEntidade = listaEntidade.Select(ObterChaveItemDominio).ToArray();
            var idsItensExcluidos = idsListaEntidade.Except(idsTela);
            var idsItensIncluidos = idsTela.Except(idsListaEntidade);

            // Exclui
            foreach (var idItemExcluir in idsItensExcluidos)
            {
                var itemExcluir = this.Get<TItemListaDominio>(idItemExcluir);
                listaEntidade.Remove(itemExcluir);
            }

            // Inclui
            foreach (var idItemIncluir in idsItensIncluidos)
            {
                var novoItem = this.Get<TItemListaDominio>(idItemIncluir);

                if (traduzir != null)
                {
                    var item = listaTela.FirstOrDefault(t => ObterChaveItemTela(t) == idItemIncluir);
                    if (item != null)
                    {
                        traduzir(item, novoItem);
                    }
                }
                listaEntidade.Add(novoItem);
            }
        }

        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
                dbContext = null;
            }
        }
    }
}