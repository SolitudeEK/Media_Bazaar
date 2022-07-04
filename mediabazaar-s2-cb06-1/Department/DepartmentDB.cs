using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using mediabazaar_s2_cb06_1.Schedule;
namespace mediabazaar_s2_cb06_1.Department
{
    static class DepartmentDB
    {
        private static string connStr = ConnectionString.GetConStr();
        public static bool AddDepartment(string inp)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "INSERT INTO `departments`(`department`) VALUES (@dep)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@dep", inp);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public static List<WorkWeek> GetDepartmentInfo(string dep)
        {
            try
            {

                List<int> arr = new List<int>();
                List<WorkWeek> otp = new List<WorkWeek>();
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "SELECT id FROM employee WHERE department=@dep";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@dep", dep);
                    conn.Open();
                    MySqlDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                        arr.Add(Convert.ToInt32(result[0]));
                }
                foreach (int id in arr)
                {
                    otp.Add(new WorkWeek(id));
                }
                return otp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static bool RemoveDepartment(string inp)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "DELETE FROM `departments` WHERE department=@dep";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@dep", inp);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static List<Departement> InitDepartmets()
        {
            List<Departement> departments = new List<Departement>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "SELECT department,COUNT(*) FROM `employee` as E WHERE EXISTS(SELECT 1 FROM departments as d WHERE E.department=D.department) GROUP BY department";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    MySqlDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                        departments.Add(new Departement(result[0].ToString(), Convert.ToInt32(result[1])));
                }

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "SELECT department FROM `departments` as D WHERE NOT EXISTS(SELECT 1 FROM employee as E WHERE E.department=D.department)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    MySqlDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                        departments.Add(new Departement(result[0].ToString(), 0));
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex+"");
                return null;
            }
            return departments;
        }
    }
}
