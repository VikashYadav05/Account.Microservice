using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Microservice.Models
{
    public class Statement
    {  
        [Key]
        public int Ref { get; set; }

        public int AccountID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
       
        public double Withdrawal { get; set; }
        public double Deposite { get; set; }

        public double ClosingBalance { get; set; }
    }
}
