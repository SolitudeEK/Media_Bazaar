using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using mediabazaar_s2_cb06_1.Schedule;

namespace mediabazaar_s2_cb06_1.Department
{
    class DepartmentManager
    {
        private static List<Departement> departments = new List<Departement>();
        public void InitDepartments()
        {
            departments = DepartmentDB.InitDepartmets();
        }

        public List<Departement> GetDepartments()
        {
            return departments;
        }
        public bool RemoveDepartment(string inp)
        {
            foreach (Departement dep in departments)
            {
                if (dep.name == inp)
                {
                    departments.Remove(dep);
                    return DepartmentDB.RemoveDepartment(inp);
                }
            }
            return false;
        }
        public bool AddDepartment(string inp)
        {
            departments.Add(new Departement(inp, 0));
            return DepartmentDB.AddDepartment(inp);
        }
        public void Cleaning()
        {
            departments.Clear();
        }

        public static List<WorkWeek> GetDepartmentInfo(string dep)
        {
            return DepartmentDB.GetDepartmentInfo(dep);
        }

    }
}
