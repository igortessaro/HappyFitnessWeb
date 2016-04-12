using System;
using System.Collections.Generic;
using System.Linq;

namespace HF.Repository.Repository.Context
{
    public interface IGenericRepository : IDisposable
    {
        void Insert(object entity);
        void Update(object entity);
        void Delete(object entity);
        TEntity Get<TEntity>(params object[] ids) where TEntity : class;
        IQueryable<TEntity> Query<TEntity>() where TEntity : class;
        void SaveChanges();
        void UndoChanges();
        TResult[] ExecuteQuery<TResult>(string commandName, TypeCommand typeCommand, params Parameter[] parameterList) where TResult : new();
        TResult ExecuteScalar<TResult>(string commandName, TypeCommand typeCommand, params Parameter[] parameterList) where TResult : struct;
        int Execute(string commandName, TypeCommand typeCommand, params Parameter[] parameterList);

        void SyncOneToMany<TEntidade, TItemLista, TItemListaDominio>(TEntidade entidade,
           ICollection<TItemListaDominio> listaEntidade, ICollection<TItemLista> listaTela,
           Func<TItemListaDominio, int> ObterChaveItemDominio, Func<TItemLista, int> ObterChaveItemTela,
           Action<TItemLista, TItemListaDominio> traduzir = null)
            where TEntidade : class
            where TItemLista : class
            where TItemListaDominio : class, new();

        void SyncManyToMany<TEntidade, TItemLista, TItemListaDominio>(TEntidade entidade,
           ICollection<TItemListaDominio> listaEntidade, ICollection<TItemLista> listaTela,
           Func<TItemListaDominio, int> ObterChaveItemDominio, Func<TItemLista, int> ObterChaveItemTela,
           Action<TItemLista, TItemListaDominio> traduzir = null)
            where TEntidade : class
            where TItemLista : class
            where TItemListaDominio : class, new();
    }
}