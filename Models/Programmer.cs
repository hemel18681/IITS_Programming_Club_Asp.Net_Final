using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IITS_Programming_Club.Models
{
    public class Programmer
    {
        [Key]
        public int key { get; set; }
        [Required]
        public string week { get; set; }
        [Required]
        public string id { get; set; }
        public bool isDone { get; set; }
    }
}
