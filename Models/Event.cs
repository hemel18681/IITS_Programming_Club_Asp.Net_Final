using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IITS_Programming_Club.Models
{
    public class Event
    {
        [Key]
        [Required]
        public string event_id { get; set; }
        [Required]
        public string event_name { get; set; }
        [Required]
        public string event_link { get; set; }
        [Required]
        public string event_for { get; set; }
        [Required]
        public string date { get; set; }
        public string winner { get; set; }
    }
}
