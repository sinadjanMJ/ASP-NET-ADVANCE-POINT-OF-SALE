using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinadjanSEMI.ViewModel
{
    public class cartList
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public string CategoryName {get; set;}
        public string Name { get; set; }
        public string Units { get; set; }
        public int Stock { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public int Quantity{ get; set;}
        public int mTotal{ get; set;}
        public int MockStock{ get; set;}
        public int cartID { get; set;}
    }
}