using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Microservice.Models;
using Microsoft.OpenApi;
using Account.Microservice.Repo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Account.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        private readonly IAccountCustomerRepo AC_Repo;
        public AccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET api/<AccountController>/5
        [HttpGet("all/{CustomerID}")]
        public IEnumerable<Models.Account> GetCustomerAccounts(int CustomerID)
        {
            return AC_Repo.GetCustomerAccounts(CustomerID, _context); //out List<Models.Account>);
        
        }


        //GET api/<AccountController>/{id}/{fromdate}/{todate}
        [HttpGet("getAccountByID/{AccountID}/{FromDate}/{ToDate}")]
        public IEnumerable<Statement> GetAccountStatement(int AccountID,DateTime FromDate,DateTime ToDate)
        {  
            if(FromDate==default(DateTime) && ToDate==default(DateTime))
            {
                ToDate = DateTime.UtcNow;
                FromDate = DateTime.UtcNow.AddDays(-30);
                return _context.Statement.Where(x => (x.Date <= ToDate && x.Date >= ToDate));
            }
           return _context.Statement.Where(x => (x.Date <= ToDate && x.Date >= ToDate));
        }


        //GET api/<AccountController>/{id}
        [HttpGet("get/{AccountID}")]
        public IActionResult GetAccount(int AccountID)
        {
            var account = _context.Account.Find(AccountID);
            if(account!=null)
            {
                //Models.Account acc = new Models.Account();
                //acc.AccountID = account.AccountID;
                //acc.AccountBalance = account.AccountBalance;
                 
                return Ok(account);
            }
            return NotFound("Account not Found");
        }

        // POST api/<AccountController>
        [HttpPost("create/{CustomerID}")]
        public AccountCreationStatus CreateAccount(Models.Account account)
        {
            return AC_Repo.CreateAccount(account, _context);
        }

        //POST api/<AcountController>/{AccountID}/{Amount}
        [HttpPost("deposit/{AccountID}/{Amount}")]
        public IActionResult Deposite(int AccountID,float Amount)
        {
            var account = _context.Account.Find(AccountID);
            if(account!=null)
            {
                using var transaction = _context.Database.BeginTransaction();

                try
                {
                    transaction.CreateSavepoint("BeforeDeposite");

                    account.AccountBalance += Amount;
                    _context.Update(account);
                    _context.SaveChanges();

                    Statement statement = new Statement();
                    statement.AccountID = AccountID;
                    statement.Date = DateTime.Now;
                    statement.Deposite = Amount;
                    statement.Withdrawal = 0;
                    statement.ClosingBalance = account.AccountBalance;
                    statement.Ref = 0;
                    statement.Description = "Deposited";

                    _context.Statement.Update(statement);
                    _context.SaveChanges();

                    transaction.Commit();
                    return Ok(Amount + " ammount Deposited");
                }
                catch
                {
                    transaction.RollbackToSavepoint("BeforeDeposite");
                }
            }
            return BadRequest("Unable to deposit ");
        }

        //POST api/<AcountController>/{AccountID}/{Amount}
        [HttpPost("withdraw/{AccountID}/{Amount}")]
        public IActionResult Withdraw(int AccountID, float Amount)
        {
            var account = _context.Account.Find(AccountID);
            if (account != null)
            {

                //Will implement Rule Service req for validating withdraw
                using var transaction = _context.Database.BeginTransaction();
                try
                {
                    transaction.CreateSavepoint("BeforeWithdraw");

                    account.AccountBalance -= Amount;
                    _context.Update(account);
                    _context.SaveChanges();

                    Statement statement = new Statement();
                    statement.AccountID = AccountID;
                    statement.Date = DateTime.Now;
                    statement.Deposite = 0;
                    statement.Withdrawal =Amount;
                    statement.ClosingBalance = account.AccountBalance;
                    statement.Ref = 0;
                    statement.Description = "Withdrawn";

                    _context.Statement.Update(statement);
                    _context.SaveChanges();

                    transaction.Commit();

                    return Ok(Amount + " ammount Withdrawn");
                }
                catch
                {
                    transaction.RollbackToSavepoint("BeforeWithdraw");
                }
            }
            return BadRequest("Something went wrong !");

        }
    }
}
