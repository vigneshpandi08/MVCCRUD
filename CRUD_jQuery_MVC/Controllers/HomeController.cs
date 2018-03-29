using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_jQuery_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ApplicationEntities entities = new ApplicationEntities();
            return View(entities.Products);
        }

        [HttpPost]
        public JsonResult AddProduct(Product product)
        {
            using (ApplicationEntities entities = new ApplicationEntities())
            {
                entities.Products.Add(product);
                entities.SaveChanges();
            }

            return Json(product);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            using (ApplicationEntities entities = new ApplicationEntities())
            {
                Product updatedCustomer = (from c in entities.Products
                                            where c.ProductId ==product.ProductId
                                            select c).FirstOrDefault();
                updatedCustomer.ProductName = product.ProductName;
                updatedCustomer.ProductCode = product.ProductCode;
                updatedCustomer.Quantity = product.Quantity;
                updatedCustomer.Amount = product.Amount;
                updatedCustomer.TaxPercent = product.TaxPercent;
                updatedCustomer.TaxAmount = product.TaxAmount;
                updatedCustomer.NetAmount = product.NetAmount;
                updatedCustomer.Category = product.Category;
                entities.SaveChanges();
            }

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult DeleteProduct(int productId)
        {
            using (ApplicationEntities entities = new ApplicationEntities())
            {
                Product customer = (from c in entities.Products
                                     where c.ProductId == productId
                                    select c).FirstOrDefault();
                entities.Products.Remove(customer);
                entities.SaveChanges();
            }
            return new EmptyResult();
        }
    }
}