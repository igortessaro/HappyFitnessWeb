using System.Data.Entity;

namespace HF.Repository.Repository.Context
{
    public interface IDbContextAdapter
    {
        DbContext DbContext { get; }
    }
}
