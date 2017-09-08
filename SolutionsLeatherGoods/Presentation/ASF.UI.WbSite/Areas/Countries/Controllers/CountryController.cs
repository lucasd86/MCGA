using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASF.Business;

namespace ASF.UI.WbSite.Areas.Countries.Controllers
{
    public class CountryController : Controller
    {
        // GET: Countries/Country
        public ActionResult Index()
        {

            CountryBusiness countryBUS = new CountryBusiness();
            List<Entities.Country> countryList = new List<Entities.Country>();
            countryList = countryBUS.All();
            return View(countryList);
           
        }
    }
}