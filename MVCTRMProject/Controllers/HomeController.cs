using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace MVCCodeTRMProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(string un, string pwd)
        {
            DBModel ctx = new DBModel();

            var a = ctx.LoginDetails.Where(e => e.UserName == un && e.Password == pwd).FirstOrDefault();
            if (a != null)
            {
                int b = a.RoleId;
                Session["RoleId"] = b;
                if (int.Parse(Session["RoleId"].ToString()) == 1)
                    return RedirectToAction("trmindex", "TRMRequest");
                else if (int.Parse(Session["RoleId"].ToString()) == 2)
                    return RedirectToAction("pocindex", "TRMRequest");
                else if (int.Parse(Session["RoleId"].ToString()) == 3)
                    return RedirectToAction("execindex", "TRMRequest");
            }
            else
                ViewBag.msg = "Error in login...Enter correct credentials";
            //return RedirectToAction("jQueryFixes.js", "Context");
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}