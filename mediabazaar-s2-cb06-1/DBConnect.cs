using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using mediabazaar_s2_cb06_1.Employee;
using System.Security.Cryptography;
namespace mediabazaar_s2_cb06_1
{
    class DBConnect
    {
        private MySqlConnection con;

        public DBConnect()
        {
            Initialize();
        }

        private void Initialize()
        {
            string connectionString = ConnectionString.GetConStr();
            con = new MySqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            try
            {
                con.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.");
                        break;
                    case 1045:
                        MessageBox.Show("Inavlid Usernname/password, please try again.");
                        break;
                }
                return false;
            }
        }

        public bool CloseConnection()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public int Login(string username, string password)
        {
            using (con)
            {
                if (OpenConnection())
                {
                    string query = "select id_employee from account WHERE username =@username AND password =@password";

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@password", Encrypt(password));
                    cmd.Parameters.AddWithValue("@username", username);
                    object id = cmd.ExecuteScalar();
                    if (id is int)
                    {
                        return (int)id; ;
                    }
                    else return -1;
                }
            }
            return -1;
        }

        private string Encrypt(string inp)
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
        public Person GetUser(int id)
        {
            try
            {
                using (con)
                {
                    string sql = "SELECT  firstName, secondName, startDate, dateOfBirth, wagePerHour, role, department, phoneNumber, email, working FROM employee WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    MySqlDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        Person user=new Worker(result[0].ToString(), result[1].ToString(), Convert.ToDateTime(result[2]), Convert.ToDateTime(result[3]), Convert.ToDouble(result[4]), result[5].ToString(), result[6].ToString(), result[7].ToString(), result[8].ToString(), Convert.ToBoolean(result[9]), id);
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }

        public bool CreateDBBackup()
        {
            using (con)
            {

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        try
                        {
                            try
                            {
                                cmd.Connection = con;
                                con.Open();
                                //The file is saving at mediabazaar-s2-cb06-1\bin\Debug
                                string file = "backupDB.BAK";
                                mb.ExportToFile(file);
                            }
                            catch (MySqlException ex)
                            {
                                MessageBox.Show(ex.Message + " sql query error.");
                                return false;
                            }

                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show(ex.Message + " connection error.");
                            return false;
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                }
            }

            return true;
        }
    }
}
