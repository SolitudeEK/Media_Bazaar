using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mediabazaar_s2_cb06_1.Schedule
{
    public partial class ScheduleInfo : Form
    {
        private WorkWeek ww;
        private int id;
        public ScheduleInfo(int id)
        {
            InitializeComponent();
            ww = new WorkWeek(id);
            initSchedule(id);
            bSave.Hide();
            pSchedule.Hide();
        }
        public ScheduleInfo(int id,bool isNew)
        {
            InitializeComponent();
            ww = new WorkWeek();
            this.id=id;
        }
        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void initSchedule(int id)
        {
            string[] week = { "Monday", "Tuesday", "Wednesday", "Thursady", "Friday" };
            int xSch = 20;
            int ySch = 70;
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
            List<WorkDay> schedule = ww.GetWeek();
            xSch = 20;
            for (int i = 0; i < 5; i++)
            {
                int hh = 8;

                for (int j = 0; j < 13; j++)
                {
                    Label label = new Label();
                    label.Font = new Font("Verdana", 18, FontStyle.Regular);
                    if (schedule[i].InShift(hh)) label.ForeColor = Color.FromArgb(255, 255, 255, 255);
                    else label.ForeColor = Color.FromArgb(255, 123, 123, 123);
                    label.Text = hh + ":00";
                    hh++;
                    label.Location = new Point(xSch, ySch);
                    label.Height = 30;
                    label.Width = 190;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    ySch += 35;
                    this.Controls.Add(label);
                }
                ySch = 70;
                xSch += 180;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (cbB0.SelectedIndex > -1 && cbB1.SelectedIndex > -1 && cbB2.SelectedIndex > -1 && cbB3.SelectedIndex > -1 && cbB4.SelectedIndex > -1)
            {
                string[] sStart = new string[5];
                sStart[0] = cbD0.SelectedItem.ToString().Substring(0, (cbD0.SelectedItem.ToString()+":").IndexOf(':'));
                sStart[1] = cbD1.SelectedItem.ToString().Substring(0, (cbD1.SelectedItem.ToString() + ":").IndexOf(':'));
                sStart[2] = cbD2.SelectedItem.ToString().Substring(0, (cbD2.SelectedItem.ToString() + ":").IndexOf(':'));
                sStart[3] = cbD3.SelectedItem.ToString().Substring(0, (cbD3.SelectedItem.ToString() + ":").IndexOf(':'));
                sStart[4] = cbD4.SelectedItem.ToString().Substring(0, (cbD4.SelectedItem.ToString() + ":").IndexOf(':'));
                string[] sEnd = new string[5];
                sEnd[0] = cbDe0.SelectedItem.ToString().Substring(0, (cbDe0.SelectedItem.ToString() + ":").IndexOf(':'));
                sEnd[1] = cbDe1.SelectedItem.ToString().Substring(0, (cbDe1.SelectedItem.ToString() + ":").IndexOf(':'));
                sEnd[2] = cbDe2.SelectedItem.ToString().Substring(0, (cbDe2.SelectedItem.ToString() + ":").IndexOf(':'));
                sEnd[3] = cbDe3.SelectedItem.ToString().Substring(0, (cbDe3.SelectedItem.ToString() + ":").IndexOf(':'));
                sEnd[4] = cbDe4.SelectedItem.ToString().Substring(0, (cbDe4.SelectedItem.ToString() + ":").IndexOf(':'));
                string[] br = new string[5];
                br[0] = cbB0.SelectedItem.ToString().Substring(0, (cbB0.SelectedItem.ToString() + ":").IndexOf(':'));
                br[1] = cbB1.SelectedItem.ToString().Substring(0, (cbB1.SelectedItem.ToString() + ":").IndexOf(':'));
                br[2] = cbB2.SelectedItem.ToString().Substring(0, (cbB2.SelectedItem.ToString() + ":").IndexOf(':'));
                br[3] = cbB3.SelectedItem.ToString().Substring(0, (cbB3.SelectedItem.ToString() + ":").IndexOf(':'));
                br[4] = cbB4.SelectedItem.ToString().Substring(0, (cbB4.SelectedItem.ToString() + ":").IndexOf(':'));
                StringBuilder sb = new StringBuilder();
                for(int i = 0; i < 5; i++)
                {
                    if (sStart[i] == "none") sb.Append("0 0v0 0");
                    else sb.Append(sStart[i] + " " + sEnd[i] + "v" + br[i] + " " + br[i]);
                    if (i != 4) sb.Append("v");
                }
                string inp = sb.ToString();
                if (!ww.AddWeek(inp, id, dTPStart.Value)) MessageBox.Show("somethig went wrong!");
                else this.Close();
            }
            else
                MessageBox.Show("Fill all fields!");
        }

        private void cbD0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbD0.SelectedIndex > -1 )
            {
                cbDe0.Items.Clear();
                if (cbD0.SelectedItem.ToString() == "none")
                {
                    cbDe0.Items.Add("none");
                    cbDe0.SelectedItem = "none";
                    cbB0.Items.Add("none");
                    cbB0.SelectedItem = "none";
                }
                else
                {
                    for (int i = cbD0.SelectedIndex + 10; i < 21; i++)
                    {
                        cbDe0.Items.Add(i + ":00");
                    }
                }
            }
        }

        private void cbD1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbD1.SelectedIndex > -1)
            {
                cbDe1.Items.Clear();
                if (cbD1.SelectedItem.ToString() == "none")
                {
                    cbDe1.Items.Add("none");
                    cbDe1.SelectedItem = "none";
                    cbB1.Items.Add("none");
                    cbB1.SelectedItem = "none";
                }
                else
                {
                    for (int i = cbD1.SelectedIndex + 10; i < 21; i++)
                    {
                        cbDe1.Items.Add(i + ":00");
                    }
                }
            }
        }

        private void cbD2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbD2.SelectedIndex > -1)
            {
                cbDe2.Items.Clear();
                if (cbD2.SelectedItem.ToString() == "none")
                {
                    cbDe2.Items.Add("none");
                    cbDe2.SelectedItem = "none";
                    cbB2.Items.Add("none");
                    cbB2.SelectedItem = "none";
                }
                else
                {
                    for (int i = cbD2.SelectedIndex + 10; i < 21; i++)
                    {
                        cbDe2.Items.Add(i + ":00");
                    }
                }
            }
        }

        private void cbD3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbD3.SelectedIndex > -1)
            {
                cbDe3.Items.Clear();
                if (cbD3.SelectedItem.ToString() == "none")
                {
                    cbDe3.Items.Add("none");
                    cbDe3.SelectedItem = "none";
                    cbB3.Items.Add("none");
                    cbB3.SelectedItem = "none";
                }
                else
                {
                    for (int i = cbD3.SelectedIndex + 10; i < 21; i++)
                    {
                        cbDe3.Items.Add(i + ":00");
                    }
                }
            }
        }

        private void cbD4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbD4.SelectedIndex > -1)
            {
                cbDe4.Items.Clear();
                if (cbD4.SelectedItem.ToString() == "none")
                {
                    cbDe4.Items.Add("none");
                    cbDe4.SelectedItem = "none";
                    cbB4.Items.Add("none");
                    cbB4.SelectedItem = "none";
                }
                else
                {
                    for (int i = cbD4.SelectedIndex + 10; i < 21; i++)
                    {
                        cbDe4.Items.Add(i + ":00");
                    }
                }
            }
        }

        private void cbDe0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDe0.SelectedIndex > -1)
            {
                cbB0.Items.Clear();                
                for (int i = cbD0.SelectedIndex + 9; i < cbD0.SelectedIndex + cbDe0.SelectedIndex+9; i++)
                {
                    cbB0.Items.Add(i + ":00");
                }
            }
        }

        private void cbDe1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDe1.SelectedIndex > -1)
            {
                cbB1.Items.Clear();
                for (int i = cbD1.SelectedIndex + 9; i < cbDe1.SelectedIndex+ cbD1.SelectedIndex + 9; i++)
                {
                    cbB1.Items.Add(i + ":00");
                }
            }
        }

        private void cbDe2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDe2.SelectedIndex > -1)
            {
                cbB2.Items.Clear();
                for (int i = cbD2.SelectedIndex + 9; i < cbD2.SelectedIndex + cbDe2.SelectedIndex + 9; i++)
                {
                    cbB2.Items.Add(i + ":00");
                }
            }
        }

        private void cbDe3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDe3.SelectedIndex > -1)
            {
                cbB3.Items.Clear();
                for (int i = cbD3.SelectedIndex + 9; i < cbD3.SelectedIndex + cbDe3.SelectedIndex + 9; i++)
                {
                    cbB3.Items.Add(i + ":00");
                }
            }
        }

        private void cbDe4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDe4.SelectedIndex > -1)
            {
                cbB4.Items.Clear();
                for (int i = cbD4.SelectedIndex + 9; i < cbD4.SelectedIndex + cbDe4.SelectedIndex +9; i++)
                {
                    cbB4.Items.Add(i + ":00");
                }
            }
        }

        private void currentSchd_Click(object sender, EventArgs e)
        {
            ww = new WorkWeek(id);
            List<WorkDay> schedule = ww.GetWeek();
            if (schedule.Count < 4)
                MessageBox.Show("There is not current schedule!");
            else
            {
                if (schedule[0].sShift == 0)
                    cbD0.SelectedIndex = 0;
                else
                {
                    cbD0.SelectedIndex = schedule[0].sShift - 7;
                    cbDe0.SelectedItem = schedule[0].eShift + ":00";
                    cbB0.SelectedItem = schedule[0].sBreak + ":00";
                }
                if (schedule[1].sShift == 0)
                    cbD1.SelectedIndex = 0;
                else
                {
                    cbD1.SelectedIndex = schedule[1].sShift - 7;
                    cbDe1.SelectedItem = schedule[1].eShift + ":00";
                    cbB1.SelectedItem = schedule[1].sBreak + ":00";
                }
                if (schedule[2].sShift == 0)
                    cbD2.SelectedIndex = 0;
                else
                {
                    cbD2.SelectedIndex = schedule[2].sShift - 7;
                    cbDe2.SelectedItem = schedule[2].eShift + ":00";
                    cbB2.SelectedItem = schedule[2].sBreak + ":00";
                }
                if (schedule[3].sShift == 0)
                    cbD3.SelectedIndex = 0;
                else
                {
                    cbD3.SelectedIndex = schedule[3].sShift - 7;
                    cbDe3.SelectedItem = schedule[3].eShift + ":00";
                    cbB3.SelectedItem = schedule[3].sBreak + ":00";
                }
                if (schedule[4].sShift == 0)
                    cbD4.SelectedIndex = 0;
                else
                {
                    cbD4.SelectedIndex = schedule[4].sShift - 7;
                    cbDe4.SelectedItem = schedule[4].eShift + ":00";
                    cbB4.SelectedItem = schedule[4].sBreak + ":00";
                }
            }
        }

        private void bFirst_Click(object sender, EventArgs e)
        {
            List<WorkDay> schedule = WorkWeek.GetFirstWeek();
            cbD0.SelectedIndex = schedule[0].sShift - 8;
            cbDe0.SelectedItem = schedule[0].eShift + ":00";
            cbB0.SelectedItem = schedule[0].sBreak + ":00";
            cbD1.SelectedIndex = schedule[1].sShift - 8;
            cbDe1.SelectedItem = schedule[1].eShift + ":00";
            cbB1.SelectedItem = schedule[1].sBreak + ":00";
            cbD2.SelectedIndex = schedule[2].sShift - 8;
            cbDe2.SelectedItem = schedule[2].eShift + ":00";
            cbB2.SelectedItem = schedule[2].sBreak + ":00";
            cbD3.SelectedIndex = schedule[3].sShift - 8;
            cbDe3.SelectedItem = schedule[3].eShift + ":00";
            cbB3.SelectedItem = schedule[3].sBreak + ":00";
            cbD4.SelectedIndex = schedule[4].sShift - 8;
            cbDe4.SelectedItem = schedule[4].eShift + ":00";
            cbB4.SelectedItem = schedule[4].sBreak + ":00";
        }

        private void bSecond_Click(object sender, EventArgs e)
        {
            List<WorkDay> schedule = WorkWeek.GetSecondWeek();
            cbD0.SelectedIndex = schedule[0].sShift - 8;
            cbDe0.SelectedItem = schedule[0].eShift + ":00";
            cbB0.SelectedItem = schedule[0].sBreak + ":00";
            cbD1.SelectedIndex = schedule[1].sShift - 8;
            cbDe1.SelectedItem = schedule[1].eShift + ":00";
            cbB1.SelectedItem = schedule[1].sBreak + ":00";
            cbD2.SelectedIndex = schedule[2].sShift - 8;
            cbDe2.SelectedItem = schedule[2].eShift + ":00";
            cbB2.SelectedItem = schedule[2].sBreak + ":00";
            cbD3.SelectedIndex = schedule[3].sShift - 8;
            cbDe3.SelectedItem = schedule[3].eShift + ":00";
            cbB3.SelectedItem = schedule[3].sBreak + ":00";
            cbD4.SelectedIndex = schedule[4].sShift - 8;
            cbDe4.SelectedItem = schedule[4].eShift + ":00";
            cbB4.SelectedItem = schedule[4].sBreak + ":00";
        }
    }
}
