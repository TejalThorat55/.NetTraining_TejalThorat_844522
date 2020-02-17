using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace MVC_HandsOn.Controllers
{
    public class New_UserController : Controller
    {
        // GET: New_User
        public ActionResult Index()
        {
           
            return View();
        }

        
        [HttpPost]
        public ActionResult Index(string UN, string pwd)
        {
            HANDSONEntities1 ctx = new HANDSONEntities1();

            LoginInfo a = new LoginInfo();
            UserDetail b = new UserDetail();

            
            var rec = ctx.LoginInfoes.Where(d => d.UserName == UN && d.Passwrd == pwd).FirstOrDefault();
            if(rec!=null)
            {
                /* */
                return Redirect("/New_User/Output?ID="+rec.UserId);
            }
            ViewBag.Msg = "Error in SignIn";
            return View();
        }

      

        public ActionResult Output()
        {

            int id = int.Parse(Request["ID"]);
            
           

            HANDSONEntities1 ctx = new HANDSONEntities1();

            var obj = ctx.UserDetails.Where(u => u.UserId == id).FirstOrDefault();
            if (obj != null)
            {
                ViewBag.FullNme = obj.FullName;
                ViewBag.age = obj.Age;
                ViewBag.city = obj.City;
                ViewBag.rep = obj.ReportingTo;
            }
            return View();
        }
    }
}