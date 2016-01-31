using PostCodeDataAccess.Models.Clinic;
using PostCodeDataAccess.Models.General;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCodeDataAccess.DataAccess
{
    public class NHSClinicApiDataReader : IDataReader<NHSClinicList>
    {
        public async Task<NHSClinicList> GetDetailsAsync(string outCode)
        {
            var url = ConfigurationManager.AppSettings["NHSClinicApiUrl"];
            string partialPostCode = GetPartialPostCode(outCode);
            NHSClinicList postCodeResult = await JsonDownloader.DownloadSerializedJsonDataAsync<NHSClinicList>(url + partialPostCode);
            return postCodeResult;
        }
        /// <summary>
        /// //If the postcode is less than 5 characters, take the whole thing as the area code. If it is greater than 5 characters, remove the last 3 characters and take the remainder as the area code:
        /// </summary>
        /// <param name="postCode"></param>
        /// <returns></returns>
        private string GetPartialPostCode(string postCode)
        {
            string partialPostCode;
            postCode = postCode.Trim().Replace(" ", string.Empty);
            if (postCode.Length < 5)
            {
                partialPostCode = postCode;
            }
            else
            {
                partialPostCode = postCode.Substring(0, postCode.Length-3);
            }
            return partialPostCode;
        
        }
    }
}
