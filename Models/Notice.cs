using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IITS_Programming_Club.Models
{
    public class Notice
    {
        [Key]
        [Required]
        public string notice_id { get; set; }
        [Required]
        public string date { get; set; }
        [Required]
        public string notice { get; set; }
    }
}
