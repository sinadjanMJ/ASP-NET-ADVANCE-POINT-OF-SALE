using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinadjanSEMI.ViewModel
{
    public class categoryProdView
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public string CategoryName {get; set;}
        public string Name { get; set; }
        public string Units { get; set; }
        public int Stock { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
    }
}