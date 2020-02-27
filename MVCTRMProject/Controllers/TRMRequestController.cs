using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCodeTRMProject.Models;

namespace MVCCodeTRMProject.Controllers
{
    public class TRMRequestController : Controller
    {
        // GET: TRMRequest
        public ActionResult trmindex()
        {
            //For PM
            DBModel ctx = new DBModel();
            var res = (from i in ctx.LoginDetails select i).FirstOrDefault();
            string name = res.UserName;
            ViewBag.msg = "Hello..." + name + " [Project Manager]";
            //To view the data from database
            // add one model to view data
            var req = from i in ctx.RequestDetails select i;
            List<DataView> t = new List<DataView>();

            foreach (var i in req)
            {
                DataView dv = new DataView();
                dv.RequestId = i.RequestId;
                dv.RequestName = i.RequestName;
                dv.Skill = i.Skill;
                dv.StartDate = i.StartDate;
                dv.EndDate = i.EndDate;
                dv.Status = i.Status;
                dv.TrainerId = i.TrainerId;
                dv.ExecId = i.ExecId;
                t.Add(dv);
                ctx.SaveChanges();
            }

            return View(t);
        }

        public ActionResult trmindex1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult trmindex1(string rname, string skill, DateTime sdate, DateTime edate)
        {
            //To fetch the data to database
            DBModel ctx = new DBModel();
            RequestDetail r = new RequestDetail();
            r.RequestName = rname;
            r.Skill = skill;
            r.StartDate = sdate;
            r.EndDate = edate;
            r.Status = "Requested";
            ctx.RequestDetails.Add(r);
            ctx.SaveChanges();
            return RedirectToAction("trmindex", "TRMRequest");
            //return View();
        }
        public ActionResult trmindex2(int rid)
        {
            //to do for PM
            DBModel ctx = new DBModel();
            var a = (from i in ctx.RequestDetails where i.RequestId == rid select i).FirstOrDefault();
            a.Status = "Confirmed";
            ctx.SaveChanges();
            return RedirectToAction("trmindex", "TRMRequest");
        }

        public ActionResult pocindex()
        {
            //For POC
            DBModel ctx = new DBModel();
            var res = (from i in ctx.LoginDetails select i).FirstOrDefault();
            string name = res.UserName;
            ViewBag.msg = "Hello..." + name + " [Point of Contact]";

            var req = from i in ctx.RequestDetails select i;
            List<DataView> t = new List<DataView>();

            foreach (var i in req)
            {
                DataView dv = new DataView();
                dv.RequestId = i.RequestId;
                dv.RequestName = i.RequestName;
                dv.Skill = i.Skill;
                dv.StartDate = i.StartDate;
                dv.EndDate = i.EndDate;
                dv.Status = i.Status;
                dv.TrainerId = i.TrainerId;
                dv.ExecId = i.ExecId;
                t.Add(dv);
                ctx.SaveChanges();
            }
            return View(t);
        }
        public ActionResult pocindex1(int rid)
        {
            Session["rid"] = rid;
            return View();
        }
        [HttpPost]
        public ActionResult pocindex1(int tid, int eid)
        {
            int rid = int.Parse(Session["rid"].ToString());
            DBModel ctx = new DBModel();
            var r = (from i in ctx.RequestDetails where i.RequestId == rid select i).FirstOrDefault();
            r.TrainerId = tid;
            r.ExecId = eid;
            r.Status = "Assigned";
            ctx.SaveChanges();
            return RedirectToAction("pocindex", "TRMRequest");
        }

        public ActionResult execindex()
        {
            //For Executive
            DBModel ctx = new DBModel();
            var res = (from i in ctx.LoginDetails select i).FirstOrDefault();
            string name = res.UserName;
            ViewBag.msg = "Hello..." + name + " [Executive]";

            var req = from i in ctx.RequestDetails select i;
            List<DataView> t = new List<DataView>();

            foreach (var i in req)
            {
                DataView dv = new DataView();
                dv.RequestId = i.RequestId;
                dv.RequestName = i.RequestName;
                dv.Skill = i.Skill;
                dv.StartDate = i.StartDate;
                dv.EndDate = i.EndDate;
                dv.Status = i.Status;
                dv.TrainerId = i.TrainerId;
                dv.ExecId = i.ExecId;
                t.Add(dv);
                ctx.SaveChanges();
            }
            return View(t);
        }
        public ActionResult execindex1(int rid)
        {
            //To fetch the data to database
            DBModel ctx = new DBModel();
            var a = (from i in ctx.RequestDetails where i.RequestId == rid select i).FirstOrDefault();
            a.Status = "Ongoing Process";
            ctx.SaveChanges();
            return RedirectToAction("execindex", "TRMRequest");
        }
        public ActionResult execindex2(int rid)
        {
            //To fetch the data to database
            DBModel ctx = new DBModel();
            var a = (from i in ctx.RequestDetails where i.RequestId == rid select i).FirstOrDefault();
            a.Status = "Completed";
            ctx.SaveChanges();
            return RedirectToAction("execindex", "TRMRequest");
        }
    }
}