using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp1;

namespace UnitTestProject1
{
    [TestClass]
    public class LightsUnitTests
    {
        [TestMethod]
        public void WinTest_AllLightsAreOff_ReturnsTrue()
        {
            var Instance = new Lights();


            foreach(Lights.Light l in Lights.lights)
            {

                l.ON = false;
            }


           var result = Lights.CheckWin();

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void WinTest_SomeLightsAreOn_ReturnsFalse()
        {
            var Instance = new Lights();                 //At least one ligth will be on be default o no need to alter anything

           
            var result = Lights.CheckWin();

            Assert.IsFalse(result);

        }
    }
}
