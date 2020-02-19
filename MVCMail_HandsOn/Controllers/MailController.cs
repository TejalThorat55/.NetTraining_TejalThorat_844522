using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.SqlClient;
using MVC_MailHandsOn.Models;

namespace MVC_MailHandsOn.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string un, string pwd)
        {
            TejalEntities1 ctx = new TejalEntities1();

            var res= ctx.UserInfoes.Where(n=>n.UserName==un && n.Passwrd==pwd).FirstOrDefault();

            if(res!=null)
            {
                return Redirect("/Mail/Process?ID=" + res.UserId);
            }
            ViewBag.msg = "UserId and Password Doesn't Match";
            return View();
        }

       
        public ActionResult Process()
        {
            int id = int.Parse(Request["ID"]);

            MVCMail model = new MVCMail();

            TejalEntities1 ctx = new TejalEntities1();

            var obj = ctx.MailDetails.Where(u => u.UserId == id);

            foreach(var a in obj)
            {
                

                ViewBag.mailid = a.MailId;
                ViewBag.mailfrom = a.MailFrom;
                ViewBag.sub = a.Sub;
                ViewBag.receivedate = a.ReceiveDate;
                ViewBag.msg = a.Msg;

               
            }
            return View();
        }
    }
}