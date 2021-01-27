using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace IITS_Programming_Club.Models
{
    public class StudentInfo
    {
        public string student_name { get; set; }
        [Key]
        [Required]
        public string student_id { get; set; }
        [Required]
        public string student_pass { get; set; }
        [Required]
        public string student_division { get; set; }
        [Required]
        public string student_status { get; set; }
        public string codeforces_handle { get; set; }
        public string codechef_handle { get; set; }
        public string vjudge_handle { get; set; }
        public string atcoder_handle { get; set; }
        public string hackerrank_handle { get; set; }
        public string active_status { get; set; }
        public string block_reason { get; set; }

    }
}
