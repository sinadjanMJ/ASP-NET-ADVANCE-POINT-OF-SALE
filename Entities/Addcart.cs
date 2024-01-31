using System;
using System.Collections.Generic;

namespace SinadjanSEMI.Entities
{
    public partial class Addcart
    {
        public int CartId { get; set; }
        public int ProdId { get; set; }
        public int CQuantity { get; set; }
        public int CMocktotal { get; set; }
        public int CMockstock { get; set; }
    }
}
