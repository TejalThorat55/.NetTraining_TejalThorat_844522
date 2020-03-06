using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCIssueTrackerCode.Models;

namespace MVCIssueTrackerCode.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DatabaseClass ctx = new DatabaseClass();
                    var r1 = ctx.LoginDetail.Where(e => e.UserName == model.UserName && e.Password == model.Password).FirstOrDefault();
                    if (r1 != null)
                    {
                        Session["UserId"] = r1.UserId;
                        int uid = int.Parse(Session["UserId"].ToString());
                        var r2 = ctx.MapDetail.Where(f => f.UserId == uid).Select(f => f).FirstOrDefault();
                        Session["RoleId"] = r2.RoleId;
                        if (int.Parse(Session["RoleId"].ToString()) == 1)
                            return RedirectToAction("Project", "Main");
                        else if (int.Parse(Session["RoleId"].ToString()) == 2)
                            return RedirectToAction("Manager", "Main");
                        else if (int.Parse(Session["RoleId"].ToString()) == 3)
                            return RedirectToAction("Developer", "Main");
                    }
                    ViewBag.msg = "alert('Error in login...Enter correct credentials')";
                }
                return View(model);
            }
            catch (Exception exp)
            {
                return RedirectToAction("Error", "Main");
            }
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
