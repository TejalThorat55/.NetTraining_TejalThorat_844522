using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCIssueTrackerCode.Models
{
    public class ProjectModel
    {
        public List<ProjectListItem> itemlist = new List<ProjectListItem >();
    }


    public class ProjectListItem
    {
            public int RoleId { get; set; }
            public int ProjectId { get; set; }
            public string ProjectName { get; set; }
        
    }
}