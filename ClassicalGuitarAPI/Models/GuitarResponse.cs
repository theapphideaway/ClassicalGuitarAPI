using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassicalGuitarAPI.Models
{
    public class GuitarResponse
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public List<Guitar> Guitars { get; set; }
     }
}
