using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
namespace mediabazaar_s2_cb06_1.Employee
{
    public static class EmployeeManagerDB
    {
        private static string connStr = ConnectionString.GetConStr();
        public static Image GetImage(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "SELECT image FROM account_images where id=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    if (cmd.ExecuteScalar() != null)
                    {
                        string resultImage = cmd.ExecuteScalar().ToString();
                        byte[] data = Convert.FromBase64String(resultImage);
                        using (MemoryStream ms = new MemoryStream(data))
                        {
                            Image image = Bitmap.FromStream(ms);
                            return image;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex + "");
            }
            return null;
        }
        public static List<Worker> InitEmployee()
        {
            List<Worker> employees = new List<Worker>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "SELECT  firstName, secondName, startDate, dateOfBirth, wagePerHour, role, department, phoneNumber, email, working,id FROM employee";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    MySqlDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        employees.Add(new Worker(result[0].ToString(), result[1].ToString(), Convert.ToDateTime(result[2]), Convert.ToDateTime(result[3]), Convert.ToDouble(result[4]), result[5].ToString(), result[6].ToString(), result[7].ToString(), result[8].ToString(), Convert.ToBoolean(result[9]), Convert.ToInt32(result[10])));
                    }
                }
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MySqlCommand cmd;
                    foreach (Worker worker in employees)
                    {
                        if (worker.IsWorking())
                        {
                            string sql = "SELECT image FROM account_images where id=@id";

                            cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@id", worker.GetId());
                            if (cmd.ExecuteScalar() != null)
                            {
                                string resultImage = cmd.ExecuteScalar().ToString();
                                byte[] data = Convert.FromBase64String(resultImage);
                                using (MemoryStream ms = new MemoryStream(data))
                                {
                                    Image image = Bitmap.FromStream(ms);
                                    worker.AddImage(image);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex + "");
                return null;
            }
            return employees;
        }
        public static bool RemoveEmployee(Worker person)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {

                    string sql = "UPDATE `employee` SET `working`=false WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", person.GetId());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    person.SetWorking(false);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public static bool RemoveFinnaly(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {

                    string sql = "DELETE FROM `employee` WHERE id=@id; DELETE FROM `account_images` WHERE id=@id; DELETE FROM `account` WHERE id_employee=@id; DELETE FROM `shifts` WHERE id=@id; DELETE FROM `wage_history` WHERE id_employee=@id ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
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

        public static bool AddEmployee(string fName, string sName, DateTime bDay, double wagePerHour, string position, string department, string phoneNumber, string email, int id)
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "INSERT INTO `employee`(id, role, firstName, secondName, department, dateOfBirth, wagePerHour, startDate, email,phoneNumber) VALUES(@id, @role, @firstName, @secondName, @department, @dateOfBirth, @wagePerHour, @startDate, @email,@phoneNumber)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@role", position);
                    cmd.Parameters.AddWithValue("@firstName", fName);
                    cmd.Parameters.AddWithValue("@secondName", sName);
                    cmd.Parameters.AddWithValue("@department", department);
                    cmd.Parameters.AddWithValue("@dateOfBirth", bDay);
                    cmd.Parameters.AddWithValue("@startDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@wagePerHour", wagePerHour);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    sql = "INSERT INTO `account`(`id_employee`, `username`, `password`) VALUES (@id, @login,@password)";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@login", email);
                    cmd.Parameters.AddWithValue("@password", Encrypt(fName + fName.Length));
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        private static string Encrypt(string inp)
        {
            StringBuilder sBuilder = new StringBuilder();
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(inp));

                for (int i = 0; i < (data.Length); i++)
                    sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public static bool ChangeEmployee(int id, string fName, string sName, DateTime bDay, double wagePerHour, string position, string department, string phoneNumber, string email)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {

                    string sql = "UPDATE employee SET role=@role, firstName=@firstName, secondName=@secondName, department=@department, dateOfBirth=@dateOfBirth, wagePerHour=@wagePerHour, email=@email,phoneNumber=@phoneNumber WHERE id=@id; ";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@role", position);
                    cmd.Parameters.AddWithValue("@firstName", fName);
                    cmd.Parameters.AddWithValue("@secondName", sName);
                    cmd.Parameters.AddWithValue("@department", department);
                    cmd.Parameters.AddWithValue("@dateOfBirth", bDay);
                    cmd.Parameters.AddWithValue("@wagePerHour", wagePerHour);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    sql = "UPDATE account SET username=@login WHERE id_employee=@id";
                    cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@login", email);
                    //cmd.Parameters.AddWithValue("@password", Encrypt(fName + id.ToString()));
                    cmd.ExecuteNonQuery();                    
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex + "");
                return false;
            }

            return true;
        }
        public static void AddWageHistory(int id, double wageIsChanged)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "INSERT INTO `wage_history`(`id_employee`, `oldWage`, `change_time`) VALUES (@id, @oldWage, @currTime)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@oldWage", wageIsChanged);
                    cmd.Parameters.AddWithValue("@currTime", DateTime.Now);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
            }
        } 
        public static bool UndoRemove(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {

                    string sql = "UPDATE `employee` SET `working`=true WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
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
    }
}
