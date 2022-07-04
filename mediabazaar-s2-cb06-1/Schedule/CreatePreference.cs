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
    public partial class CreatePreference : Form
    {
        private WorkWeek ww = new WorkWeek();
        private bool isNew;
        public CreatePreference(int id)
        {
            InitializeComponent();
            isNew = ww.GetWanted(id);
            if (!isNew)
            {
                List<WorkDay> schedule = ww.GetWeek();
                if (schedule[0].sShift == 0)
                    cbD0.SelectedIndex = 0;
                else
                {
                    cbD0.SelectedIndex = schedule[0].sShift - 7;
                    cbDe0.SelectedItem = schedule[0].eShift + ":00";
                }
                if (schedule[1].sShift == 0)
                    cbD1.SelectedIndex = 0;
                else
                {
                    cbD1.SelectedIndex = schedule[1].sShift - 7;
                    cbDe1.SelectedItem = schedule[1].eShift + ":00";
                }
                if (schedule[2].sShift == 0)
                    cbD2.SelectedIndex = 0;
                else
                {
                    cbD2.SelectedIndex = schedule[2].sShift - 7;
                    cbDe2.SelectedItem = schedule[2].eShift + ":00";
                }
                if (schedule[3].sShift == 0)
                    cbD3.SelectedIndex = 0;
                else
                {
                    cbD3.SelectedIndex = schedule[3].sShift - 7;
                    cbDe3.SelectedItem = schedule[3].eShift + ":00";
                }
                if (schedule[4].sShift == 0)
                    cbD4.SelectedIndex = 0;
                else
                {
                    cbD4.SelectedIndex = schedule[4].sShift - 7;
                    cbDe4.SelectedItem = schedule[4].eShift + ":00";
                }
            } 
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cbD0_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbD0.SelectedIndex > -1)
            {
                cbDe0.Items.Clear();
                if (cbD0.SelectedItem.ToString() == "none")
                {
                    cbDe0.Items.Add("none");
                    cbDe0.SelectedItem = "none";
                }
                else
                {
                    for (int i = cbD0.SelectedIndex + 8; i < 21; i++)
                    {
                        cbDe0.Items.Add(i + ":00");
                        cbDe0.SelectedIndex = 0;
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
                }
                else
                {
                    for (int i = cbD1.SelectedIndex + 8; i < 21; i++)
                    {
                        cbDe1.Items.Add(i + ":00");
                        cbDe1.SelectedIndex = 0;
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
                }
                else
                {
                    for (int i = cbD2.SelectedIndex + 8; i < 21; i++)
                    {
                        cbDe2.Items.Add(i + ":00");
                        cbDe2.SelectedIndex = 0;
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
                }
                else
                {
                    for (int i = cbD3.SelectedIndex + 8; i <21; i++)
                    {
                        cbDe3.Items.Add(i + ":00");
                        cbDe3.SelectedIndex = 0;
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
                }
                else
                {
                    for (int i = cbD4.SelectedIndex + 8; i < 21; i++)
                    {
                        cbDe4.Items.Add(i + ":00");
                        cbDe4.SelectedIndex=0;
                    }
                }
            }
        }

        private void bSaveEdit_Click(object sender, EventArgs e)
        {
            if(cbD0.SelectedIndex>-1&& cbD1.SelectedIndex > -1&& cbD2.SelectedIndex > -1&& cbD3.SelectedIndex > -1&& cbD4.SelectedIndex > -1)
            {
                string[] time = new string[5];
                if (cbD0.SelectedItem.ToString() != "none")
                {
                    time[0] = cbD0.SelectedItem.ToString().Substring(0, (cbD0.SelectedItem.ToString() + ":").IndexOf(':'));
                    time[0] += " " + cbDe0.SelectedItem.ToString().Substring(0, (cbDe0.SelectedItem.ToString() + ":").IndexOf(':'));
                }
                else
                    time[0] = "0 0";
                if (cbD1.SelectedItem.ToString() != "none")
                {
                    time[1] = cbD1.SelectedItem.ToString().Substring(0, (cbD1.SelectedItem.ToString() + ":").IndexOf(':'));
                    time[1] += " " + cbDe1.SelectedItem.ToString().Substring(0, (cbDe1.SelectedItem.ToString() + ":").IndexOf(':'));
                }
                else
                    time[1] = "0 0";
                if (cbD2.SelectedItem.ToString() != "none")
                {
                    time[2] = cbD2.SelectedItem.ToString().Substring(0, (cbD2.SelectedItem.ToString() + ":").IndexOf(':'));
                    time[2] += " " + cbDe2.SelectedItem.ToString().Substring(0, (cbDe2.SelectedItem.ToString() + ":").IndexOf(':'));
                }
                else
                    time[2] = "0 0";
                if (cbD3.SelectedItem.ToString() != "none")
                {
                    time[3] = cbD3.SelectedItem.ToString().Substring(0, (cbD3.SelectedItem.ToString() + ":").IndexOf(':'));
                    time[3] += " " + cbDe3.SelectedItem.ToString().Substring(0, (cbDe3.SelectedItem.ToString() + ":").IndexOf(':'));
                }
                else
                    time[3] = "0 0";
                if (cbD4.SelectedItem.ToString() != "none")
                {
                    time[4] = cbD4.SelectedItem.ToString().Substring(0, (cbD4.SelectedItem.ToString() + ":").IndexOf(':'));
                    time[4] += " " + cbDe4.SelectedItem.ToString().Substring(0, (cbDe4.SelectedItem.ToString() + ":").IndexOf(':'));
                }
                else
                    time[4] = "0 0";
                if (!ww.AddWanted(isNew,time)) MessageBox.Show("somethig went wrong!");
                else this.Close();
            }
            else
                MessageBox.Show("Fill all fields!");
        }
    }
}
