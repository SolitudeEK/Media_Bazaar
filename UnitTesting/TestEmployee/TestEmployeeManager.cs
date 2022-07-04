using System;
using mediabazaar_s2_cb06_1.Employee;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.TestEmployee
{
    [TestClass]
    public class TestEmployeeManager
    {
        static DateTime startDate = DateTime.Now;
        static DateTime dob = DateTime.Now;
        private Worker w1 = new Worker("Peter", "Watson", startDate, dob, 10, "HR", "HR", "999999999", "email@gmail.com", true, 011111111);
        private Worker w2 = new Worker("Jhon", "Hammer", startDate, dob, 15, "Stock", "Stock", "888888888", "email@gmail.com", true, 011111112);
        private EmployeeManager employeeManager = new EmployeeManager();

        private void AddEmployees()
        {
            employeeManager.AddEmployee(w1);
            employeeManager.AddEmployee(w2);
        }

        [TestMethod]
        public void CorrectGetPersonById()
        {
            AddEmployees();
            Worker worker = employeeManager.GetPersonById(w1.Id);
            Assert.AreEqual(w1.FirstName, worker.FirstName);
            Assert.AreEqual(w1.LastName, worker.LastName);
            Assert.AreEqual(w1.StartDate, worker.StartDate);
            Assert.AreEqual(w1.DateOfBirth, worker.DateOfBirth);
            Assert.AreEqual(w1.WagePerHour, worker.WagePerHour);
            Assert.AreEqual(w1.AccessRights, worker.AccessRights);
            Assert.AreEqual(w1.Department, worker.Department);
            Assert.AreEqual(w1.Phone, worker.Phone);
            Assert.AreEqual(w1.Email, worker.Email);
            Assert.AreEqual(w1.IsWorking(), worker.IsWorking());
            Assert.AreEqual(w1.Id, worker.Id);
        }

        [TestMethod]
        public void GetNonExistentPersonById()
        {
            AddEmployees();
            Worker worker = employeeManager.GetPersonById(011111113);
            Assert.AreEqual(null, worker);
        }

        [TestMethod]
        public void WrongTestGetPersonById()
        {
            AddEmployees();
            employeeManager.RemoveEmployee(w1);
            Worker worker = employeeManager.GetPersonById(w1.Id);
            Assert.AreNotEqual(w1, worker);
        }
    }
}
