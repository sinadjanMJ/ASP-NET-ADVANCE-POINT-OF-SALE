using System;
using System.Collections.Generic;

namespace SinadjanSEMI.Entities
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public float SubTotal { get; set; }
        public float Discount { get; set; }
        public float Deduction { get; set; }
        public float TotalAmount { get; set; }
        public float PaidAmount { get; set; }
        public float Orchange { get; set; }
        public string DatePurchased { get; set; }
    }
}
