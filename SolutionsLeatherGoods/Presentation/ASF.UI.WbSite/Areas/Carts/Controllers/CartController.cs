using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.UI.Process;
using ASF.Entities;

namespace ASF.UI.WbSite.Areas.Carts.Controllers
{
    public class CartController : Controller
    {
        
        public ActionResult Index()
        {
            var cp = new CartProcess();
            var lista = cp.SelectList();
            return View(lista);
        }

        
        public ActionResult Details(int id)
        {
            var cp = new CartProcess();
            var cart = cp.FindByID(id);

            return View(cart);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult Create(Cart cart)
        {
            var cp = new CartProcess();
            cp.Add(cart);
            return RedirectToAction("Index");
        }

        
        public ActionResult Delete(Cart cart)
        {
            var cp = new CartProcess();
            cp.Delete(cart);
            return RedirectToAction("Index");
        }

      
        public ActionResult Edit(int id)
        {
            var cp = new CartProcess();
            var cart = cp.FindByID(id);

            return View(cart);
        }

        [HttpPost]
       
        public ActionResult Edit(Cart cart)
        {
            var cp = new CartProcess();
            cp.Edit(cart);
            return RedirectToAction("Index");
        }
    }
}