using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace mediabazaar_s2_cb06_1.Schedule
{
    static class WorkWeekDB
    {
        private static string connStr = ConnectionString.GetConStr();
        public static List<WorkDay> GetDays(int id)
        {
            List<WorkDay> workDays = new List<WorkDay>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "SELECT  d0, b0, d1, b1, d2, b2, d3, b3, d4, b4 FROM shifts WHERE id=@id AND StartDate <= @now ORDER BY StartDate DESC LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@now", DateTime.Now.ToString("yyyy-MM-dd"));
                    conn.Open();
                    MySqlDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (result[i * 2] == null)
                                workDays.Add(new WorkDay("00 00", "00 00"));
                            else if (result[i * 2 + 1] == null)
                                workDays.Add(new WorkDay(result[2 * i].ToString(), "00 00"));
                            else
                                workDays.Add(new WorkDay(result[2 * i].ToString(), result[2 * i + 1].ToString()));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                for (int i = 0; i < 5; i++)
                    workDays.Add(new WorkDay("10 20", "14 14"));
            }
            if (workDays.Count < 1)
            {
                for (int i = 0; i < 5; i++)
                    workDays.Add(new WorkDay("00 00", "00 00"));
            }
            return workDays;
        }
        public static bool ChngeDay(int id, string[] chng, int day)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "INSERT INTO `shifts`(d=@d, b=@b) VALUES (@dC,@bC) WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@d", "d" + day);
                    cmd.Parameters.AddWithValue("@b", "b" + day);
                    cmd.Parameters.AddWithValue("@dC", chng[0]);
                    cmd.Parameters.AddWithValue("@bC", chng[1]);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool AddWeek(string[] inp, int id, DateTime start)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "INSERT INTO `shifts`(`id`, `d0`, `b0`, `d1`, `b1`, `d2`, `b2`, `d3`, `b3`, `d4`, `b4`, StartDate) VALUES (@id, @d0, @b0, @d1, @b1, @d2, @b2, @d3, @b3, @d4, @b4,@now)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@d0", inp[0]);
                    cmd.Parameters.AddWithValue("@b0", inp[1]);
                    cmd.Parameters.AddWithValue("@d1", inp[2]);
                    cmd.Parameters.AddWithValue("@b1", inp[3]);
                    cmd.Parameters.AddWithValue("@d2", inp[4]);
                    cmd.Parameters.AddWithValue("@b2", inp[5]);
                    cmd.Parameters.AddWithValue("@d3", inp[6]);
                    cmd.Parameters.AddWithValue("@b3", inp[7]);
                    cmd.Parameters.AddWithValue("@d4", inp[8]);
                    cmd.Parameters.AddWithValue("@b4", inp[9]);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@now", start.ToString("yyyy-MM-dd"));
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool AddWanted(int id, string[] slot, bool isNew)
        {

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql;
                    if (isNew)
                        sql = "INSERT INTO `wnated_shifts`(`d0`, `d1`, `d2`, `d3`, `d4`, id) VALUES (@d0, @d1, @d2, @d3, @d4, @id)";
                    else
                        sql = "UPDATE `wnated_shifts` SET `d0`=@d0,`d1`=@d1,`d2`=@d2,`d3`=@d3,`d4`=@d4 WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@d0", slot[0]);
                    cmd.Parameters.AddWithValue("@d1", slot[1]);
                    cmd.Parameters.AddWithValue("@d2", slot[2]);
                    cmd.Parameters.AddWithValue("@d3", slot[3]);
                    cmd.Parameters.AddWithValue("@d4", slot[4]);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex + "");
                return false;
            }
        }
        public static List<WorkDay> GetWanted(int id)
        {
            List<WorkDay> workDays = new List<WorkDay>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "SELECT  d0, d1, d2, d3, d4  FROM wnated_shifts WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    MySqlDataReader result = cmd.ExecuteReader();
                    if (result.HasRows)
                    {
                        while (result.Read())
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                workDays.Add(new WorkDay(result[i].ToString(), "00 00"));
                            }
                        }
                        return workDays;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex + "");
                return null;
            }
        }
        public static List<WorkDay> GetWorkedDays(int id, DateTime time)
        {
            List<string> data = new List<string>();
            List<WorkDay> workDays = new List<WorkDay>();
            try
            {

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    for (int i = 0; i < 5; i++)
                    {
                        string sql = "SELECT `time` FROM `onwork` WHERE id=@id AND date=@time";
                        MySqlCommand cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@time", time.Date);

                        MySqlDataReader result = cmd.ExecuteReader();
                        data.Clear();
                        while (result.Read())
                            data.Add(result[0].ToString());
                        switch (data.Count)
                        {
                            case 1:
                                workDays.Add(new WorkDay(data[0] + " "+ DateTime.Now.ToString("HH"), "0 0"));
                                break;
                            case 2:
                                workDays.Add(new WorkDay(data[0] + " " + data[1],"0 0"));
                                break;
                            case 3:
                                workDays.Add(new WorkDay(data[0] + " " + data[2], data[1] + " " + data[1]));
                                break;
                            case 4:
                                workDays.Add(new WorkDay(data[0] + " " + data[3], data[1] + " " + data[2]));
                                break;
                            default:
                                workDays.Add(new WorkDay("0 0", "0 0"));
                                break;
                        }
                        time=time.AddDays(1);
                        result.Close();
                    }
                    return workDays;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex + "");
            }
            return null;
        }
        public static bool SetQRTime(int id)
        {
            try
            {

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM `onwork` WHERE id=@id AND time=@time AND date=@date";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("HH"));
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        sql = "INSERT INTO `onwork`(`id`, `time`, `date`) VALUES(@id, @time, @date)";
                        cmd = new MySqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("HH"));
                        cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex + "");
            }
            return false;
        }
    }
}
