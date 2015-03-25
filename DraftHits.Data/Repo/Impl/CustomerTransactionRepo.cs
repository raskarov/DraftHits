using System;
using System.Linq;

using DraftHits.Data.Entities;
using DraftHits.Data.Exceptions;

namespace DraftHits.Data.Repo.Impl
{
    internal class CustomerTransactionRepo : RepoBase<CustomerTransaction, DraftHitsContext>, ICustomerTransactionRepo
    {
        public CustomerTransactionRepo(UnitOfWork<DraftHitsContext> unitOfWork) : base(unitOfWork) { }
    }
}
