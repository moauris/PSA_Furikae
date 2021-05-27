using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSA_Furikae.Models;
using PSA_Furikae.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSA_Furikae.Services.Tests
{
    [TestClass()]
    public class ServiceItemExtensionsTests
    {
        [TestMethod()]
        public void ToJsonTest()
        {
            ServiceItem item = new ServiceItem(
                "6j0NS0o222U0",
                12, "O222U0",
                "6J0NS0"
                );

            double[] interlockData =
            {
                0.010, 0.010, 0.010,
                0,0,0,
                0,0,0,
                0,0,0
            };
            item.MonthInterlock = interlockData;

            Console.WriteLine(item.ToJson());


            Assert.IsTrue(true);
        }
    }
}