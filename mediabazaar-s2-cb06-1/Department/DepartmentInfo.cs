using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mediabazaar_s2_cb06_1.Schedule;

namespace mediabazaar_s2_cb06_1.Department
{
    public partial class DepartmentInfo : Form
    {
        private bool balance=false;
        private string name;
        public DepartmentInfo(string department)
        {
            InitializeComponent();
            initInfo(department);
            name = department;
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;
        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void initInfo(string inp)
        {
            int[,] depinfo = new int[5,13];
            List<WorkWeek> weeksInfo = DepartmentManager.GetDepartmentInfo(inp);
            if (weeksInfo != null)
            {
                foreach(WorkWeek ww in weeksInfo)
                {
                    List<WorkDay> schedule = ww.GetWeek();
                    for (int i = 0; i < 5; i++)
                    {
                        int hh = 8;
                        for (int j = 0; j < 13; j++)
                        {
                            if (schedule[i].InShift(hh)) depinfo[i,j]++;
                            hh++;
                        }
                    }
                }
                int xSch = 20;
                for (int i = 0; i < 5; i++)
                {
                    int hh = 8;
                    int ySch = 70;
                    for (int j = 0; j < 13; j++)
                    {
                        Label label = new Label();
                        label.Font = new Font("Verdana", 18, FontStyle.Regular);
                        if (depinfo[i, j] > 0)
                        {
                            label.ForeColor = Color.FromArgb(255, 255, 255, 255);
                            label.Text = hh + ":00 w:" + depinfo[i, j];
                        }
                        else
                        {
                            label.ForeColor = Color.FromArgb(255, 123, 123, 123);
                            label.Text = hh + ":00";
                        }
                        hh++;
                        label.Location = new Point(xSch, ySch);
                        label.Height = 30;
                        label.Width = 190;
                        label.TextAlign = ContentAlignment.MiddleCenter;
                        ySch += 35;
                        this.Controls.Add(label);
                    }
                    xSch += 180;
                }
                string[] week = { "Monday", "Tuesday", "Wednesday", "Thursady", "Friday" };
                xSch = 20;
                for (int i = 0; i < 5; i++)
                {
                    Label label = new Label();
                    label.Font = new Font("Verdana", 20, FontStyle.Regular);
                    label.ForeColor = Color.FromArgb(255, 255, 255, 255);
                    label.Text = week[i];
                    label.Location = new Point(xSch, 20);
                    label.Height = 40;
                    label.Width = 190;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    xSch += 180;
                    this.Controls.Add(label);
                }
            }
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            try
            {
                int MaxHour=Convert.ToInt32(tbMaxHour.Text);
                int MiniShop=Convert.ToInt32(tbMiniShop.Text);
                int NumPpl=Convert.ToInt32(tbNumPpl.Text);
                GeneratorSchedule gs = new GeneratorSchedule(MaxHour, MiniShop, NumPpl, name);
                MessageBox.Show(gs.GenerateShedule());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Enter correct details"+ex);
            }
            
        }

    }
}
