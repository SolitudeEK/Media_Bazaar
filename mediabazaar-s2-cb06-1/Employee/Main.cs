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
using mediabazaar_s2_cb06_1.Department;
using mediabazaar_s2_cb06_1.Schedule;
using mediabazaar_s2_cb06_1.Product;
using mediabazaar_s2_cb06_1.AccountLogin;
using mediabazaar_s2_cb06_1.MailBox;
using mediabazaar_s2_cb06_1.Scanner;
namespace mediabazaar_s2_cb06_1
{
    public partial class Main : Form
    {
        private Person user;
        private List<Button> bEmployees = new List<Button>();
        private ListBox lbDepartment = new ListBox();
        private Button bAddDepartment = new Button();
        private Button bRemoveDepartment = new Button();
        private Button bViewDepartment = new Button();
        private Button bRem = new Button();
        private TextBox tbAddDepartment = new TextBox();
        private EmployeeManager Em = new EmployeeManager();
        private DepartmentManager Dm= new DepartmentManager();
        private ProductManager pm = new ProductManager();
        private ListBox list = new ListBox();
        private WorkWeek ww;
        private bool formState = true;
        private int xEmp = 20, yEmp = 30;
        private List<bool> access;
        private string depSearch="none";
        private bool isPrdctDeleting = false;
        public Main(Person person, int id)
        {
            InitializeComponent();
            makeAccess(person);
            lblNameAccount.Text = person.GetNamePos();
            Em.InitEmployee();
            Dm.InitDepartments();
            pm.InitProducts();
            ww = new WorkWeek(id);
            updEmployee();
            initDepartments();
            initStock();
            initSchedule(id);
            initOption();
            initEmployee();
            pDepartment.Hide();
            user = person;
            this.CenterToScreen();
        }
        public void makeAccess(Person usr)
        {
            switch (usr.GetNamePos().Substring(0, usr.GetNamePos().IndexOf(" "))) // Access Rights 0- Employee control; 1- see Stock; 2-department control; 3- administrative actions; 4- scannerQr
            {
                case "HR":
                    access = new List<bool>() { true, false, false, false, false };
                    break;
                case "Stock":
                    access = new List<bool>() { false, true, false, false, false };
                    break;
                case "Executive":
                    access = new List<bool>() { true, false, true, true, false };
                    break;
                case "Receptionist":
                    access = new List<bool>() { false, false, false, false, true };
                    break;
                default:
                    access = new List<bool>() { false, false, false, false, false };
                    break;
            }
        }

        #region Employee
        public void updEmployee()
        {
            pEmployee.Controls.Clear();
            bEmployees.Clear();
            xEmp = 20;
            yEmp = 30;
            List<Worker> inp = Em.GetEmployees();
            foreach (Worker employee in inp)
            {
                if (depSearch=="none"&&employee.IsWorking()) addExmployeeCard(employee);
                else if(employee.GetDepartment()==depSearch && employee.IsWorking()) addExmployeeCard(employee);
            }
            if (access[0]) addEmployeeAddCardAdd();

        }
        private void initEmployee()
        {
            cbSearch.Items.Clear();
            cbSearch.Items.Add("none");
            foreach (Departement dep in Dm.GetDepartments())
            {
                cbSearch.Items.Add(dep.name);
            }
            //cbSearch.Items.AddRange(Dm.GetDepartments().ToArray());
            cbSearch.SelectedIndex = 0;

        }
        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSearch.SelectedIndex > -1)
            {
                depSearch = cbSearch.SelectedItem.ToString();           
                updEmployee();
            }
        }
        private void EmployeeHide()
        {
            pEmployee.Hide();
            cbSearch.Hide();
        }
        private void EmployeeShow()
        {
            pEmployee.Show();
            cbSearch.Show();
        }
        public void addExmployeeCard(Person person) 
        {
            bEmployees.Add(new Button());
            bEmployees.Last().Name = person.GetId().ToString();
            bEmployees.Last().Width = 151;
            bEmployees.Last().Height = 193;
            bEmployees.Last().Text = "\n\n\n\n"+person.ToCard();
            bEmployees.Last().TextAlign = ContentAlignment.MiddleCenter;
            bEmployees.Last().Font = new Font("Verdana", 12, FontStyle.Regular);
            bEmployees.Last().ForeColor = Color.FromArgb(255, 255, 255, 255);
            bEmployees.Last().Location = new Point(xEmp, yEmp);
            PictureBox picture = new PictureBox();
            picture.Width = 86;
            picture.Height = 86;
            picture.BackColor= Color.FromArgb(255, 0, 0, 0);
            picture.Location= new Point(xEmp+34, yEmp+12);
            Image image = person.GetImage();
            if (image == null)
                picture.Image = ((System.Drawing.Image)(Properties.Resources.Asset_10_1_77x));
            else
                picture.Image = (Image)(new Bitmap(image, new Size(86, 86)));
            pEmployee.Controls.Add(picture);
            xEmp += 168;
            if (xEmp > 1000) 
            {
                xEmp = 20;
                yEmp += 213;
            }
            bEmployees.Last().FlatStyle = FlatStyle.Flat;
            bEmployees.Last().FlatAppearance.BorderSize = 0;
            bEmployees.Last().BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Asset_4_11));
            bEmployees.Last().Click += new EventHandler(Employee_Click);
            pEmployee.Controls.Add(bEmployees.Last());
        }
        public void addEmployeeAddCardAdd() 
        {
            bEmployees.Add(new Button());
            bEmployees.Last().Width = 151;
            bEmployees.Last().Height = 193;
            bEmployees.Last().Location = new Point(xEmp, yEmp);
            xEmp += 168;
            if (xEmp > 1000)
            {
                xEmp = 20;
                yEmp += 213;
            }
            bEmployees.Last().FlatStyle = FlatStyle.Flat;
            bEmployees.Last().FlatAppearance.BorderSize = 0;
            bEmployees.Last().BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Asset_8_1_77x));
            bEmployees.Last().Click += new EventHandler(EmployeeAdd_Click);
            pEmployee.Controls.Add(bEmployees.Last());
        } 
        private void Employee_Click(object sender, EventArgs e)
        {
            EmployeeInfo form = new EmployeeInfo(Convert.ToInt32(((System.Windows.Forms.Button)sender).Name), access[0]);
            form.ShowDialog();
            updEmployee();
        }
        private void EmployeeAdd_Click(object sender, EventArgs e)
        {
            EmployeeInfo form = new EmployeeInfo( access[0]);
            form.ShowDialog();
            updEmployee();
        }
        private void bTP_close_Click(object sender, EventArgs e)//Form control PART
        {
            this.Close();
            Application.Exit();
        } 
        private void button7_Click(object sender, EventArgs e)
        {
            if (formState)
            {
                this.WindowState = FormWindowState.Maximized;
                formState = false;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                formState = true;
            }
        }
        private void bTP_hide_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion
        #region Department
        private void initDepartments()
        {
            pDepartment.Controls.Clear();           
            lbDepartment.Font = new Font("Verdana", 16, FontStyle.Regular);
            lbDepartment.ForeColor = Color.FromArgb(255, 255, 255, 255);
            lbDepartment.BackColor = Color.FromArgb(255, 29, 29, 29);
            lbDepartment.Location = new Point(40, 50);
            lbDepartment.BorderStyle = BorderStyle.None;
            lbDepartment.Height = 450;
            lbDepartment.Width = 400;
            pDepartment.Controls.Add(lbDepartment);
            lbDepartment.Enabled = false;
            if (access[2])
            {
                lbDepartment.Enabled = true;
                bAddDepartment.Width = 76;
                bAddDepartment.Height = 37;
                bAddDepartment.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Asset_6_1_77x));
                bAddDepartment.Font = new Font("Verdana", 14, FontStyle.Regular);
                bAddDepartment.ForeColor = Color.FromArgb(255, 153, 153, 153);
                bAddDepartment.Text = "add";
                bAddDepartment.TextAlign = ContentAlignment.MiddleCenter;
                bAddDepartment.Location = new Point(500, 100);
                bAddDepartment.FlatAppearance.BorderSize = 0;
                bAddDepartment.FlatStyle = FlatStyle.Flat;
                bAddDepartment.Click += new EventHandler(bAddDepartment_Click);
                pDepartment.Controls.Add(bAddDepartment);
                bRemoveDepartment.Width = 98;
                bRemoveDepartment.Height = 37;
                bRemoveDepartment.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Asset_7_1_77x));
                bRemoveDepartment.Font = new Font("Verdana", 14, FontStyle.Regular);
                bRemoveDepartment.ForeColor = Color.FromArgb(255, 153, 153, 153);
                bRemoveDepartment.Text = "remove";
                bRemoveDepartment.TextAlign = ContentAlignment.MiddleCenter;
                bRemoveDepartment.Location = new Point(586, 100);
                bRemoveDepartment.FlatAppearance.BorderSize = 0;
                bRemoveDepartment.FlatStyle = FlatStyle.Flat;
                bRemoveDepartment.Click += new EventHandler(bRemoveDepartment_Click);
                pDepartment.Controls.Add(bRemoveDepartment);
                bViewDepartment.Width = 76;
                bViewDepartment.Height = 37;
                bViewDepartment.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Asset_6_1_77x));
                bViewDepartment.Font = new Font("Verdana", 14, FontStyle.Regular);
                bViewDepartment.ForeColor = Color.FromArgb(255, 153, 153, 153);
                bViewDepartment.Text = "view";
                bViewDepartment.TextAlign = ContentAlignment.MiddleCenter;
                bViewDepartment.Location = new Point(692, 100);
                bViewDepartment.FlatAppearance.BorderSize = 0;
                bViewDepartment.FlatStyle = FlatStyle.Flat;
                bViewDepartment.Click += new EventHandler(bViewDepartment_Click);
                pDepartment.Controls.Add(bViewDepartment);
                tbAddDepartment.Location = new Point(500, 50);
                tbAddDepartment.BackColor = Color.FromArgb(255, 29, 29, 29);
                tbAddDepartment.Font= new Font("Verdana", 14, FontStyle.Regular);
                tbAddDepartment.ForeColor = Color.FromArgb(255, 255, 255, 255);
                tbAddDepartment.Text = "Enter name";
                tbAddDepartment.BorderStyle = BorderStyle.None;
                tbAddDepartment.Width = 184;
                pDepartment.Controls.Add(tbAddDepartment);
                updDepartments();
            }
        }
        private void updDepartments()
        {
            lbDepartment.Items.Clear();
            List<Departement> deps = Dm.GetDepartments();
            lbDepartment.Items.Add("Departments:");
            foreach (Departement dep in deps)
            {
                lbDepartment.Items.Add("•" + dep.Info());
            }
        }
        private void bViewDepartment_Click(object sender, EventArgs e)
        {
            if (lbDepartment.SelectedIndex > -1)
            {
                DepartmentInfo DI = new DepartmentInfo(lbDepartment.SelectedItem.ToString().Substring(1, lbDepartment.SelectedItem.ToString().LastIndexOf('W') - 2));
                DI.Show();
            }
        }
        #endregion
        #region Schedule
        private void initSchedule(int id)
        {
            string[] week = { "Monday", "Tuesday", "Wednesday", "Thursady", "Friday" };
            int xSch = 20;
            int ySch = 80;
            for(int i = 0; i < 5; i++)
            {
                Label label = new Label();
                label.Font = new Font("Verdana", 20, FontStyle.Regular);
                label.ForeColor = Color.FromArgb(255, 255, 255, 255);
                label.Text = week[i];
                label.Location = new Point(xSch, 30);
                label.Height = 40;
                label.Width = 190;
                label.TextAlign = ContentAlignment.MiddleCenter;
                xSch += 200;
                pSchedule.Controls.Add(label);
            }
            List<WorkDay> schedule = ww.GetWeek();
            xSch = 20;
            for(int i = 0; i < 5; i++)
            {
                int hh = 8;

                for (int j = 0; j < 13; j++)
                {
                    Label label = new Label();
                    label.Font = new Font("Verdana", 20, FontStyle.Regular);
                    try
                    {
                        if (schedule[i].InShift(hh)) label.ForeColor = Color.FromArgb(255, 255, 255, 255);
                        else label.ForeColor = Color.FromArgb(255, 51, 51, 51);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex+"");
                    }
                    label.Text = hh+":00";
                    hh++;
                    label.Location = new Point(xSch, ySch);
                    label.Height = 30;
                    label.Width = 190;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    ySch += 45;
                    pSchedule.Controls.Add(label);
                } 
                ySch = 80;
                xSch += 200;
            }
        }
        #endregion
        #region Stock
       
        private void initStock()
        {
            pStock.HorizontalScroll.Enabled = false;
            pStock.Controls.Clear();
            CreateHeadersStock();
            int[] x = new int[] { 0, 60, 350, 550, 650, 840, 1040 };
            List<Product.Product> prdcts = pm.GetProducts();
            int y=42;
            bool IsBlack =false;
            foreach (Product.Product prdct in prdcts)
            {
                string[] info = prdct.GetInfo();
                if (access[1])
                {
                    //MessageBox.Show("Test");
                    Label lSbstrct = new Label();
                    lSbstrct.Width = 36;
                    lSbstrct.Height = 36;
                    lSbstrct.Name = info[0];
                    lSbstrct.Text = "-";
                    lSbstrct.Font = new Font("Verdana", 13, FontStyle.Regular);
                    lSbstrct.ForeColor = Color.FromArgb(255, 255, 255, 255);
                    if (IsBlack)
                        lSbstrct.BackColor = Color.FromArgb(255, 29, 29, 29);
                    else
                        lSbstrct.BackColor = Color.FromArgb(255, 51, 51, 51);
                    lSbstrct.Location = new Point(780, y);
                    lSbstrct.Click += new EventHandler(bSbstrct_Click);
                    lSbstrct.BringToFront();
                    pStock.Controls.Add(lSbstrct);
                    Label lAdd = new Label();
                    lAdd.Width = 36;
                    lAdd.Height = 36;
                    lAdd.Name = info[0];
                    lAdd.Text = "+";
                    lAdd.Font = new Font("Verdana", 13, FontStyle.Regular);
                    lAdd.ForeColor = Color.FromArgb(255, 255, 255, 255);
                    if (IsBlack)
                        lAdd.BackColor = Color.FromArgb(255, 29, 29, 29);
                    else
                        lAdd.BackColor = Color.FromArgb(255, 51, 51, 51);
                    lAdd.Location = new Point(675, y);
                    lAdd.Click += new EventHandler(bAdd_Click);
                    lAdd.BringToFront();
                    pStock.Controls.Add(lAdd);
                }
                for (int i = 0; i < 6; i++)
                {
                    Label label = new Label();
                    label.Location = new Point(x[i], y);
                    label.Name = info[0];
                    label.Text = info[i];
                    label.Font = new Font("Verdana", 13, FontStyle.Regular);
                    label.ForeColor = Color.FromArgb(255, 255, 255, 255);
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    if (i == 1) label.DoubleClick += new EventHandler(DeleteProduct_DoubleClick);
                    if (IsBlack)
                        label.BackColor = Color.FromArgb(255, 29, 29, 29);
                    else
                        label.BackColor = Color.FromArgb(255, 51, 51, 51);
                    label.Height = 36;
                    label.Width = x[i + 1] - x[i];
                    label.SendToBack();
                    pStock.Controls.Add(label);
                }
                if (IsBlack) IsBlack = false;
                else IsBlack = true;
                y += 36;               
            }
            if (access[1])
            {
                Button button = new Button();
                button.Height = 37;
                button.Width = 76;
                button.Text = "add";
                button.TextAlign = ContentAlignment.MiddleCenter;
                button.Font = new Font("Verdana", 12, FontStyle.Regular);
                button.ForeColor = Color.FromArgb(255, 255, 255, 255);
                button.Location = new Point(400, y+10);
                button.FlatAppearance.BorderSize = 0;
                button.FlatStyle = FlatStyle.Flat;
                button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Asset_6_1_77x));
                button.Click += new EventHandler(bAddProduct_Click);
                pStock.Controls.Add(button);

                bRem.Height = 37;
                bRem.Width = 98;
                bRem.Text = "remove";
                bRem.TextAlign = ContentAlignment.MiddleCenter;
                bRem.Font = new Font("Verdana", 12, FontStyle.Regular);
                bRem.ForeColor = Color.FromArgb(255, 255, 255, 255);
                bRem.Location = new Point(500, y + 10);
                bRem.FlatAppearance.BorderSize = 0;
                bRem.FlatStyle = FlatStyle.Flat;
                bRem.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Asset_7_1_77x));
                bRem.Click += new EventHandler(bRemProduct_Click);
                pStock.Controls.Add(bRem);
            }
        }
        private void CreateHeadersStock()
        {
            string[] info = new string[] { "ID:", "Name:", "Category:", "Price:", "Amount:", "Barcode:" };
            int[] x = new int[] { 0, 60, 350, 550, 650, 840, 1040 };
            for (int i = 0; i < 6; i++)
            {
                Label label = new Label();
                label.Location = new Point(x[i], 0);
                label.Text = info[i];
                label.Font = new Font("Verdana", 16, FontStyle.Regular);
                label.ForeColor = Color.FromArgb(255, 255, 255, 255);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BackColor = Color.FromArgb(255, 29, 29, 29);
                label.Height = 42;
                label.Width = x[i + 1] - x[i];
                pStock.Controls.Add(label);
            }
        }
        private void bAdd_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((System.Windows.Forms.Label)sender).Name);
            int amount = pm.GetAmount(id);
            if (!pm.ChangeAmount(id, amount + 1))
                MessageBox.Show("Connection problem");
            else
                initStock();
        }
        private void bSbstrct_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((System.Windows.Forms.Label)sender).Name);
            int amount = pm.GetAmount(id);
            if (!pm.ChangeAmount(id, amount - 1))
                MessageBox.Show("Can not be less 0!");
            else
                initStock();
        }
        private void bAddProduct_Click(object sender, EventArgs e)
        {
            ProductInfo form = new ProductInfo(access[1]);
            form.ShowDialog();
        }
        private void bRemProduct_Click(object sender, EventArgs e)
        {
            if (isPrdctDeleting)
            {
                isPrdctDeleting = false;
                bRem.Text = "Delete";
            }
            else
            {
                bRem.Text = "Lock";
                isPrdctDeleting = true;
            }
        }
        private void DeleteProduct_DoubleClick(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(((System.Windows.Forms.Label)sender).Name);
            DialogResult dialogResult = MessageBox.Show("Sure", "Delete product", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!pm.DeletePrdct(id))
                    MessageBox.Show("Connection problem");
                else initStock();
            }
        }
        #endregion Stock
        #region Option
        private void initOption()
        {
            Button button = new Button();
            button.Height = 37;
            button.Width = 98;
            button.Text = "log out";
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.Font = new Font("Verdana", 12, FontStyle.Regular);
            button.ForeColor = Color.FromArgb(255, 255, 255, 255);
            button.Location = new Point(20, 40);
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Asset_7_1_77x));
            button.Click += new EventHandler(logOut_Click);
            pOption.Controls.Add(button);
                Button bSetPref = new Button();
            bSetPref.Height = 37;
            bSetPref.Width = 98;
            bSetPref.Text = "set pref";
            bSetPref.TextAlign = ContentAlignment.MiddleCenter;
            bSetPref.Font = new Font("Verdana", 12, FontStyle.Regular);
            bSetPref.ForeColor = Color.FromArgb(255, 255, 255, 255);
            bSetPref.Location = new Point(520, 40);
            bSetPref.FlatAppearance.BorderSize = 0;
            bSetPref.FlatStyle = FlatStyle.Flat;
            bSetPref.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Asset_7_1_77x));
            bSetPref.Click += new EventHandler(bSetPref_Click);
            pOption.Controls.Add(bSetPref);
            if (access[3])
            {
                list.BorderStyle = BorderStyle.FixedSingle;
                list.BackColor = Color.FromArgb(255, 29, 29, 29);
                list.ForeColor = Color.FromArgb(255, 255, 255, 255);
                list.Height = 450;
                list.Width = 300;
                list.Font = new Font("Verdana", 12, FontStyle.Regular);
                list.Location = new Point(180, 40);
                updLBToFire();
                    pOption.Controls.Add(list);
                Button bRemove = new Button();
                bRemove.Height = 37;
                bRemove.Width = 98;
                bRemove.FlatAppearance.BorderSize = 0;
                bRemove.Text = "remove";
                bRemove.TextAlign = ContentAlignment.MiddleCenter;
                bRemove.Font = new Font("Verdana", 12, FontStyle.Regular);
                bRemove.ForeColor = Color.FromArgb(255, 255, 255, 255);
                bRemove.Location = new Point(520, 80);
                bRemove.FlatStyle = FlatStyle.Flat;
                bRemove.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Asset_7_1_77x));
                bRemove.Click += new EventHandler(removeEmp_Click);
                pOption.Controls.Add(bRemove);
                Button undRemove = new Button();
                undRemove.Height = 37;
                undRemove.Width = 98;
                undRemove.FlatAppearance.BorderSize = 0;
                undRemove.Text = "reinstate";
                undRemove.TextAlign = ContentAlignment.MiddleCenter;
                undRemove.Font = new Font("Verdana", 12, FontStyle.Regular);
                undRemove.ForeColor = Color.FromArgb(255, 255, 255, 255);
                undRemove.Location = new Point(520, 120);
                undRemove.FlatStyle = FlatStyle.Flat;
                undRemove.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Asset_7_1_77x));
                undRemove.Click += new EventHandler(undoRemoveEmp_Click);
                pOption.Controls.Add(undRemove);
            }
            if(access[4])
            {
                Button btnScan = new Button();
                btnScan.Height = 37;
                btnScan.Width = 98;
                btnScan.FlatAppearance.BorderSize = 0;
                btnScan.Text = "scanner";
                btnScan.TextAlign = ContentAlignment.MiddleCenter;
                btnScan.Font = new Font("Verdana", 12, FontStyle.Regular);
                btnScan.ForeColor = Color.FromArgb(255, 255, 255, 255);
                btnScan.Location = new Point(520, 80);
                btnScan.FlatStyle = FlatStyle.Flat;
                btnScan.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.Asset_7_1_77x));
                btnScan.Click += new EventHandler(ScanQr_Click);
                pOption.Controls.Add(btnScan);
            }
        }
        private void ScanQr_Click(object sender, EventArgs e)
        {
            ScannerQr scn = new ScannerQr();
            scn.Show();
        }

        private void updLBToFire()
        {
            list.Items.Clear();
            List<Worker> inp = Em.GetEmployees();
            List<string> otp = new List<string>();
            foreach (Worker employee in inp)
                if (!employee.IsWorking()) otp.Add(employee.GetNamePos());
            list.Items.AddRange(otp.ToArray());
        }
        private void bSetPref_Click(object sender, EventArgs e)
        {
            CreatePreference cP = new CreatePreference(user.GetId());
            cP.ShowDialog();
        }
        private void removeEmp_Click(object sender, EventArgs e)
        {
            if (list.SelectedIndex > -1)
            {
                if (MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if(Em.removeEmployeeFinally(list.SelectedItem.ToString()));
                    updLBToFire();
                }
            }
        }
        private void undoRemoveEmp_Click(object sender, EventArgs e)
        {
            if (list.SelectedIndex > -1)
            {
                if (MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (Em.undoRemove(list.SelectedItem.ToString()))
                    {
                        updLBToFire();
                        updEmployee();
                    }
                }
            }
        }
        private void logOut_Click(object sender, EventArgs e)
        {
            Em.Cleaning();
            Dm.Cleaning();
            pm.Cleaning();
            Login login = new Login();
            login.Show();
            this.Close();
        }
        private void bEmployee_Click(object sender, EventArgs e)
        {
            bEmployee.BackColor = Color.FromArgb(255, 153, 153, 153);
            bOption.BackColor = Color.FromArgb(255, 0, 0, 0);
            bSchedule.BackColor = Color.FromArgb(255, 0, 0, 0);
            bStock.BackColor = Color.FromArgb(255, 0, 0, 0);
            bDepartment.BackColor = Color.FromArgb(255, 0, 0, 0);
            EmployeeShow();
            pDepartment.Hide();
            pStock.Hide();
            pSchedule.Hide();
            pOption.Hide();
        }
        private void bAddDepartment_Click(object sender, EventArgs e)
        {
            if(tbAddDepartment.Text!= "Enter name" && tbAddDepartment.Text != "") 
            {
                if(!Dm.AddDepartment(tbAddDepartment.Text)) MessageBox.Show("Something went wrong");
                else tbAddDepartment.Text = "Enter name";
            }
            else MessageBox.Show("Enter department name");
            updDepartments();
        }
        private void bRemoveDepartment_Click(object sender, EventArgs e)
        {
            if (lbDepartment.SelectedIndex > 0) {
                if(MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    if (!Dm.RemoveDepartment(lbDepartment.SelectedItem.ToString().Substring(1, lbDepartment.SelectedItem.ToString().LastIndexOf('W')-2))) MessageBox.Show("Something went wrong");
            }
            else MessageBox.Show("Select department to delete");
            updDepartments();
        }
        #endregion
        private void bStock_Click(object sender, EventArgs e)
        {
            bEmployee.BackColor = Color.FromArgb(255, 0, 0, 0);
            bOption.BackColor = Color.FromArgb(255, 0, 0, 0);
            bSchedule.BackColor = Color.FromArgb(255, 0, 0, 0);
            bStock.BackColor = Color.FromArgb(255, 153, 153, 153);
            bDepartment.BackColor = Color.FromArgb(255, 0, 0, 0);
            EmployeeHide();
            pDepartment.Hide();
            pStock.Show();
            pSchedule.Hide();
            pOption.Hide();
        }

        private void bSchedule_Click(object sender, EventArgs e)
        {
            bEmployee.BackColor = Color.FromArgb(255, 0, 0, 0);
            bOption.BackColor = Color.FromArgb(255, 0, 0, 0);
            bSchedule.BackColor = Color.FromArgb(255, 153, 153, 153);
            bStock.BackColor = Color.FromArgb(255, 0, 0, 0);
            bDepartment.BackColor = Color.FromArgb(255, 0, 0, 0);
            EmployeeHide();
            pDepartment.Hide();
            pStock.Hide();
            pSchedule.Show();
            pOption.Hide();
        }


        private void bDepartment_Click(object sender, EventArgs e)
        {
            bEmployee.BackColor = Color.FromArgb(255, 0, 0, 0);
            bOption.BackColor = Color.FromArgb(255, 0, 0, 0);
            bSchedule.BackColor = Color.FromArgb(255, 0, 0, 0);
            bStock.BackColor = Color.FromArgb(255, 0, 0, 0);
            bDepartment.BackColor = Color.FromArgb(255, 153, 153, 153);
            EmployeeHide();
            updDepartments();
            pDepartment.Show();
            pStock.Hide();
            pSchedule.Hide();
            pOption.Hide();
        }

        private void lblNameAccount_Click(object sender, EventArgs e)
        {
            MailsBox mb = new MailsBox(user);
            mb.ShowDialog();
        }

        private void bOption_Click(object sender, EventArgs e)
        {
            bEmployee.BackColor = Color.FromArgb(255, 0, 0, 0);
            bOption.BackColor = Color.FromArgb(255, 153, 153 ,153);
            bSchedule.BackColor = Color.FromArgb(255, 0, 0, 0);
            bStock.BackColor = Color.FromArgb(255, 0, 0, 0);
            bDepartment.BackColor = Color.FromArgb(255, 0, 0, 0);
            EmployeeHide();
            pDepartment.Hide();
            pStock.Hide();
            pSchedule.Hide();
            pOption.Show();
            updLBToFire();
        }

    }
}
