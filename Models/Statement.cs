using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Account.Microservice.Models
{
    public class Statement
    {
        public DateTime Date { get; set; }
        public string Narration { get; set; }
        public DateTime ValueDate { get; set; }
        public double Withdrawal { get; set; }
        public double Deposite { get; set; }

        public double ClosingBalance { get; set; }
    }
}
