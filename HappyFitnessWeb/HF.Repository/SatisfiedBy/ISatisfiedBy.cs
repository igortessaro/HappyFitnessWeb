using System;
using System.Linq.Expressions;

namespace HF.Repository
{
    public interface ISatisfiedBy<TEntity>
    {
        Expression<Func<TEntity, bool>> Where
        { get; set; }
    }
}
