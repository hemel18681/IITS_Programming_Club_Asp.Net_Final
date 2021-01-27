using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IITS_Programming_Club.Models
{
    public class Complain
    {
        [Key]
        public string student_id { get; set; }
        [Required]
        public string message { get; set; }
    }
}
