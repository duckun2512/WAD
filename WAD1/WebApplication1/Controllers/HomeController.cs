using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Product()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Product(Product product)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        public ActionResult Brand()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Brand(Brand brand)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                return View(brand);
            }
            catch
            {
                return View(brand);
            }
        }
    }
}