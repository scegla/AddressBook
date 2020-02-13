using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
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

        [HttpPost]
        public ActionResult Create(Contact cont)
        {
            ContactValidator validator = new ContactValidator();
            ValidationResult result = validator.Validate(cont);

            if (!result.IsValid)
            {
                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
            }

            return View(cont);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            return View(new Contact());
        }

        [HttpPost]
        public ActionResult Edit(Contact cont)
        {
            ContactValidator validator = new ContactValidator();
            ValidationResult result = validator.Validate(cont);

            if (!result.IsValid)
            {
                foreach (ValidationFailure failer in result.Errors)
                {
                    ModelState.AddModelError(failer.PropertyName, failer.ErrorMessage);
                }
            }

            return View(cont);
        }
    }
}