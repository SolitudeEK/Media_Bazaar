using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mediabazaar_s2_cb06_1.MailBox;

namespace mediabazaar_s2_cb06_1.Product
{
    class ProductManager
    {
        private static List<Product> products = new List<Product>();

        public void InitProducts()
        {
            products = ProductManagerDB.InitProducts();
        }

        public List<Product> GetProducts()
        {
            return products;
        }
        public bool ChangeAmount(int id, int amount)
        {
            if (amount < 0) return false;
            if (amount == 0) MailManager.SendMail("Product with id " + id + " is out of stock", "Stock", 2);
            else if(amount < 2) MailManager.SendMail("Product with id " + id + " is ending", "Stock", 2);
                if (ProductManagerDB.ChangeAmount(id, amount))
            {
                foreach (Product prdct in products)
                {
                    if (prdct.GetId() == id)
                        prdct.ChangeAmount(amount);
                }
                return true;
            }
            else
                return false;
        }
        public int GetAmount(int id)
        {
            foreach (Product prdct in products)
            {
                if (prdct.GetId() == id)
                    return prdct.GetAmount();
            }
            return -1;
        }
        public void Cleaning()
        {
            products.Clear();
        }
        public bool AddProduct(string name, string category, int amount, double price, string barcode)
        {
            if (ProductManagerDB.AddProduct(name, category, amount, price, barcode))
            {
                products.Add(new Product(products.Last().GetId() + 1, name, category, barcode, price, amount));
                return true;
            }
            return false;
        }
        public bool DeletePrdct(int id)
        {
            if (ProductManagerDB.DeletePrdct(id))
            {
                foreach (Product prdct in products)
                {
                    if (prdct.GetId() == id)
                    {
                        products.Remove(prdct);
                        break;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
