using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GnocFluentValidation.Models;

namespace GnocFluentValidation.Controllers
{
    public class GnocController : Controller
    {
        //
        // GET: /Gnoc/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View(new GnocModel());
        }

        [HttpPost]
        public ActionResult Create(GnocModel model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "InValid";
                return View(model);
            }
            return View(model);
        }
	}
}