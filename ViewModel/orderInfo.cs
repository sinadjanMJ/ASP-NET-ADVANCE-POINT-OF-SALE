using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinadjanSEMI.ViewModel
{
    public class orderInfo
    {
       
         public string productName { get; set; }
        public string prodUnit { get; set; }
        public string prodPrice { get; set; }
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float ProductTotal { get; set; }
        public float subTotal {get; set;}
        public float deduction {get; set;}
        public float totalAmount {get; set;}
        public float paidAmount {get; set;}
        public float sukli{get; set;}
        public string adlaw { get; set; }
    }
}