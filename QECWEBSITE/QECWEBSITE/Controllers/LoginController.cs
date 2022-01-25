using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QECWEBSITE.Models;



namespace QECWEBSITE.Controllers
{
    
    public class LoginController : Controller
    {

        QECPortalEntities db = new QECPortalEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login objcheck)
        {
            var user = db.Logins.Where(model => model.username == objcheck.username && model.password == objcheck.password).FirstOrDefault();
            if (user != null)
            {
                Session["UserId"] = objcheck.id.ToString();
                Session["UserName"] = objcheck.username.ToString();
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfull !!')</script>";
                return RedirectToAction("Index", "Maju");
            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('Username or password is incorrect!!')</script>";
                return View();


            }

        }
    }
}