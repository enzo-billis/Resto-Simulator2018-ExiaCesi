using System;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestaurantSimulator.Controller;

namespace RestoTests.Controller
{
    [TestClass]
    public class TestParametersController
    {
        [TestMethod]
        public void TestGetValueOrDefault()
        {
            var value = ConfigurationManager.AppSettings["speed"];
            Assert.IsNotNull(value); 

            string result = ParametersController.GetValueOrDefault("test", "TestValue");
            Assert.AreEqual("TestValue", result);

            result = ParametersController.GetValueOrDefault("speed", "10");
            Assert.AreEqual("1", result);

            result = ParametersController.GetValueOrDefault("MAP_NUMBER", "16", numericalValue: true);
            var numericalResult = Int32.Parse(result);
            Assert.AreEqual(40, numericalResult);

            result = ParametersController.GetValueOrDefault("SALLE_CLIENT_LOCAL_IP", "10", true);
            Assert.AreEqual("10", result);
        }
    }
}
