using PostCodeDataAccess.Models.Clinic;
using PostCodeDataAccess.Models.General;
using PostCodeDataAccess.Models.School;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostCodeDataAccess.Models
{
    public class PostCodeDetails
    {
        public GeneralDetails GeneralDetails { get; set; }
        public SchoolAndNurseryList SchoolAndNurseryList { get; set; }
        public NHSClinicList NHSClinicList { get; set; }
    }
}