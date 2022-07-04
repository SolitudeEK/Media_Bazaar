using System;
using mediabazaar_s2_cb06_1.Employee;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.TestEmployee
{
    [TestClass]
    public class TestWorker
    {
        static DateTime startDate = DateTime.Now;
        static DateTime dob = DateTime.Now;
        private Worker w = new Worker("Peter", "Watson", startDate, dob, 10, "HR", "HR", "999999999", "email@gmail.com", true, 011111112);

        [TestMethod]
        public void CorrectTestChangeEmployeeData()
        {
            double output = w.chngEmployeeData("Peter", "Watson", dob, 12, "HR", "HR", "999999999","email@gmail.com");
            Assert.AreEqual(output, 10);
        }

        [TestMethod]
        public void TestChangeEmployeeData_NotChanging()
        {
            double output = w.chngEmployeeData("Peter", "Watson", dob, 10, "HR", "HR", "999999999", "email@gmail.com");
            Assert.AreEqual(output, -1);
        }

        [TestMethod]
        public void CorrectTestIsWorking()
        {
            bool output = w.IsWorking();
            Assert.AreEqual(output, true);
        }

        [TestMethod]
        public void WrongTestIsWorking()
        {
            w.SetWorking(false);
            bool output = w.IsWorking();
            Assert.AreNotEqual(output, true);
        }

        [TestMethod]
        public void CorrectTestGetDepartment()
        {
            string dep = w.GetDepartment();
            Assert.AreEqual(dep, "HR");
        }
    }
}
