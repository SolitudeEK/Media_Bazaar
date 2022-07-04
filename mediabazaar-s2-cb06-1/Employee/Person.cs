using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mediabazaar_s2_cb06_1.AccountLogin;
using System.Drawing;
namespace mediabazaar_s2_cb06_1.Employee
{
    public abstract class Person
    {
        private static int idSeeder = 0;
        private int _id;
        public int Id { get { return _id; } }

        private string _firstName;
        public string FirstName { get { return _firstName; } }

        private string _lastName;
        public string LastName { get { return _lastName; } }

        private DateTime _startDate;
        public DateTime StartDate { get { return _startDate; } }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth { get { return _dateOfBirth; } }

        private double _wagePerHour;
        public double WagePerHour { get { return _wagePerHour; } }

        public Person(string firstName, string lastName, DateTime startDate, DateTime dateOfBirth, double wagePerHour)
        {
            _id = idSeeder;
            Person.idSeeder++;
            _firstName = firstName;
            _lastName = lastName;
            _startDate = startDate;
            _dateOfBirth = dateOfBirth;
            _wagePerHour = wagePerHour;
        }

        public Person(int id, string firstName, string lastName)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
        }
        public Person(string firstName, string lastName, DateTime startDate, DateTime dateOfBirth, double wagePerHour, int id)
        {
            idSeeder=id;
            Person.idSeeder++;
            _firstName = firstName;
            _lastName = lastName;
            _startDate = startDate;
            _dateOfBirth = dateOfBirth;
            _wagePerHour = wagePerHour;
            _id = id;
        }
        public override string ToString()
        {
            return $"{Id},{_firstName} {_lastName},{_startDate.ToString("MM/dd/yyyy")},{_dateOfBirth.ToString("MM/dd/yyyy")},{_wagePerHour}";
        }
        public virtual string ToCard()
        {
            return $"{_firstName} {_lastName}";
        }
        public virtual string GetNamePos()
        {
            return $" {_firstName} {_lastName}";
        }
        public int GetId()
        {
            return _id;
        }
        public virtual List<string> GetInfo()
        {
            List<string> otp = new List<string>();
            otp.Add($"{_firstName} {_lastName}");
            otp.Add(_dateOfBirth.ToString("MM/dd/yyyy"));
            otp.Add(_wagePerHour.ToString());
            return otp;
        }
        public virtual double chngEmployeeData(string firstName, string lastName, DateTime dateOfBirth, double wagePerHour)
        {
            double check = IsWageChanged(wagePerHour, _wagePerHour);

            _firstName = firstName;
            _lastName = lastName;
            _dateOfBirth = dateOfBirth;
            _wagePerHour = wagePerHour;
            return check;
        }
        public virtual string GetDepartment() { return "none"; }
        public virtual Image GetImage() { return null; }
        private double IsWageChanged(double newWage, double oldWage)
        {
            if (newWage != oldWage) return oldWage;
            return -1;
        }
    }

}
