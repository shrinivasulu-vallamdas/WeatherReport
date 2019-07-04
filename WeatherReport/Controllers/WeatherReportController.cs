using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Xml.Linq;
using WeatherReport.Business.Class;
using WeatherReport.Business.Interface;

namespace WetherReport.Controllers
{
    /// <summary>
    /// Weather Report
    /// </summary>
    /// 
    [RoutePrefix("api/WeatherReport")]
    public class WeatherReportController : ApiController
    {
        IBuilder _builder;
        /// <summary>
        /// Generate weather report
        /// </summary>
        /// <returns></returns>
        ///
        //public WeatherReportController()
        //{

        //}
        public WeatherReportController(IBuilder builder)
        {
            // Once Dependency Resolver issues Fixed we can pass Interface
            _builder = builder;

        }
        [HttpGet]
        [Route("GenerateWeatherReport/")]
        public async Task<HttpResponseMessage> GenerateWeatherReport()
        {
            
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://api.openweathermap.org/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Getting Source file 
                    string[] files = _builder.GetSource();

                    foreach (string item in files)
                    {
                        string[] textvalue = item.Split('=');
                        // Call weather API
                        Byte[] memoryStream = await _builder.CallService(client, textvalue[0]);

                        // Upload file in the Destination
                        _builder.UploadFile(memoryStream, textvalue[1]);
                    }
                }
                catch (Exception ex) {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex.Message);
                }
                return Request.CreateErrorResponse(HttpStatusCode.OK,"Successfully created");
            }
        }
    }
}
