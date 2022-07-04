using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mediabazaar_s2_cb06_1.Employee;

namespace mediabazaar_s2_cb06_1.AccountLogin
{
    public partial class Login : Form
    {
        EmployeeAdministration ea = new EmployeeAdministration();
        AccountAdministration aa = new AccountAdministration();
        DBConnect dbConnect = new DBConnect();

        public Login()
        {
            //Daily backup of the database
            dbConnect.CreateDBBackup();
            InitializeComponent();
            this.CenterToScreen();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtPassword.Text))
                {
                    int id = dbConnect.Login(txtUsername.Text, txtPassword.Text);
                    if (id!=-1)
                    {
                        Person usr=dbConnect.GetUser(id);
                        if (usr != null)
                        {
                            Main main = new Main(usr,id);
                            main.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Login failed");
                    }
                    dbConnect.CloseConnection();
                }
                else MessageBox.Show("Please fill in all fields");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid values");
            }
            catch (Exception ex)
            {
                MessageBox.Show("And error ocurred! " + ex.Message);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }
    }
}
