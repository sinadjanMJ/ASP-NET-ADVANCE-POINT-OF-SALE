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

    public class FlutterAPIController : ControllerBase
    {
         private readonly semiContext _context;

        public FlutterAPIController(semiContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public  async Task<ActionResult<List<Flutterproduct>>> getAllProducts(){
          var sheesssh = await _context.Flutterproducts.ToListAsync();
          return  Ok(sheesssh);
        }

        
        [HttpPost]
        public  async Task<ActionResult<Flutterproduct>> addprods(Flutterproduct varProduct){
            _context.Flutterproducts.Add(varProduct);
          await _context.SaveChangesAsync();
        
          return CreatedAtAction("getproduct",new {id = varProduct.Id},varProduct);
        }

        public IActionResult getproduct(int id){
          var prod = _context.Flutterproducts.FindAsync(id);

          if(prod == null){
          return BadRequest("The value is not Found");
          }
          return Ok(prod);
        }


        
        public  async Task<ActionResult> updateprods(Flutterproduct varProduct){
           if(varProduct != null){
            _context.Flutterproducts.Update(varProduct);
          await _context.SaveChangesAsync();
           }else{
            Console.WriteLine("Teh value is null");
           }
           
         return Ok();
         }


          
        public  IActionResult deleteProd(int id){
          
           var productres = _context.Flutterproducts.Where(element => element.Id == id).FirstOrDefault();
           _context.Flutterproducts.Remove(productres);
           _context.SaveChanges();
        
         return Ok();
    }

      [HttpGet]
     public ActionResult<List<Flutterproduct>> getProdOutOfStock(){
          
            var productVal = _context.Flutterproducts.Where(element => element.Stock <= 0).ToList();
            return Ok(productVal);
    }
    public ActionResult<List<Flutterproduct>> getProdActive(){
            var productRes = _context.Flutterproducts.Where(element => element.Status == "Active" && element.Stock != 0).ToList();
            return Ok(productRes);
   }
    public ActionResult<List<Flutterproduct>> getProdLowOfStock(){
            
            var productVal = _context.Flutterproducts.Where(element => element.Stock <= 5 && element.Stock !=0 && element.Status == "Active" ).ToList();
            return Ok(productVal);
    }

}
}
