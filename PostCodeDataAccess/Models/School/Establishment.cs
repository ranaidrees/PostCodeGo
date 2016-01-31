using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCodeDataAccess.Models.School
{
    public class Establishment
    {
        public string establishment_name { get; set; }
        public string establishment_url { get; set; }
        public string establishment_type { get; set; }
        public string establishment_lat { get; set; }
        public string establishment_lng { get; set; }
        public string establishment_distance_from_target { get; set; }
        public string establishment_last_inspected { get; set; }
    }
}
