using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Microservice.Models
{
    public class Account
    {   
      
        public int CustomerID { get; set; }
        [Key]
        public int AccountID { get; set; }
        [Required(ErrorMessage ="Balance requird")]
        public float AccountBalance { get; set; }

        [Required(ErrorMessage = "Account type requird")]
        public int AccountType { get; set; }
    }

    public enum AccountType
    {
        current,
        savings
    }
   
}
