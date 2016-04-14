using System;
using System.Linq.Expressions;

namespace HF.Repository.SatisfiedBy.Atividade
{
    public class SatisfiedById : ISatisfiedBy<Domain.Entities.Atividade>
    {
        public Expression<Func<Domain.Entities.Atividade, bool>> Where
        { get; set; }

        public SatisfiedById(int id)
        {
            this.Where = this.Conditional(id);
        }

        private Expression<Func<Domain.Entities.Atividade, bool>> Conditional(int id)
        {
            return x => x.codAtividade == id;
        }
    }
}
