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

namespace mediabazaar_s2_cb06_1.MailBox
{
    public partial class MailsBox : Form
    {
        private MailManager mm;
        private EmployeeManager em = new EmployeeManager();
        private Label lMail;
        private int y=20;
        public MailsBox(Person person)
        {
            InitializeComponent();
            lblNameAccount.Text = person.GetNamePos();
            mm = new MailManager(person);
            foreach (Person prsn in em.GetEmployees()) 
                cbPeople.Items.Add(prsn.GetNamePos());
            UpdMails();
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            int recive = -1;
            if (cbPeople.SelectedIndex > -1 && tbMail.Text != "")
            {
                foreach (Person prsn in em.GetEmployees())
                {
                    if (prsn.GetNamePos() == cbPeople.SelectedItem.ToString())
                        recive=prsn.GetId();
                }
                if (mm.SendMail(recive, tbMail.Text))
                {
                    MessageBox.Show("Sended");
                    tbMail.Text = "";
                }
            }
        }
        private void UpdMails()
        {
            pMails.Controls.Clear();
            y = 20;
            foreach(Mail mail in mm.GetMails())
            {
                List<string> info = mail.GetInfo();
                lMail = new Label();
                lMail.Text = info[3]+"\n By "+em.GetPersonById(Convert.ToInt32(info[0])).GetNamePos()+" "+info[2];
                lMail.Name = info[4];
                lMail.Location = new Point(10, y);
                lMail.ForeColor =Color.FromArgb(255, 255, 255, 255);
                lMail.Height = 40;
                lMail.Width = 960;
                y += 45;
                lMail.Font = new Font("Verdana", 11, FontStyle.Regular);
                lMail.DoubleClick += new EventHandler(Delete_DoubleClick);
                pMails.Controls.Add(lMail);
            }
        }
        private void Delete_DoubleClick(object sender, EventArgs e)
        {
            if(!mm.DeleteMail(Convert.ToInt32(((System.Windows.Forms.Label)sender).Name)))
                MessageBox.Show("Someting went wrong");
            UpdMails();
        }
        //Form design part
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        private void bTP_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
