using System;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WetherReport.Controllers;

namespace WeatherReport.Tests.Controllers
{
    [TestClass]
    public class WeatherReportControllerTest
    {
        [TestMethod]
        public void GenerateWeatherReport()
        {
            // Arrange
            WeatherReportController controller = new WeatherReportController();
            var result = controller.GenerateWeatherReport();
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result);

        }
    }
}
