using System;

namespace DraftHits.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Int32 Commit();

        TRepo GetRepo<TRepo>();
    }
}
