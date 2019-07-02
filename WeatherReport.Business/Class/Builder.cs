using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WeatherReport.Business.Interface;

namespace WeatherReport.Business.Class
{
    public class Builder : IBuilder
    {
        public static string serviceName = "http://api.openweathermap.org/";
        public string[] GetSource()
        {
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/inputFile.txt"));
            string[] files = File.ReadAllLines(path);
            return files;
        }

        public bool UploadFile(Byte[] memoryStream,string fileName)
        {
            try
            {
                DateTime now = DateTime.Today;
                string filePath = Path.Combine(HttpContext.Current.Server.MapPath(string.Format("~/{0}/{1}/{2}", now.Year, now.Month, now.Day)));
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                File.WriteAllBytes(filePath + string.Format("/{0}.json", fileName), memoryStream);
                return true;
            }
            catch (Exception ex) {

                return false;
            }
        }

        public async Task<Byte[]> CallService(HttpClient client,string CountryId)
        {
            string url = string.Format("data/2.5/weather?id={0}&APPID=aa69195559bd4f88d79f9aadeb77a8f6", CountryId);
            return await client.GetByteArrayAsync(url);
        }



    }
}
