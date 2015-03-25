using Braintree;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DHWC = DraftHits.Website.Core;

namespace DraftHits.Website.Core
{
    public static class Constants
    {
        public static BraintreeGateway Gateway = new BraintreeGateway
        {
            Environment = Braintree.Environment.SANDBOX,
            MerchantId = DHWC.Configuration.GatewayMerchantId,
            PublicKey = DHWC.Configuration.GatewayPublicKey,
            PrivateKey = DHWC.Configuration.GatewayPrivateKey
        };
    }
}