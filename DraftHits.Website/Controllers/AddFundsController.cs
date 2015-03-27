using Braintree;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DraftHits.Website.Models;
using DraftHits.Data;
using DraftHits.Data.Entities;
using DraftHits.Website.Core;
using DraftHits.Data.Repo;
using DraftHits.Data.Enums;

namespace DraftHits.Website.Controllers
{
    public class AddFundsController : BaseController
    {
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
                
                using (var uow = UnityManager.Resolve<IUnitOfWork>())
                {
                    var repoCustomer = uow.GetRepo<ICustomerRepo>();
                    var repoCustomerTransaction = uow.GetRepo<ICustomerTransactionRepo>();
                    var repoCustomerPaymentsLog = uow.GetRepo<ICustomerPaymentsLogRepo>();

                    var customer = repoCustomer.GetByUserId(User.Id);
                    customer.Balance += 10;

                    customer = repoCustomer.Update(customer);

                    var customerTransaction = new CustomerTransaction();
                    customerTransaction.CustomerId = customer.Id;
                    customerTransaction.Credit = 10;
                    customerTransaction.CustomerTransactionType = CustomerTransactionType.EntryFee;
                    customerTransaction.Debit = 20;
                    customerTransaction.DateTransaction = DateTime.Now;

                    customerTransaction = repoCustomerTransaction.Add(customerTransaction);

                    uow.Commit();

                    var customerPaymentsLog = new CustomerPaymentsLog();
                    customerPaymentsLog.CustomerId = customer.Id;
                    customerPaymentsLog.CustomerTransactionId = customerTransaction.Id;
                    customerPaymentsLog.PaymentAmount = 257;
                    customerPaymentsLog.PaymentProvider = "provider";
                    customerPaymentsLog.PaymentTransactionId = "x4gfds553";
                    customerPaymentsLog.CustomerIPAddress = "10.0.83.32";
                    customerPaymentsLog.DatePayment = DateTime.Now;

                    customerPaymentsLog = repoCustomerPaymentsLog.Add(customerPaymentsLog);

                    uow.Commit();
                }
            }
            else
            {
                ViewData["Message"] = String.Format(@"{0}{1}", result.Message, result.Transaction);
            }

            return View();
        }
    }
}