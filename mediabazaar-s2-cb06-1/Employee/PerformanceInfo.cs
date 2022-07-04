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

namespace mediabazaar_s2_cb06_1.Employee
{
    public partial class PerformanceInfo : Form
    {
        private WorkWeek wwS;
        private WorkWeek wwW;
        private DateTime data;
        private int id;
        public PerformanceInfo(int id)
        {
            InitializeComponent();
            data = DateTime.Today.AddDays(-(DateTime.Today.DayOfWeek - DayOfWeek.Monday)).Date;
            wwS = new WorkWeek(id);
            lDateInfo.Text = "Week from \n" + data.Date.ToShortDateString();
            this.id = id;
            initPerformance();
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
        private void initPerformance()
        {
            wwW = new WorkWeek(id, data);
            pInfo.Controls.Clear();
            string[] week = { "Monday", "Tuesday", "Wednesday", "Thursady", "Friday" };
            int xSch = 20;
            int ySch = 50;
            for (int i = 0; i < 5; i++)
            {
                Label label = new Label();
                label.Font = new Font("Verdana", 18, FontStyle.Regular);
                label.ForeColor = Color.FromArgb(255, 255, 255, 255);
                label.Text = week[i];
                label.Location = new Point(xSch, 10);
                label.Height = 40;
                label.Width = 160;
                label.TextAlign = ContentAlignment.MiddleCenter;
                xSch += 160;
                pInfo.Controls.Add(label);
            }
            WorkDay[] schedule = wwS.GetWeek().ToArray();
            WorkDay[] worked = wwW.GetWeek().ToArray();
            xSch = 20;
            for (int i = 0; i < 5; i++)
            {
                int hh = 8;

                for (int j = 0; j < 13; j++)
                {
                    Label label = new Label();
                    label.Font = new Font("Verdana", 17, FontStyle.Regular);
                        if (schedule[i].InShift(hh))
                            label.ForeColor = Color.FromArgb(255, 255, 255, 255);
                        else
                            label.ForeColor = Color.FromArgb(255, 123, 123, 123);
                        if (worked[i].InShift(hh))
                                label.BackColor = Color.FromArgb(255, 77, 166, 88);
                    label.Text = hh + ":00";
                    hh++;
                    label.Location = new Point(xSch, ySch);
                    label.Height = 31;
                    label.Width = 120;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    ySch += 31;
                    pInfo.Controls.Add(label);
                }
                ySch = 50;
                xSch += 160;
            }
            lExpected.Text = "Expected:\n" + wwS.GetWorkedHours() + " hours";
            lFact.Text= "Worked:\n" + wwW.GetWorkedHours() + " hours";
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            if (data+TimeSpan.FromDays(7) > DateTime.Now)
                MessageBox.Show("We can not see in to the futere!");
            else
            {
                data = data.AddDays(7);
                lDateInfo.Text = "Week from \n" + data.Date.ToShortDateString();
                this.initPerformance();
            }
        }

        private void bPrev_Click(object sender, EventArgs e)
        {
            data = data.AddDays(-7);
            lDateInfo.Text = "Week from \n" + data.Date.ToShortDateString();
            this.initPerformance();
        }
    }
}
