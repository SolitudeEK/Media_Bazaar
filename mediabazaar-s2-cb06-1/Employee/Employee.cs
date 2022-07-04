using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mediabazaar_s2_cb06_1.AccountLogin;

namespace mediabazaar_s2_cb06_1.Employee
{
    class ExecutiveEmployee : Person
    {
        private int _adminLevel = 1;

        public ExecutiveEmployee(int id, string name, DateTime startDate, DateTime dateOfBirth, double salary) : base(id, name, startDate, dateOfBirth, salary)
        {
            _adminLevel = 1;
        }

        public override string ToString()
        {
            return base.ToString() + $",{_adminLevel}";
        }
    }
}
