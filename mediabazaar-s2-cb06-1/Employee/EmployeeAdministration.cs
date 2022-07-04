using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using mediabazaar_s2_cb06_1.AccountLogin;

namespace mediabazaar_s2_cb06_1.Employee
{
    class EmployeeAdministration
    {
        private static List<ExecutiveEmployee> executiveEmployees = new List<ExecutiveEmployee>();

        public EmployeeAdministration()
        {

        }

        public void AddExecutiveEmployee(ExecutiveEmployee ee)
        {
            executiveEmployees.Add(ee);
        }

        public void WriteToTextFile()
        {
            FileStream fs = null;
            StreamWriter sw = null;
            try
            {
                fs = new FileStream("EmployeeInformation.txt", FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);

                foreach(ExecutiveEmployee ee in executiveEmployees)
                {
                    sw.WriteLine(ee);
                }
                MessageBox.Show("Writing successful");
            }
            catch (IOException)
            {
                MessageBox.Show("Error writing file.");
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong.");
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }
    }
}
