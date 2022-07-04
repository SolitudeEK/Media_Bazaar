using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mediabazaar_s2_cb06_1.Product
{
    public class Product
    {
        private static List<Product> products = new List<Product>();

        private int _id;
        private string _productName; 
        private string _category;
        private string _barcode;
        private double _price;
        private int _stockAmount;

        public Product(int id, string productName, string category, string barcode, double price, int stockAmount)
        {
            _id = id;
            _productName = productName;
            _category = category;
            _barcode = barcode;
            _price = price;
            _stockAmount = stockAmount;

        }

        public string[] GetInfo()
        {
            List<string> otp = new List<string>();
            otp.Add(_id.ToString()); 
            otp.Add(_productName);
            otp.Add(_category);
            otp.Add(_price.ToString());
            otp.Add(_stockAmount.ToString());
            otp.Add(_barcode);
            return otp.ToArray();
        }
        public int GetId()
        {
            return _id;
        }
        public int GetAmount()
        {
            return _stockAmount;
        }
        public void ChangeAmount(int amount)
        {
            _stockAmount=amount;
        }


    }
}
