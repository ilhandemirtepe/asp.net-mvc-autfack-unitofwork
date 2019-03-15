using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutofacExample.Entities.Model;
using AutofacExample.Services.IRepository;

namespace AutofacExample.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productServices;
        private ICategoryService _categoryService;

        public ProductController(IProductService productServices, ICategoryService categoryService)
        {
            _productServices = productServices;
            _categoryService = categoryService;
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Addnew(ProductModel model)
        {
            return Json(_productServices.Addnew(model), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCategory()
        {
            return Json(_categoryService.GetAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllProduct()
        {
            return Json(_productServices.GetAll(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            _productServices.Delete(id);
            return Json("true", JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckCode(string code)
        {
            return Json(_productServices.CheckCode(code), JsonRequestBehavior.AllowGet);
        }
    }
}