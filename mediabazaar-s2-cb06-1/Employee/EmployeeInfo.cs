using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mediabazaar_s2_cb06_1.Department;
using mediabazaar_s2_cb06_1.Schedule;
namespace mediabazaar_s2_cb06_1.Employee
{
    public partial class EmployeeInfo : Form
    {
        private Worker person;
        private EmployeeManager em= new EmployeeManager();
        private DepartmentManager dm = new DepartmentManager();
        private bool IsNew = false;
        public EmployeeInfo(int id,bool accsses)
        {
            InitializeComponent();
            person = em.GetPersonById(id);
            ControlReadOnly(true);
            AddDepartments();
            List<string> info = person.GetInfo();
                cbDepartment.SelectedItem = info[5];
                tbEmail.Text = info[3];
                tbPhone.Text = info[4];
                cbPosition.Text = info[6];
                tbSalary.Text = info[2];
                tbBirtDay.Text = info[1];
                tbFirstName.Text = info[0];
            Image image = person.GetImage();
            if (image != null)
                pbPhoto.Image = (Image)(new Bitmap(image, new Size(180, 180)));
            else
                pbPhoto.Image= (Image)(new Bitmap((Properties.Resources.Asset_11_2_77x), new Size(180, 180)));
            if (accsses)
            {
                bSaveEdit.Text = "edit";
            }
            else
            {
                bCreate.Hide();
                bSaveEdit.Hide();
                bRemove.Hide();
                bPerformance.Hide();
            }
        }
        private void AddDepartments()
        {
            foreach(Departement dep in dm.GetDepartments())
            {
                cbDepartment.Items.Add(dep.name);
            }
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
        public EmployeeInfo( bool accsses)
        {
            InitializeComponent();
            IsNew = true;
            bCreate.Hide();
            bRemove.Hide();
            cbDepartment.Text = "Enter department";
            cbPosition.Text = "Enter position";
            foreach (Departement dep in dm.GetDepartments())
            {
                cbDepartment.Items.Add(dep.name);
            }
        }
        private void ControlReadOnly(bool access)
        {
            cbDepartment.Enabled = !access;
            tbEmail.ReadOnly = access;
            tbPhone.ReadOnly = access;
            cbPosition.Enabled = !access;
            tbSalary.ReadOnly = access;
            tbBirtDay.ReadOnly = access;
            tbFirstName.ReadOnly = access;
        }
        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure fire person?", "warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (em.DBRemoveEmployee(person))
                {
                    em.RemoveEmployee(person);
                    this.Close();
                }
                else
                    MessageBox.Show("something went wrong");
            }
        }

        private void bSaveEdit_Click(object sender, EventArgs e)
        {
            List<string> name = tbFirstName.Text.Split(' ').ToList();
            bool isNull = false;
            DateTime birthDay=new DateTime(); 
            double salary=0;
            string position="";
            string department="";
            string phone = "";
            string email = "";
            if (bSaveEdit.Text == "save")
            {
                if (name[1] == "" || name[1] == "")
                {
                    MessageBox.Show("Enter name, please");
                    isNull = true;
                }
                if (tbBirtDay.Text == "")
                {
                    MessageBox.Show("Enter birth day, please");
                    isNull = true;
                }
                else
                    birthDay = Convert.ToDateTime(tbBirtDay.Text);

                if (tbSalary.Text == "")
                {
                    MessageBox.Show("Enter salary, please");
                    isNull = true;
                }
                else
                    salary = Convert.ToDouble(tbSalary.Text);

                if (cbPosition.SelectedText!="")
                {
                    MessageBox.Show("Enter position, please");
                    isNull = true;
                }
                else
                    position = cbPosition.Text;
                MessageBox.Show(position);
                if (cbDepartment.SelectedItem == null)
                {
                    MessageBox.Show("Enter department, please");
                    isNull = true;
                }
                else department = cbDepartment.SelectedItem.ToString();
                if (tbPhone.Text == "")
                {
                    MessageBox.Show("Enter phone, please");
                    isNull = true;
                }
                else phone = tbPhone.Text;
                if (tbEmail.Text == "")
                {
                    MessageBox.Show("Enter email, please");
                    isNull = true;
                }
                else email = tbEmail.Text;
            }
            if (IsNew && !(isNull))
            {
                if (em.DBAddEmployee(name[0], name[1], birthDay, salary, position, department, phone, email))
                {
                    Worker newEmployee = new Worker(name[0], name[1], DateTime.Now, birthDay, salary, position, department, phone, email);
                    em.AddEmployee(newEmployee);
                    this.Close();
                }
                else
                    MessageBox.Show("something went wrong");
            }
            else
            {
                if (bSaveEdit.Text == "edit")
                {
                    ControlReadOnly(false);
                    bSaveEdit.Text = "save";
                }
                else if (!isNull)
                {
                    bSaveEdit.Text = "edit";
                    if (em.DBChangeEmployee(person.GetId(), name[0], name[1], birthDay, salary, position, department, phone, email) == false)
                        MessageBox.Show("something went wrong");
                    ControlReadOnly(true);
                }
            }
            
        }

        private void bSchedule_Click(object sender, EventArgs e)
        {
            ScheduleInfo scheduleInfo;
            if (IsNew)
                scheduleInfo = new ScheduleInfo(em.GetLastId()+1, true);
            else
                scheduleInfo = new ScheduleInfo(person.GetId());
            scheduleInfo.Show();
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            ScheduleInfo scheduleInfo = new ScheduleInfo(person.GetId(), true);
            scheduleInfo.Show();
        }

        private void bPerformance_Click(object sender, EventArgs e)
        {
            PerformanceInfo pf = new PerformanceInfo(person.GetId());
            pf.Show();
        }
    }
}
