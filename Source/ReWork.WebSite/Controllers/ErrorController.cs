﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReWork.WebSite.Controllers
{
    public class ErrorController : Controller
    {  
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult ServerError()
        {
            //TODO: сделать логгировнаие
            return View();
        }
    }
}