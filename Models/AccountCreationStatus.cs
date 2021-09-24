using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Microservice.Models
{
    public class AccountCreationStatus
    {
        public int AccountId { get; set; }
        public string Message { get; set; }
        public AccountCreationStatus(int id,string m)
        {
            AccountId = id;
            Message = m;
        }
    }
    
}
