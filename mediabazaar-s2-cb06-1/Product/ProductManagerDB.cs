using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace mediabazaar_s2_cb06_1.Product
{
    static class ProductManagerDB
    {
        private static string connStr = ConnectionString.GetConStr();

        public static List<Product> InitProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "SELECT id,name,category,barcode,price,stockAmount FROM `products` LIMIT 50";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    MySqlDataReader result = cmd.ExecuteReader();
                    while (result.Read())
                        products.Add(new Product(
                            Convert.ToInt32(result[0]),
                            result[1].ToString(),
                            result[2].ToString(),
                            result[3].ToString(),
                            Convert.ToDouble(result[4]),
                            Convert.ToInt32(result[5])));
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return products;
        }

        public static bool ChangeAmount(int id, int amount)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "UPDATE `products` SET `stockAmount`=@amount WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@amount",amount);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public static bool AddProduct(string name, string category, int amount, double price, string barcode)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "INSERT INTO `products` (`name`, `category`, `price`, `stockAmount`, `barcode`) VALUES (@name, @category,@price,@amount,@barcode)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@category", category);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@barcode", barcode);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        public static bool DeletePrdct(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    string sql = "DELETE FROM `products` WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    conn.Open();
                    cmd.Parameters.AddWithValue("@id", id);
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
