using System;
using System.Linq;

using DraftHits.Data.Entities;

namespace DraftHits.Data.Repo.Impl
{
    internal class CustomerPaymentsLogRepo : RepoBase<CustomerPaymentsLog, DraftHitsContext>, ICustomerPaymentsLogRepo
    {
        public CustomerPaymentsLogRepo(UnitOfWork<DraftHitsContext> unitOfWork) : base(unitOfWork) { }
    }
}
