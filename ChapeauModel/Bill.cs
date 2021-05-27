using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Bill
    {
        public int Id { get; set; }

        public Order Order { get; set; }

        public decimal OrderPrice { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public DateTime Date { get;  set; }

        public decimal Tip { get; set; }

        public string Feedback { get; set; }

        public decimal VAT { get; set; }

        public decimal TotalPrice 
        { 
            get { return VAT + OrderPrice + Tip; } 
        }
    }
}
