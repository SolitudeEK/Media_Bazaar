using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using mediabazaar_s2_cb06_1.MailBox;

namespace mediabazaar_s2_cb06_1.Employee
{
    public class EmployeeManager
    {
        private static List<Worker> employees = new List<Worker>();
        public Worker GetPersonById(int id)
        {
            foreach (Worker employee in employees)
            {
                if (employee.GetId() == id)
                    return employee;
            }
            return null;
        }
        public void RemoveEmployee(Worker person)
        {
            employees.Remove(person);
        }
        public List<Worker> GetEmployees()
        {
            return employees;
        }
        public void AddEmployee(Worker newEmployee)
        {
                employees.Add(newEmployee);
            MailManager.SendMail(newEmployee.GetNamePos()+" is enrolled", "Executive", 3);
        }
        public int GetLastId()
        {
            return employees.Last().GetId();
        }
        public void InitEmployee()
        {
            employees = EmployeeManagerDB.InitEmployee();
        }
        public bool DBRemoveEmployee(Worker person)
        {
            return EmployeeManagerDB.RemoveEmployee(person);
        }
        public bool removeEmployeeFinally(string name)
        {
            int id = -1;
            foreach (Worker person in employees)
            {
                if (person.GetNamePos() == name)
                {
                    id = person.GetId();
                    employees.Remove(person);
                    break;
                }
            }
            return EmployeeManagerDB.RemoveFinnaly(id);
        }
        public bool DBAddEmployee(string fName, string sName, DateTime bDay, double wagePerHour, string position, string department, string phoneNumber, string email)
        {
            return EmployeeManagerDB.AddEmployee(fName, sName, bDay, wagePerHour, position, department, phoneNumber, email, this.GetLastId() + 1);
        }
        
        public bool DBChangeEmployee(int id, string fName, string sName, DateTime bDay, double wagePerHour, string position, string department, string phoneNumber, string email)
        {
            bool otp =EmployeeManagerDB.ChangeEmployee(id, fName, sName, bDay, wagePerHour, position, department, phoneNumber, email);
            double wageIsChanged = -1;
            foreach (Worker emp in employees)
            {
                if (emp.GetId() == id)
                {
                    wageIsChanged = emp.chngEmployeeData(fName, sName, bDay, wagePerHour, position, department, phoneNumber, email);
                    break;
                }
            }
            if (wageIsChanged != -1)
            {
                EmployeeManagerDB.AddWageHistory(id, wageIsChanged);
            }
            return otp;
        }
        public bool undoRemove(string name)
        {
            int id = -1;
            foreach (Worker person in employees)
            {
                if (person.GetNamePos() == name)
                {
                    id = person.GetId();
                    person.SetWorking(true);
                    break;
                }
            }
            return EmployeeManagerDB.UndoRemove(id);
        }
        public void Cleaning()
        {
            employees.Clear();
        }
    }
}

