using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DraftHits.Website.Core
{
    public static class Configuration
    {
        public static String GatewayMerchantId
        {
            get
            {
                return ConfigurationManager.AppSettings["MerchantId"];
            }
        }

        public static String GatewayPublicKey
        {
            get
            {
                return ConfigurationManager.AppSettings["PublicKey"];
            }
        }

        public static String GatewayPrivateKey
        {
            get
            {
                return ConfigurationManager.AppSettings["PrivateKey"];
            }
        }
    }
}