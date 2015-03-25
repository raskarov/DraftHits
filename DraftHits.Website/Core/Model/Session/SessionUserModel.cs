using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraftHits.Website.Core.Model.Session
{
    public class SessionUserModel
    {
        public Guid Id { get; set; }

        public String UserName { get; set; }

        public String LastName { get; set; }

        public String FirstName { get; set; }

        public String FullName { get; set; }

        public String AliasName { get; set; }

        public DateTime CreationDate { get; set; }

        public Int64 CustomerId { get; set; }

        public Boolean AccountLocked { get; set; }

        public Decimal Balance { get; set; }

        public Int32 DHRP { get; set; }

        public Decimal PendingBonus { get; set; }
    }
}