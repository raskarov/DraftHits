using System;
using System.Linq;
using System.Data.Entity.Migrations;

using DraftHits.Data.Entities;
using DraftHits.Core.Unity;
using DraftHits.Data.Repo;

namespace DraftHits.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DraftHitsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DraftHitsContext context)
        {
            UnityManager.Instance.RegisterAllUnitySetups();
        }
    }
}
