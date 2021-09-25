using Account.Microservice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Microservice.Repo
{
    public class AccountCustomerRepo : IAccountCustomerRepo
    {
        public AccountCreationStatus CreateAccount(Models.Account account, ApplicationDbContext _context)
        {
            int n = 0;
            account.AccountID = 0;
           
           
                var accountId = _context.Add(account);
                _context.SaveChanges();
                n = accountId.Entity.AccountID;
                Console.Write(accountId);

            
            if (n != 0)
                return new AccountCreationStatus(n, "success");
            return new AccountCreationStatus(0, "fail");

        }

        public IEnumerable<Models.Account> GetCustomerAccounts(int CustomerID, ApplicationDbContext _context)
        {
            return _context.Account.Where(c => c.CustomerID == CustomerID);
        }
    }
}
