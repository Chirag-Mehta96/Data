using RetreieveImage.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RetreieveImage.Controllers
{
    public class HomeController : Controller
    {
        Entities db = new Entities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDetails(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                byte[] bytes;
                using (System.IO.BinaryReader br = new BinaryReader(image.InputStream))
                {
                    bytes = br.ReadBytes(image.ContentLength);
                }
                Product data = new Product() { Name = product.Name, Price = product.Price, P_Description = product.P_Description, P_Image = bytes };
                db.Products.Add(data);
                db.SaveChanges();
            }
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult ShowData()
        {
            Entities entities = new Entities();
            return View(from Product in entities.Products
                        select Product);
        }
    }
}