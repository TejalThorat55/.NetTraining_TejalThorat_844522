using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVCIssueTrackerCode;
using MVCIssueTrackerCode.Models;

namespace IssueTrackerMVCproject.Controllers
{
    public class MainController : Controller
    {
        public ActionResult Error()
        {
            ViewBag.msg = "Error Page";
            return View();
        }

        // GET: Main
        public ActionResult Project()
        {
            DatabaseClass ctx = new DatabaseClass();
            int Id = int.Parse(Session["UserId"].ToString());
            ProjectModel model = new ProjectModel();
            var res = from m in ctx.MapDetail
                      join p in ctx.ProjectDetail
                      on m.ProjId equals p.ProjId
                      where m.UserId == Id
                      select new { ProjectId = p.ProjId, ProjectName = p.ProjName, RoleId = m.RoleId };
            var h = ctx.MapDetail.Where(o => o.UserId == Id).FirstOrDefault();
            Session["ProjId"] = h.ProjId;
            Session["RoleId"] = h.RoleId;
            foreach (var entry in res)
            {
                ProjectListItem itm = new ProjectListItem();
                itm.ProjectId = entry.ProjectId;
                itm.ProjectName = entry.ProjectName;
                itm.RoleId = entry.RoleId;
                model.itemlist.Add(itm);
            }
            List<SelectListItem> proj = new List<SelectListItem>();
            //SelectListItem[] proj = new SelectListItem[model.itemlist.Count];
            //int j = 0;
            foreach (var i in model.itemlist)
            {
                proj.Add(new SelectListItem() { Text = i.ProjectName, Value = i.ProjectId.ToString() });
                //j++;
            }
            //ViewBag.proj = proj;
            return View(proj);
        }

        [HttpPost]
        public ActionResult Project(int proj)
        {
            //Select a project
            /*DatabaseClass ctx = new DatabaseClass();
            int Id = int.Parse(Session["UserId"].ToString()); 
            ProjectModel model = new ProjectModel();
            var res = from m in ctx.MapDetail
                      join p in ctx.ProjectDetail
                      on m.ProjId equals p.ProjId
                      where m.UserId == Id
                      select new { ProjectId = p.ProjId, ProjectName = p.ProjName, RoleId = m.RoleId};
            foreach(var entry in res)
            {
                ProjectListItem itm = new ProjectListItem();
                itm.ProjectId = entry.ProjectId;
                itm.ProjectName = entry.ProjectName;
                itm.RoleId = entry.RoleId;
                model.itemlist.Add(itm);
            }

            SelectListItem[] proj = new SelectListItem[model.itemlist.Count];
            int j = 0;
            foreach (var i in model.itemlist)
            {
                proj[j] = new SelectListItem() { Text = i.ProjectName, Value = i.ProjectName };
                j++;
            }
            ViewBag.proj = proj;*/
            try
            {
                Session["ProjId"] = proj;
                return RedirectToAction("Tester", "Main");
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }

        public ActionResult Tester()
        {
            try
            {
                //For Tester
                DatabaseClass ctx = new DatabaseClass();
                //To view the data from database
                // add one model to view data
                var req = from i in ctx.BugPoolDetail select i;
                List<DataView> model = new List<DataView>();
                foreach (var i in req)
                {
                    DataView dv = new DataView();
                    dv.BugId = i.BugId;
                    dv.BugTitle = i.BugTitle;
                    dv.Priority = i.Priority;
                    dv.TesterId = i.TesterId;
                    dv.DeveloperId = i.DeveloperId;
                    dv.ProjectId = i.ProjectId;
                    dv.Status = i.Status;
                    dv.RaisedDate = i.RaisedDate;
                    model.Add(dv);
                    ctx.SaveChanges();
                }

                return View(model);
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }
        public ActionResult TesterAddBug()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TesterAddBug(DataView m)//(string BugTitle, string Priority, DateTime RaisedDate, string Comments)
        {
            try
            {
                //To fetch the data to database
                DatabaseClass ctx = new DatabaseClass();
                BugPoolDetails r = new BugPoolDetails();
                CommentDetails c = new CommentDetails();
                r.BugTitle = m.BugTitle;
                r.Priority = m.Priority;
                r.RaisedDate = DateTime.Now;
                r.Status = "OPEN";
                r.TesterId = int.Parse(Session["UserId"].ToString());
                r.ProjectId = int.Parse(Session["ProjId"].ToString());

                c.Comments = m.Comments;
                c.CommentDate = DateTime.Now;
                c.CommentedBy = int.Parse(Session["UserId"].ToString());

                c.Bug = r; //Navigation Prop

                ctx.BugPoolDetail.Add(r);
                ctx.CommentDetail.Add(c);

                ctx.SaveChanges();
                return RedirectToAction("Tester", "Main");
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }
        public ActionResult TesterClose(int bid)
        {
            try
            {
                Session["bid"] = bid;
                DatabaseClass ctx = new DatabaseClass();
                int Bid = int.Parse(Session["bid"].ToString());
                var req = (from i in ctx.BugPoolDetail where i.BugId == Bid select i).FirstOrDefault();
                req.Status = "CLOSED";
                ctx.SaveChanges();
                return Redirect("/Main/Tester?pid=" + req.ProjectId.ToString());
                //return RedirectToAction("Tester", "Main");
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }

        public ActionResult Manager()
        {
            try
            {
                DatabaseClass ctx = new DatabaseClass();
                //To view the data from database
                // add one model to view data
                var req = from i in ctx.BugPoolDetail select i;
                List<DataView> model = new List<DataView>();
                foreach (var i in req)
                {
                    DataView dv = new DataView();
                    dv.BugId = i.BugId;
                    dv.BugTitle = i.BugTitle;
                    dv.Priority = i.Priority;
                    dv.TesterId = i.TesterId;
                    dv.DeveloperId = i.DeveloperId;
                    dv.ProjectId = i.ProjectId;
                    dv.Status = i.Status;
                    dv.RaisedDate = i.RaisedDate;
                    model.Add(dv);
                    ctx.SaveChanges();
                }

                return View(model);
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }
        public ActionResult ManagerAssign(int bid)
        {
            try
            {
                Session["BugId"] = bid;
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }
        [HttpPost]
        public ActionResult ManagerAssign(DataView m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DatabaseClass ctx = new DatabaseClass();
                    CommentDetails c = new CommentDetails();
                    int bid = int.Parse(Session["BugId"].ToString());
                    var res = (from i in ctx.BugPoolDetail where i.BugId == bid select i).FirstOrDefault();

                    res.DeveloperId = m.at;
                    res.Status = "ASSIGNED";

                    int uid = int.Parse(Session["UserId"].ToString());
                    c.CommentedBy = uid;
                    c.Comments = m.atc;
                    c.BugId = bid;
                    c.CommentDate = DateTime.Now;
                    ctx.CommentDetail.Add(c);
                    ctx.SaveChanges();

                    return RedirectToAction("Manager", "Main");
                }
                return View(m);
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }

        public ActionResult Developer()
        {
            try
            {
                DatabaseClass ctx = new DatabaseClass();
                //To view the data from database
                // add one model to view data
                var req = from i in ctx.BugPoolDetail select i;
                List<DataView> model = new List<DataView>();
                foreach (var i in req)
                {
                    DataView dv = new DataView();
                    dv.BugId = i.BugId;
                    dv.BugTitle = i.BugTitle;
                    dv.Priority = i.Priority;
                    dv.TesterId = i.TesterId;
                    dv.DeveloperId = i.DeveloperId;
                    dv.ProjectId = i.ProjectId;
                    dv.Status = i.Status;
                    dv.RaisedDate = i.RaisedDate;
                    model.Add(dv);
                    ctx.SaveChanges();
                }

                return View(model);
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }
        public ActionResult DeveloperResolve(int bid)
        {
            try
            {
                Session["BugId"] = bid;
                return View();
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }
        [HttpPost]
        public ActionResult DeveloperResolve(DataView1 m)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DatabaseClass ctx = new DatabaseClass();
                    CommentDetails c = new CommentDetails();
                    int bid = int.Parse(Session["BugId"].ToString());
                    var res = (from i in ctx.BugPoolDetail where i.BugId == bid select i).FirstOrDefault();
                    res.Status = "RESOLVED";

                    int uid = int.Parse(Session["UserId"].ToString());
                    c.CommentedBy = uid;
                    c.Comments = m.dc;
                    c.BugId = bid;
                    c.CommentDate = DateTime.Now;
                    ctx.CommentDetail.Add(c);

                    ctx.SaveChanges();
                    return RedirectToAction("Developer", "Main");
                }
                return View(m);
            }
            catch
            {
                return RedirectToAction("Error", "Main");
            }
        }

        public ActionResult Comments(int bid)
        {

            DatabaseClass ctx = new DatabaseClass();
            //To view the data from database
            // add one model to view data
            ViewBag.PID = int.Parse(Session["ProjId"].ToString());
            ViewBag.RID = int.Parse(Session["RoleId"].ToString());
            var req = from i in ctx.CommentDetail where i.BugId == bid select i;
            List<HistoryModel> model = new List<HistoryModel>();
            foreach (var i in req)
            {
                HistoryModel dv = new HistoryModel();

                dv.BugId = i.BugId;
                dv.CommentId = i.CommentId;
                dv.CommentedBy = i.CommentedBy;
                dv.Comments = i.Comments;
                dv.CommentedDate = i.CommentDate;
                model.Add(dv);
                ctx.SaveChanges();
            }
            ViewBag.bugid = bid;
            return View(model);


        }
    }
}

