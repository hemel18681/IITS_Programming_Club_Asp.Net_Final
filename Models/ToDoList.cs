using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IITS_Programming_Club.Models
{
    public class ToDoList
    {
        public int id { get; set; }
        [Required]
        public string problem_link { get; set; }
        public bool isdone { get; set; }
        [Required]
        public string student_id { get; set; }
    }
}
