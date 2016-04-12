using System;

namespace HF.Repository.Repository.Context
{
    public abstract class BaseService : IDisposable
    {
        public virtual void Dispose()
        {
        }

        ~BaseService()
        {
            Dispose();
        }
    }
}