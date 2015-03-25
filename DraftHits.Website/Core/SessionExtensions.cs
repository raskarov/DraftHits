using DraftHits.Core.Unity;
using DraftHits.Data;
using DraftHits.Data.Entities;
using DraftHits.Data.Repo;
using DraftHits.Website.Core.Model.Session;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Web;
using System.Web.Security;

namespace DraftHits.Website.Core
{
    public static class SessionExtensions
    {
        public static SessionUserModel GetUser(this HttpSessionStateWrapper session)
        {
            return GetUser(session);
        }

        public static SessionUserModel GetUser(this HttpSessionStateBase session)
        {
            //var user = (SessionUserModel)session[_sessionKey];
            SessionUserModel user = null;
            if (user == null || user.UserName != HttpContext.Current.User.Identity.Name)
            {
                using (var uow = UnityManager.Instance.Resolve<IUnitOfWork>())
                {
                    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DraftHitsContext()));
                    var currentUser = manager.FindByName(HttpContext.Current.User.Identity.Name);
                    
                    if (currentUser == null)
                    {
                        FormsAuthentication.SignOut();
                        return null;
                    }

                    var repo = uow.GetRepo<ICustomerRepo>();
                    var customer = repo.GetByUserId(Guid.Parse(currentUser.Id));

                    user = new SessionUserModel
                    {
                        Id = Guid.Parse(currentUser.Id),
                        UserName = currentUser.UserName,
                        AliasName = currentUser.AliasName,
                        CreationDate = currentUser.CreationDate,
                        
                        CustomerId = customer.Id,
                        AccountLocked = customer.AccountLocked,
                        Balance = customer.Balance,
                        DHRP = customer.DHRP,
                        PendingBonus = customer.PendingBonus
                    };

                    session[_sessionKey] = user;
                }
            }

            return user;
        }

        private static readonly String _sessionKey = "user";
    }
}