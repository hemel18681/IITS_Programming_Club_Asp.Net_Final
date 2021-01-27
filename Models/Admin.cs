using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IITS_Programming_Club.Models
{
    public class Admin
    {
        public string admin_name { get; set; }
        [Key]
        [Required]
        public string admin_id { get; set; }
        [Required]
        public string admin_pass { get; set; }
        public string admin_phone { get; set; }
        public string admin_mail { get; set; }
        public string admin_address { get; set; }
        public string active_status { get; set; }
    }
}
