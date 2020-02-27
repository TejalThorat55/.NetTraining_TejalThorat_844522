using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCodeTRMProject.Models
{
    public class DataView
    {
        public int RequestId { get; set; }
        public string RequestName { get; set; }
        public string Skill { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public int ExecId { get; set; }
        public int TrainerId { get; set; }
    }
}