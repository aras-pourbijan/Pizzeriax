using Microsoft.Ajax.Utilities;
using Pizzeriax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizzeriax.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

         [Authorize(Users = "admin")]
        public ActionResult Gestione()
        {

            return View();
        }


    }

}