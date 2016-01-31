using PostCodeDataAccess.DataAccess;
using PostCodeDataAccess.Models.School;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostCodeDataAccess.DataAccess
{
    public class SchoolApiDataReader: IDataReader<SchoolAndNurseryList>
    {
        public async Task<SchoolAndNurseryList> GetDetailsAsync(string outCode)
            {
                var url = ConfigurationManager.AppSettings["SchoolApiUrl"];
                var range = ConfigurationManager.AppSettings["SchoolApiAreaRange"];
                SchoolAndNurseryList postCodeResult = await JsonDownloader.DownloadSerializedJsonDataAsync<SchoolAndNurseryList>(url + outCode + "&range=" + range);
                return postCodeResult;
            }
    }
}
