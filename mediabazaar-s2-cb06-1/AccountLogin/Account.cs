using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mediabazaar_s2_cb06_1.Employee;

namespace mediabazaar_s2_cb06_1.AccountLogin
{
    class Account : Person
    {
        private string _username;
        private string _password;

        public Account(int id, string firstName, string lastName) : base(id, firstName, lastName)
        {
            _username = firstName + lastName;
            _password = firstName + lastName + 01;
        }

        public override string ToString()
        {
            return $"{base.Id},{_username},{_password}";
        }
    }
}
