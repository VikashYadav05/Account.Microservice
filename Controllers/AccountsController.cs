using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Microservice.Models;
using Microsoft.OpenApi;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Account.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
      
        public AccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/<AccountController>/5
        [HttpGet("{CustomerID}")]
        public IEnumerable<Models.Account> GetCustomerAccounts(int CustomerID)
        {
            return null;
        }


        //GET api/<AccountController>/{id}/{fromdate}/{todate}
        [HttpGet("{AccountID}/{FromDate}/{ToDate}")]
        public IEnumerable<Statement> GetAccountStatement(int AccountID,DateTime FromDate,DateTime ToDate)
        {
            List<Statement> Statement = new List<Statement>();
            return Statement;
        }


        //GET api/<AccountController>/{id}
        [HttpGet("{AccountID}")]
        public Models.Account GetAccount(int AccountID)
        {
            Models.Account Account = new Models.Account();
            return Account;
        }

        // POST api/<AccountController>
        [HttpPost("{CustomerID}")]
        public AccountCreationStatus CreateAccount(int CustomerId,Models.Account account)
        {
            if (ModelState.IsValid)
            {
                var accountId = _context.Add(account);
                Console.Write(accountId);

            }
            //if ( != null)
                return new AccountCreationStatus(12, "success");
           // return new AccountCreationStatus(0, "fail");
        }

        //POST api/<AcountController>/{AccountID}/{Amount}
        [HttpPost("{AccountID}/{Amount}")]
        public TransactionStatus Deposite(int AccountID,double Amount)
        {
            return new TransactionStatus();
        }

        //POST api/<AcountController>/{AccountID}/{Amount}
        [HttpPost("{AccountID}/{Amount}")]
        public TransactionStatus Withdraw(int AccountID, double Amount)
        {
            return new TransactionStatus();
        }
    }
}
