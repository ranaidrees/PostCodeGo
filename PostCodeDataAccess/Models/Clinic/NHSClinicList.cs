using PostCodeDataAccess.Models.Clinic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCodeDataAccess.Models.Clinic
{
    public class NHSClinicList
    {
        public bool success { get; set; }
        public IList<NHSClinicDetails> result { get; set; }
    }
}
