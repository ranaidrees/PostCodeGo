using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostCodeDataAccess.Models.Clinic
{
    public class NHSClinicDetails
    {
        public string website { get; set; }
        public string sub_type { get; set; }
        public string postcode { get; set; }
        public string phone { get; set; }
        public string partial_postcode { get; set; }
        public string organisation_type { get; set; }
        public string organisation_status { get; set; }
        public string organisation_name { get; set; }
        public string organisation_id { get; set; }
        public string organisation_code { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string is_pims_managed { get; set; }
        public string fax { get; set; }
        public string email { get; set; }
        public string county { get; set; }
        public string city { get; set; }
        public string address3 { get; set; }
        public string address2 { get; set; }
        public string address1 { get; set; }
    }
}