using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mediabazaar_s2_cb06_1.MailBox
{
    public static class MailDB
    {
        private static string connStr = ConnectionString.GetConStr();
        public static bool DeleteMail(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "DELETE FROM `mails` WHERE `mail_id`=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }
        public static bool SendMail(int recipentId, string mail, int holderId)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "INSERT INTO `mails`(`sender_id`, `recipent_id`, `message`, `sended`) VALUES (@sender,@recipent,@mail,@time)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@sender", holderId);
                    cmd.Parameters.AddWithValue("@recipent", recipentId);
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public static List<Mail> GetMails(int holderId)
        {
            List<Mail> mails = new List<Mail>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "SELECT `sender_id`, `message`, `sended`, mail_id FROM `mails` WHERE `recipent_id`=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", holderId);
                    conn.Open();
                    MySqlDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                        mails.Add(new Mail(Convert.ToInt32(result[0]), holderId, result[1].ToString(), Convert.ToDateTime(result[2]), Convert.ToInt32(result[3])));
                    return mails;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex + "") ;
            }
            return null;
        }

        public static List<int> GetIds(string role)
        {
            List<int> ids = new List<int>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "SELECT `id` FROM `employee` WHERE role=@role";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@role", role);
                    conn.Open();
                    MySqlDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                        ids.Add(Convert.ToInt32(result[0]));
                    return ids;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex + "");
            }
            return null;
        }
    }
}
