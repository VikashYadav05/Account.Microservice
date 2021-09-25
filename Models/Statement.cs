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

        [Required(ErrorMessage ="Account id required")]
        public int AccountID { get; set; }
       // [Required(ErrorMessage = "Account id required")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "description required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "withdrawal amount requird required")]

        public double Withdrawal { get; set; }
        [Required(ErrorMessage = "deposite amount  required")]
        public double Deposite { get; set; }
        [Required(ErrorMessage = "closing balance required")]
        public double ClosingBalance { get; set; }
    }
}
