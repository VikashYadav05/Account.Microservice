using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Microservice.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        public float AccountBalance { get; set; }

        public int AccountType { get; set; }
    }

    public enum AccountType
    {
        current,
        savings
    }
   
}
