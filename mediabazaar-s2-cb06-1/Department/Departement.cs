using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediabazaar_s2_cb06_1.Department
{
    public class Departement
    { 
        public string name { private set; get; }
        private int numberEmployee;

        public Departement(string name, int quantity)
        {
            this.name = name;
            numberEmployee = quantity;
        }
        public string Info()
        {
            return name + " Workers:" + numberEmployee;
        }
    }
}
