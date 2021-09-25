using Account.Microservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Microservice.Repo
{
    public interface IAccountCustomerRepo
    {
        public AccountCreationStatus CreateAccount(Models.Account account,ApplicationDbContext _context);

        public IEnumerable<Models.Account> GetCustomerAccounts(int CustomerID,ApplicationDbContext _context);
    }
}
