using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace mediabazaar_s2_cb06_1.Employee
{
    public class Worker : Person
    {
        private string _accessRights;
        public string AccessRights { get { return _accessRights; } }

        private string _department;
        public string Department { get { return _department; } }

        private string _phone;
        public string Phone { get { return _phone; } }

        private string _email;
        public string Email { get { return _email; } }

        private bool _isWorking;
        private Image picture=null;
        public Worker(string firstName, string lastName, DateTime startDate, DateTime dateOfBirth, double wagePerHour, string accessRights, string department, string phone, string email) : base(firstName, lastName, startDate, dateOfBirth, wagePerHour)
        {
            _accessRights = accessRights;
            _department = department;
            _email = email;
            _phone = phone;
            _isWorking = true;
        }
        public Worker(string firstName, string lastName, DateTime startDate, DateTime dateOfBirth, double wagePerHour, string accessRights, string department, string phone, string email, bool isWorking, int id) : base(firstName, lastName, startDate, dateOfBirth, wagePerHour, id)
        {
            _accessRights = accessRights;
            _department = department;
            _email = email;
            _phone = phone;
            _isWorking = isWorking;
        }
        public override string ToCard()
        {
            return base.ToCard() + $"\n{_department}\n {_accessRights}";
        }
        public override List<string> GetInfo()
        {
            List<string> otp = base.GetInfo();
            otp.Add(_email);
            otp.Add(_phone);
            otp.Add(_department);
            otp.Add(_accessRights);
            return otp;
        }
        public double chngEmployeeData(string firstName, string lastName, DateTime dateOfBirth, double wagePerHour, string accessRights, string department, string phone, string email)
        {
            _accessRights = accessRights;
            _department = department;
            _email = email;
            _phone = phone;
            return base.chngEmployeeData(firstName, lastName, dateOfBirth, wagePerHour);
        }
        public override string GetNamePos()
        {
            return _accessRights + base.GetNamePos();
        }
        public bool IsWorking()
        {
            return _isWorking;
        }
        public override string GetDepartment()
        {
            return _department;
        }
        public void AddImage(Image img)
        {
            picture = img;
        }
        public override Image GetImage()
        {
            return picture;
        }
        public void SetWorking(bool inp)
        {
            _isWorking = inp;
        }
    }
}
