using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinadjanSEMI.ViewModel
{
    public class stockProdHistory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AStockId { get; set; }
        public int ProdId { get; set; }
        public int AddedStock { get; set; }
        public string Date { get; set; }
    }
}