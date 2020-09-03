using AspDotnetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace AspDotnetProject.Controllers
{
    public class LoginController : Controller
    {
        AspProjectEntities db = new AspProjectEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user_ objchk)
        {
            if(ModelState.IsValid)
            {
                using (AspProjectEntities db = new AspProjectEntities())
                {
                    var obj = db.user_.Where(a => a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();

                    if(obj != null)
                    {
                        Session["userID"] = obj.id.ToString();
                        Session["userNAME"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", " The Username or Password is incorrect");
                    }
                }
                  

            }


            return View(objchk);

        }

        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }


    }
}