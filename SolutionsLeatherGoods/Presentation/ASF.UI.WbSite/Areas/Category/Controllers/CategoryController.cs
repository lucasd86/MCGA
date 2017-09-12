using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Entities;
using ASF.UI.Process;

namespace ASF.UI.WbSite.Areas.Category.Controllers
{
    public class CategoryController : Controller

    {

        public ActionResult Index()
        {
            var cp = new CategoryProcess();
            var lista = cp.SelectList();
            return View(lista);
        }


        public ActionResult Detail(int id)
        {
            var cp = new CategoryProcess();
            var lista = cp.FindByID(id);
            return View(lista);
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Entities.Category cat)
        {
            var cp = new CategoryProcess();
            cp.Add(cat);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cp = new CategoryProcess();
            var category = cp.FindByID(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Entities.Category cat)
        {
            var cp = new CategoryProcess();
            cp.Edit(cat);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cp = new CategoryProcess();
            var category = cp.FindByID(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Delete(Entities.Category cat)
        {
            var cp = new CategoryProcess();
            cp.Delete(cat);
            return RedirectToAction("Index");

        }

    }
}