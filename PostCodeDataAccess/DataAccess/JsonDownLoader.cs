using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Linq;
using System.Web.Script.Serialization;
using System.Xml;

namespace PostCodeDataAccess.DataAccess
{
    public static class JsonDownloader
    {
        public static async Task<T> DownloadSerializedJsonDataAsync<T>(string url) where T : new()
        {
            using (var httpClient = new HttpClient())
            {
               
                string data;
                try
                {
                    data = await httpClient.GetStringAsync(url);
                    if (!IsJson(data))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.LoadXml(data);
                        data = JsonConvert.SerializeXmlNode(doc);
                    }
                }
                catch (Exception)
                {
                    return default(T);
                }
                return !string.IsNullOrEmpty(data) ? JsonConvert.DeserializeObject<T>(data) : default(T);
            }
        }
        /// <summary>
        /// Check if the input is Json format or seomthing else.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static bool IsJson(string input)
        {
            input = input.Trim();
            return input.StartsWith("{") && input.EndsWith("}")
                   || input.StartsWith("[") && input.EndsWith("]");
        }
    }
}
