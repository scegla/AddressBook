using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneBooth.Models;

namespace PhoneBooth.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new Contact());
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View(new Contact());
        }
    }
}