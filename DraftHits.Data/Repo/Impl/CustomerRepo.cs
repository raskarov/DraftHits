using System;
using System.Linq;

using DraftHits.Data.Entities;
using DraftHits.Data.Exceptions;

namespace DraftHits.Data.Repo.Impl
{
    internal class CustomerRepo : RepoBase<Customer, DraftHitsContext>, ICustomerRepo
    {
        public CustomerRepo(UnitOfWork<DraftHitsContext> unitOfWork) : base(unitOfWork) { }

        public Customer GetByUserId(Guid id)
        {
            return GetAll().FirstOrDefault(x => x.UserId == id);
        }
    }
}
