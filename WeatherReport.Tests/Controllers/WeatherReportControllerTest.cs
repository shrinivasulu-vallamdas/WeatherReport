using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherReport.Business.Class;
using WeatherReport.Business.Interface;
using WetherReport.Controllers;

namespace WeatherReport.Tests.Controllers
{
    [TestClass]
    public class WeatherReportControllerTest
    {
        [TestMethod]
        public void GenerateWeatherReport()
        {
            IBuilder _builder=new Builder();
            // Arrange
            WeatherReportController controller = new WeatherReportController(_builder);
            var result = controller.GenerateWeatherReport();
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result);

        }
    }
}
