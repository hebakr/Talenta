using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Talenta.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult CreateOrder()
        {
            return View();
        }
    }
}