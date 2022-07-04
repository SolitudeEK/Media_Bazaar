using System;
using mediabazaar_s2_cb06_1.Department;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.TestMailBox
{
    [TestClass]
    public class TestDepartment
    {
        private Departement departement = new Departement("Phones", 15);

        [TestMethod]
        public void CorrectTestInfo()
        {
            string info = "Phones Workers:15";
            string output = departement.Info();
            Assert.AreEqual(output, info);
        }
    }
}
