using System;

using DraftHits.Data.Entities;

namespace DraftHits.Data.Repo
{
    public interface ICustomerRepo : IRepoBase<Customer>
    {
        Customer GetByUserId(Guid id);
    }
}
