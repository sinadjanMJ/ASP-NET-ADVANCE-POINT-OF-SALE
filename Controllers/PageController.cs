using Microsoft.AspNetCore.Mvc;
using SinadjanSEMI.Entities;

namespace SinadjanSEMI.Controllers
{
    public class PageController : Controller
    {
       
        public ActionResult Product(){
            return View();
        }


        public ActionResult ProductList(){
            return View();
        }


    }
}