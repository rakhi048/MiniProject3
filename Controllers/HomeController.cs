using MiniProject3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProject3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult Loginuser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Loginuser(Customer obj)
        {

            var res = (from t in dc.Customers
                       where t.Email == obj.Email && t.Pwd == obj.Pwd
                       select t).Count();

            if (res > 0)
            {
                return RedirectToAction("Registration");
            }
            else
            {
                ViewBag.e = "Login failed";
            }

            return View("Loginuser");
        }
        public ActionResult Registration()
        {
            return View();
        }

        MiniProject3Entities dc = new MiniProject3Entities();
        [HttpPost]
        public ActionResult Registration(Customer obj)
        {

            Customer tb1 = new Customer();

            var res = (from t in dc.Customers
                       where t.Custid == obj.Custid
                       select t.Custid).Count();
            if (res == 0)
            {

                tb1.Custid = obj.Custid;
                tb1.Pwd = obj.Pwd;
                tb1.Email = obj.Email;
                dc.Customers.Add(tb1);
                int i = dc.SaveChanges();
                if (i > 0)
                {
                    ViewBag.e = "Registation Successfly Completed";
                }
                else
                {
                    ViewBag.e = "Invalid Registarion";
                }
            }
            else
            {
                ViewBag.e = "User already Presented";
            }
            
            
            return View();
        }
        public ActionResult Menu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Menu(OrderTable obj)
        {
            return View();
        }
        public ActionResult FoodItems()
        {
            

            return View();
        }

        public ActionResult BuyNow()
        {

            return View();
        }
        [HttpPost]
        public ActionResult BuyNow(OrderTable objor, Customer objcust)
        {
            OrderTable tbor = new OrderTable();
            Customer tbcust = new Customer();
            tbor.Orderid = 1;
            tbor.Ordername = "Noodles";
            tbor.Price = 250;
            tbor.CustId = objcust.Custid;
            tbor.Quantity = objor.Quantity;
            tbor.Img = "NoodlesImage";
            dc.OrderTables.Add(tbor);
            int i = dc.SaveChanges();
            if(i > 0)
            {
                ViewBag.e = "Order Placed Noodles";
            }
            else
            {
                ViewBag.e = "Failed in order";
            }

            return View();
        }
       



    }
}