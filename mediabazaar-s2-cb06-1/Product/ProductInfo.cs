using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mediabazaar_s2_cb06_1.Product
{
    public partial class ProductInfo : Form
    {
        ProductManager pm = new ProductManager();
        public ProductInfo(bool access)
        {
            InitializeComponent();

        }


        private void bProductSave_Click(object sender, EventArgs e)
        {
            if (tbBarcode.Text == "")
                return;
            if (tbPrice.Text == "")
                return;
            if (tbProductName.Text == "")
                return;
            if (tbStockAmount.Text == "")
                return;
            if (pm.AddProduct(tbProductName.Text, cbProductCategory.SelectedItem.ToString(), Convert.ToInt32(tbStockAmount.Text), Convert.ToDouble(tbPrice.Text), tbBarcode.Text))
                this.Close();
            else
                MessageBox.Show("Data incorrect!");
        }

        private void bProductClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
