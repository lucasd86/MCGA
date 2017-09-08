using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;

namespace ASF.UI.WbSite.Areas.Category.Controllers
{
    public class CategoryController : Controller

    {
        


        // GET: Category/Category
        public ActionResult Index()
        {
            ASF.Business.CategoryBusiness CatBus = new ASF.Business.CategoryBusiness();
            Process.CategoryProcess CatProc = new Process.CategoryProcess();
            Entities.Category cat = new Entities.Category();
            
            List<Entities.Category> Listacat = new List<Entities.Category>();
            Listacat = CatBus.All();

            
            return View(Listacat);
        }
    }
}