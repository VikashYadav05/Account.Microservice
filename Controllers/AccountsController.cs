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
        [HttpGet("cid/{CustomerID}")]
        public IEnumerable<Models.Account> GetCustomerAccounts(int CustomerID)
        {
            return null;
        }


        //GET api/<AccountController>/{id}/{fromdate}/{todate}
        [HttpGet("getaccounts/{AccountID}/{FromDate}/{ToDate}")]
        public IEnumerable<Statement> GetAccountStatement(int AccountID,DateTime FromDate,DateTime ToDate)
        {
            List<Statement> Statement = new List<Statement>();
            return Statement;
        }


        //GET api/<AccountController>/{id}
        [HttpGet("aid/{AccountID}")]
        public Models.Account GetAccount(int AccountID)
        {
            Models.Account Account = new Models.Account();
            return Account;
        }

        // POST api/<AccountController>
        [HttpPost("createacc/{CustomerID}")]
        public AccountCreationStatus CreateAccount(int CustomerID,Models.Account account)
        {
            int n = 0;
            account.AccountID = 0;
            if (ModelState.IsValid)
            {
                var accountId = _context.Add(account);
                _context.SaveChanges();
                 n = accountId.Entity.AccountID;
                Console.Write(accountId);

            }
            if (n != 0)
                return new AccountCreationStatus(n, "success");
            return new AccountCreationStatus(0, "fail");
        }

        //POST api/<AcountController>/{AccountID}/{Amount}
        [HttpPost("deposit/{AccountID}/{Amount}")]
        public IActionResult Deposite(int AccountID,float Amount)
        {
            var account = _context.Account.Find(AccountID);
            if(account!=null)
            {
                account.AccountBalance += Amount;
                _context.Update(account);
                _context.SaveChanges();
                return Ok(Amount+" ammount Deposited");
            }
            return BadRequest("Unable to deposit ");
        }

        //POST api/<AcountController>/{AccountID}/{Amount}
        [HttpPost("withdraw/{AccountID}/{Amount}")]
        public TransactionStatus Withdraw(int AccountID, double Amount)
        {
            return new TransactionStatus();
        }

        private bool AccountExists(int id)
        {
            return _context.Account.Any(e => e.AccountID == id);
        }
    }
}
