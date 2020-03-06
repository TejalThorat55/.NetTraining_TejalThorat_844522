using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCIssueTrackerCode.Models
{
    public class HistoryModel
    {
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public int BugId { get; set; }
        public int CommentedBy { get; set; }
        public string Comments { get; set; }
        public DateTime CommentedDate { get; set; }
    }
}