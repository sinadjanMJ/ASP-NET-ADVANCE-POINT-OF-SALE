using System;
using System.Collections.Generic;

namespace SinadjanSEMI.Entities
{
    public partial class Orderdetail
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float ProductTotal { get; set; }
    }
}
