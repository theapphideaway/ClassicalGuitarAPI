using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassicalGuitarAPI.Models
{
    public class Guitar
    {
        public int id { get; set; }
        public string guitar_name { get; set; }
        public string guitar_description { get; set; }
        public string body_type { get; set; }
        public string back_and_sides { get; set; }
        public string guitar_image { get; set; }
        public string guitar_top { get; set; }
    }
}
