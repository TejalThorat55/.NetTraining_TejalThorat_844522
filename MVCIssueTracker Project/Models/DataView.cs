using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCIssueTrackerCode.Models
{
    public class DataView
    {
        
        public int BugId { get; set; }
        
        public string BugTitle { get; set; }
       
        public string Priority { get; set; }
      
        public int TesterId { get; set; }
       
        public int DeveloperId { get; set; }
        
        public int ProjectId { get; set; }
       
        public DateTime RaisedDate { get; set; }
       
        public string Status { get; set; }

        public string Comments { get; set; }

        [Required]
        public int at { get; set; }
        [Required]
        public string atc { get; set; }
    }
}