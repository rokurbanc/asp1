 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcLoginRegistration.Models;

namespace MvcLoginRegistration.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            using (OurDbContext db = new OurDbContext())
            {
                return View(db.uAccount.ToList());
            }
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UAccount account)
        {

            if(ModelState.IsValid)
            {
                using (OurDbContext db = new OurDbContext())
                {

                    db.uAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Username + " sucessfully registered!";
            }
            return View();
        }


        //loginIn
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UAccount user)
        {

            using (OurDbContext db = new OurDbContext())
            {
                var usr = db.uAccount.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    Session["UserId"] = usr.UserID.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else {

                    ModelState.AddModelError("","Wrong usernae or password");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (Session["userId"] !=null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
 
            }
        }




    }
}