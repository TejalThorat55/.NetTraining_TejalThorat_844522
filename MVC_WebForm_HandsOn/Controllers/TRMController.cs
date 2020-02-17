using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MVC_Webform_HandsOn;

namespace MVC_Webform_HandsOn.Controllers
{
    public class TRMController : Controller
    {
        // GET: TRM
        [HttpPost]
        public ActionResult Index(string re, string sk, DateTime st, DateTime en)
        {
            PIYAEntities ctx = new PIYAEntities();
            New_Training tr = new New_Training();

            tr.Req_Name = re;
            tr.Skill = sk;
            tr.Start_D = st;
            tr.End_D = en;
            ctx.New_Training.Add(tr);
            ctx.SaveChanges();
           

            return View();
        }
    

    
    public ActionResult Index()
    {
        return View();
    }
        }
}