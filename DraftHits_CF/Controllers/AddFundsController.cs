using Braintree;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DraftHits_CF.Models;
//using System.Transactions;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.SqlServer;
//using DraftHits_CF.DAL; 

namespace DraftHits_CF.Controllers
{
   

    public class Constants
    {
        public static BraintreeGateway Gateway = new BraintreeGateway
        {
            Environment = Braintree.Environment.SANDBOX,
            MerchantId = "m5nfyykh6cj6gsq6",
            PublicKey = "gvbpnsx8bh3n5cs3",
            PrivateKey = "395167aa266074f8200145cc91f61516"
        };
    }

    public class AddFundsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AddFunds
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTransaction(FormCollection collection)
        {
            TransactionRequest request = new TransactionRequest
            {
                Amount = 1000,
                CreditCard = new TransactionCreditCardRequest
                {
                
                    CardholderName = collection["cardholdername"],
                    Number = collection["number"],
                    CVV = collection["cvv"],
                    ExpirationMonth = collection["month"],
                    ExpirationYear = collection["year"]
                },
                BillingAddress = new AddressRequest
                {
                    PostalCode =  collection["postalcode"]
                },
                Options = new TransactionOptionsRequest
                {
                   
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = Constants.Gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                Transaction transaction = result.Target;
                ViewData["TransactionId"] = transaction.Id;


                //update transaction log

                //update balance

                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = manager.FindById(User.Identity.GetUserId());


                //##Update Balance with entity update query

                //long currentUserID = Convert.ToInt64(currentUser.Customer.Id);
                //DH_datasetTableAdapters.CustomersTableAdapter customerAdapter = new DH_datasetTableAdapters.CustomersTableAdapter();
                //customerAdapter.UpdateBalance(currentUser.Customer.Balance + 10 , currentUserID);

                using (var dbContext = new ApplicationDbContext())
                {
                    using (var dbContextTransaction = dbContext.Database.BeginTransaction())
                    {
                        var dbSetCustomer = dbContext.Set<Models.Customer>();
                        var customer = dbSetCustomer.FirstOrDefault(x => x.User.Id == currentUser.Id);
                        
                        customer.Balance += 10;
                                            
                        var dbSetCustomerTransaction = dbContext.Set<Models.CustomerTransaction>();
                        var customerTransaction = new Models.CustomerTransaction();

                        customerTransaction.CustomerId = customer.Id;
                        customerTransaction.Credit = 10;
                        customerTransaction.CustomerTransactionType = CustomerTransactionType.EntryFee;
                        customerTransaction.Debit = 20;
                        customerTransaction.TransactionDate = DateTime.Now;

                        dbSetCustomerTransaction.Add(customerTransaction);

                        dbContext.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                }

                //## Check First Time Bonus
            }
            else
            {
                ViewData["Message"] = result.Message  + result.Transaction;
            }

            return View();
        }



    }
}