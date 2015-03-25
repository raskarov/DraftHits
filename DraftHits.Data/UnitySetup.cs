using System.Data.Entity;
using DraftHits.Data.Migrations;
using Microsoft.Practices.Unity;

using DraftHits.Core.Unity;
using DraftHits.Data.Repo;
using DraftHits.Data.Repo.Impl;

namespace DraftHits.Data
{
    public class UnitySetup : IUnitySetup
    {
        public IUnityContainer RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IUnitOfWork, UnitOfWork<DraftHitsContext>>();

            container.RegisterType<ICustomerRepo, CustomerRepo>();
            container.RegisterType<ICustomerTransactionRepo, CustomerTransactionRepo>();
                        
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DraftHitsContext, Configuration>());

            return container;
        }
    }
}
