using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PostCodeDataAccess.Models;
using PostCodeDataAccess.Models.General;
using System.Configuration;

namespace PostCodeDataAccess.DataAccess
{
    public class GeneralApiDataReader : IDataReader<GeneralDetails>
    {
        public async Task<GeneralDetails> GetDetailsAsync(string outCode)
        {
            var url = ConfigurationManager.AppSettings["PostCodeBasicInfoUrl"];
            GeneralDetails postCodeResult = await JsonDownloader.DownloadSerializedJsonDataAsync<GeneralDetails>(url + outCode);
            return postCodeResult;
        }
    }

   
}
