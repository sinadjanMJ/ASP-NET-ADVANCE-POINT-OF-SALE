using System;
using System.Collections.Generic;

namespace SinadjanSEMI.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Units { get; set; }
        public int Stock { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
    }
}
