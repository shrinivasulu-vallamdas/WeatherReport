using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherReport.Business.Interface
{
   public interface IBuilder
    {
        string[] GetSource();
        bool UploadFile(Byte[] memoryStream, string fileName);
        Task<Byte[]> CallService(HttpClient client, string CountryId);
    }
}
