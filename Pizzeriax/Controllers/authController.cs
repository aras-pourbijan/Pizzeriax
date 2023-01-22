using Pizzeriax.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Pizzeriax.Controllers
{
    public class authController : Controller
    {
        // GET: auth
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(users U)
        {
            try { 
                if (users.Autenticated(U.username, U.password))
                {
                    FormsAuthentication.SetAuthCookie(U.username, false);
                    return Redirect(FormsAuthentication.DefaultUrl);
                }
                else
                {
                    ViewBag.erroreAuth = "Riprova!";
                return View();
                }
            }catch(Exception ex) {

                ViewBag.erroreAuth = ex.Message;
                return View();
            }
            
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return Redirect(FormsAuthentication.LoginUrl);
        }

    }
}