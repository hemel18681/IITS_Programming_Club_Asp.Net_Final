using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace IITS_Programming_Club.Models
{
    public class Home
    {
        [Key]
        public int key { get; set; }
        public string student_id { get; set; }
        public string student_name { get; set; }
        public string codeforces_handle { get; set; }
        public string class_advance { get; set; }
        public string class_intermediate { get; set; }
        public string class_beginner { get; set; }
        public string room_advance { get; set; }
        public string room_intermediate { get; set; }
        public string room_begineer { get; set; }
        public string time_advance { get; set; }
        public string time_intermediate { get; set; }
        public string time_begineer { get; set; }
        public string date_advance { get; set; }
        public string date_intermediate { get; set; }
        public string date_begineer { get; set; }
        public string change_plan_advance { get; set; }
        public string change_plan_intermediate { get; set; }
        public string change_plan_begineer { get; set; }
    }
}
