using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IITS_Programming_Club.Models
{
    public class ClassSchedule
    {
        [Key]
        public int key { get; set; }
        [Required]
        public string group { get; set; }
        [Required]
        public string room_no { get; set; }
        [Required]
        public string time { get; set; }
        [Required]
        public string date { get; set; }
        public bool isDone { get; set; }
        public string change_plan { get; set; }
        public string remarks { get; set; }

    }
}
