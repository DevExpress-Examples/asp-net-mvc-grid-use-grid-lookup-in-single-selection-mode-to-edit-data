using E2979MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E2979MVC.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        NorthwindDataContext context = new NorthwindDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductsGridViewPartial()
        {
            var model = context.Products;
            ViewData["Categories"] = context.Categories;
            return PartialView(model);
        }

        public ActionResult GridLookupPartial(int? CurrentCategory)
        {
            ViewData["Categories"] = context.Categories;
            if (CurrentCategory == null)
                CurrentCategory = -1;
            return PartialView(new Product() { CategoryID = (int)CurrentCategory });
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ProductsGridViewAddNewPartial(Product item)
        {
            var model = context.Products;
            ViewData["Categories"] = context.Categories;
            if (ModelState.IsValid)
            {
                try
                {
                    model.InsertOnSubmit(item);
                    context.SubmitChanges(); //uncomment this line to save changes to a data base
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
           
            return PartialView("_ProductsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ProductsGridViewUpdatePartial(Product item)
        {
            var model = context.Products;
            ViewData["Categories"] = context.Categories;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ProductID == item.ProductID);
                    if (modelItem != null)
                    {
                        modelItem.ProductName = item.ProductName;
                        modelItem.UnitPrice = item.UnitPrice;
                        modelItem.CategoryID = item.CategoryID;
                        modelItem.QuantityPerUnit = item.QuantityPerUnit;                      
                     //   context.SubmitChanges(); uncomment this line to save changes to a data base
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
           
            return PartialView("ProductsGridViewPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult ProductsGridViewDeletePartial(System.Int32 ProductID)
        {

            var model = context.Products;
            ViewData["Categories"] = context.Categories;
            if (ProductID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ProductID == ProductID);
                    if (item != null)
                        model.DeleteOnSubmit(item);
                    // context.SubmitChanges(); uncomment this line to save changes to a data base
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }

            return PartialView("_ProductsGridViewPartial", model);
        }
    }
}