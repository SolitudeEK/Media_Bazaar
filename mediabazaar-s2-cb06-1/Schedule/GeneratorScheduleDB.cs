using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mediabazaar_s2_cb06_1.Schedule
{
    class GeneratorScheduleDB
    {
        private static string connStr = ConnectionString.GetConStr();
        public static int CheckPpl(string department) //return number of people in selected department
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "SELECT COUNT(*) FROM `employee` WHERE department=@department";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@department", department);
                    conn.Open();
                    int result= Convert.ToInt32(cmd.ExecuteScalar());
                    return result;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        public static int[] GetIds(string department, int num) //return id of people in selected departament
        {
            int[] ids = new int[num];
            int i = 0;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "SELECT id FROM `employee` WHERE department = @department ORDER BY RAND() LIMIT "+num;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@department", department);
                    conn.Open();
                    MySqlDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        ids[i] = Convert.ToInt32(result[0]);
                        i++;
                    }
                    return ids;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Dictionary<int, WorkDay[]> GetWanteds(int[] ids)  // return preferences of people
        {
            Dictionary<int, WorkDay[]> otp = new Dictionary<int, WorkDay[]>();
            WorkDay[] wd = new WorkDay[5];
            try
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    using (MySqlConnection conn = new MySqlConnection(connStr))
                    {

                        string sql = "SELECT `id`, `d0`, `d1`, `d2`, `d3`, `d4` FROM `wnated_shifts` WHERE id=@id";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", ids[i]);
                        conn.Open();
                        MySqlDataReader result = cmd.ExecuteReader();
                        while (result.Read())
                        {
                            wd[0] = new WorkDay(result[1].ToString(), "0 0");
                            wd[1] = new WorkDay(result[2].ToString(), "0 0");
                            wd[2] = new WorkDay(result[3].ToString(), "0 0");
                            wd[3] = new WorkDay(result[4].ToString(), "0 0");
                            wd[4] = new WorkDay(result[5].ToString(), "0 0");
                            otp.Add(Convert.ToInt32(result[0]), wd);
                        }                        
                    }
                }
                return otp;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex+"");
                return null;
            }
        }
    }
}
