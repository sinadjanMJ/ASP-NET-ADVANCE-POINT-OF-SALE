using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SinadjanSEMI.Entities;
using System.Diagnostics;
using SinadjanSEMI.ViewModel;
using Microsoft.AspNetCore.Cors;

namespace SinadjanSEMI.Controllers
{
    [EnableCors]
    [Route("/api/[controller]/[action]")]
    public class NewAPIController : ControllerBase
    {

        private readonly semiContext _context;

        public NewAPIController(semiContext context)
        {
            _context = context; 
        }

        // [HttpGet]
        // public  async Task<ActionResult<List<Product>>> getAllProducts(){
        //   var sheesssh = await _context.Products.ToListAsync();
        //   return  Ok(sheesssh);
        // }

        
        // [HttpPost]
        // public  async Task<ActionResult<Product>> addprods(Product varProduct){
        //     _context.Products.Add(varProduct);
        //   await _context.SaveChangesAsync();
        //   return Ok();
        // }

         public ActionResult<List<Addcart>> count(){
            return _context.Addcarts.ToList();
        }
        public ActionResult<List<ProductViewModel>> getAllProduct()
        {
          


            var result = (
                from p in _context.Products
                join c in _context.Categories
                on p.Category equals c.Id.ToString() // naka base siya table if int ba or sting kung int mag tostring ka

                select new ProductViewModel
                {

                   
                   Id = p.Id,
                    Category = c.Id,
                    CategoryName = c.Name,
                    Name = p.Name,
                    Units = p.Units,
                    Stock = p.Stock,
                    Price = p.Price,
                    Status = p.Status
                }



            ).ToList();
            return Ok(result);
        }
      
      public IActionResult addProduct(Product p)
        {
            if(string.IsNullOrEmpty(p.Status) || p.Status == "false")
            {
                //  p.Status = "Inactive";
                p.Status = "Active";
            }
            _context.Products.Add(p);
            _context.SaveChanges();
            return Ok();
        }

        

        public IActionResult updateProduct(Product p)
        {
            if(string.IsNullOrEmpty(p.Status) || p.Status == "false")
            {
                // p.Status = "Inactive";
                p.Status = "Active";
            }
            else
            {
                 p.Status = "Active";
                p.Status = "Inactive";
            }
            _context.Products.Update(p);
            _context.SaveChanges();
            return Ok();
        } 

         public IActionResult deleteProduct(int id)
        {
            var res = _context.Products.Where(q => q.Id == id).FirstOrDefault();
            _context.Products.Remove(res);
            _context.SaveChanges();
            
            return Ok();
        }
    

        public IActionResult addStockProduct(Product p, int iStock ,string date)
        {
            Stockhistory sh = new Stockhistory();

            p.Stock += iStock;
            _context.Products.Update(p);

            sh.AddedStock = iStock;
            sh.ProdId = p.Id;
            sh.Date = date;

            _context.Stockhistories.Add(sh);
            _context.SaveChanges();
            return Ok();
        }
       public IActionResult addCart(Addcart ct)
        {
            _context.Addcarts.Add(ct);
            _context.SaveChanges();
            return Ok(ct);
        }

         public IActionResult updateCart(Addcart ct)
        {
            _context.Addcarts.Update(ct);
            _context.SaveChanges();
            return Ok(ct);
        }
         public ActionResult<List<Addcart>> popCart(){
            var res = 
            (
                from cp in _context.Addcarts
                join p in _context.Products on cp.ProdId equals p.Id
                join c in _context.Categories on p.Category equals c.Id.ToString()

                select new cartList
                {
                    Id = p.Id,
                    Category = c.Id,
                    CategoryName = c.Name,
                    Name = p.Name,
                    Units = p.Units,
                    Stock = p.Stock,
                    Price = p.Price,
                    Status = p.Status,
                    Quantity = cp.CQuantity,
                   mTotal = cp.CMocktotal,
                   MockStock = cp.CMockstock,
                    cartID = cp.CartId
                }
            ).ToList();

            return Ok(res);
        }
        public ActionResult<List<Product>> viewStockHistory(int id){
            
            //return _context.Products.ToList();
            var res = _context.Stockhistories.ToList().Where(p => p.ProdId == id);

            return Ok(res);
        } 

         public IActionResult deleteCart(int cartID)
        {
            var res = _context.Addcarts.Where(q => q.CartId == cartID).FirstOrDefault();
            _context.Addcarts.Remove(res);
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult savetoOrder(Order ord)
        {
            _context.Orders.Add(ord);
            _context.SaveChanges();

            //Get the current order id
            //var res = _context.Orders.LastOrDefault();
            var lastId = _context.Orders.OrderByDescending(x => x.OrderId).FirstOrDefault()?.OrderId;
            return Ok(lastId);
        }

        public IActionResult savetoOrderDetails(Orderdetail ordtls, int mStock)
        {
            _context.Orderdetails.Add(ordtls);
            _context.SaveChanges();


            //UPDATE THE STOCK
            Product p = new Product();
            var res = _context.Products.Where(q => q.Id == ordtls.ProductId).FirstOrDefault();
            res.Stock = mStock;

            _context.Products.Update(res);
            _context.SaveChanges();
            return Ok();
        }

        public IActionResult clearCart()
        {
            _context.Addcarts.RemoveRange(_context.Addcarts);
            _context.SaveChanges();
            return Ok();
        } 

         public ActionResult<List<Order>> getAllOrders(){
            return  _context.Orders.ToList();
        }

        public ActionResult<List<orderInfo>> getAllOrderDetails(int id){
            var res = 
            (
                from od in _context.Orderdetails
                join p in _context.Products on od.ProductId equals p.Id
                join o in _context.Orders on od.OrderId equals o.OrderId
                where o.OrderId == id

                select new orderInfo
                {
                    // productName = p.Name,
                    // OrderDetailsId = od.OrderDetailsId,
                    // OrderId = o.OrderId,
                    // ProductId = p.Id,
                    // Quantity = od.Quantity,
                    // ProductTotal = od.ProductTotal

                     productName = p.Name,
                    prodUnit = p.Units,
                    prodPrice = p.Price,
                    OrderDetailsId = od.OrderDetailsId,
                    OrderId = o.OrderId,
                    ProductId = p.Id,
                    Quantity = od.Quantity,
                    ProductTotal = od.ProductTotal,
                    subTotal = o.SubTotal,
                    deduction = o.Deduction,
                    totalAmount = o.TotalAmount,
                    paidAmount = o.PaidAmount,
                    sukli = o.Orchange,
                    adlaw = o.DatePurchased
                }
            ).ToList();

            return Ok(res);
        }
           
    }
}
