namespace mediabazaar_s2_cb06_1.Department
{
    partial class DepartmentInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentInfo));
            this.bClose = new System.Windows.Forms.Button();
            this.tbMaxHour = new System.Windows.Forms.TextBox();
            this.tbNumPpl = new System.Windows.Forms.TextBox();
            this.tbMiniShop = new System.Windows.Forms.TextBox();
            this.bCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.Transparent;
            this.bClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bClose.BackgroundImage")));
            this.bClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClose.FlatAppearance.BorderSize = 0;
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.Location = new System.Drawing.Point(1043, 21);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(25, 25);
            this.bClose.TabIndex = 17;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // tbMaxHour
            // 
            this.tbMaxHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tbMaxHour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMaxHour.Font = new System.Drawing.Font("Verdana", 13F);
            this.tbMaxHour.ForeColor = System.Drawing.Color.White;
            this.tbMaxHour.Location = new System.Drawing.Point(941, 98);
            this.tbMaxHour.Name = "tbMaxHour";
            this.tbMaxHour.Size = new System.Drawing.Size(125, 50);
            this.tbMaxHour.TabIndex = 18;
            // 
            // tbNumPpl
            // 
            this.tbNumPpl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tbNumPpl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbNumPpl.Font = new System.Drawing.Font("Verdana", 13F);
            this.tbNumPpl.ForeColor = System.Drawing.Color.White;
            this.tbNumPpl.Location = new System.Drawing.Point(941, 198);
            this.tbNumPpl.Name = "tbNumPpl";
            this.tbNumPpl.Size = new System.Drawing.Size(125, 50);
            this.tbNumPpl.TabIndex = 19;
            // 
            // tbMiniShop
            // 
            this.tbMiniShop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tbMiniShop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMiniShop.Font = new System.Drawing.Font("Verdana", 13F);
            this.tbMiniShop.ForeColor = System.Drawing.Color.White;
            this.tbMiniShop.Location = new System.Drawing.Point(942, 320);
            this.tbMiniShop.Name = "tbMiniShop";
            this.tbMiniShop.Size = new System.Drawing.Size(125, 50);
            this.tbMiniShop.TabIndex = 20;
            // 
            // bCreate
            // 
            this.bCreate.BackgroundImage = global::mediabazaar_s2_cb06_1.Properties.Resources.Asset_7_1_77x;
            this.bCreate.FlatAppearance.BorderSize = 0;
            this.bCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCreate.Font = new System.Drawing.Font("Verdana", 14F);
            this.bCreate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.bCreate.Location = new System.Drawing.Point(944, 481);
            this.bCreate.Name = "bCreate";
            this.bCreate.Size = new System.Drawing.Size(98, 37);
            this.bCreate.TabIndex = 29;
            this.bCreate.Text = "create";
            this.bCreate.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bCreate.UseVisualStyleBackColor = true;
            this.bCreate.Click += new System.EventHandler(this.bCreate_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 14F);
            this.label1.Location = new System.Drawing.Point(930, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 45);
            this.label1.TabIndex = 30;
            this.label1.Text = "Max hour one day";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 14F);
            this.label2.Location = new System.Drawing.Point(920, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 60);
            this.label2.TabIndex = 31;
            this.label2.Text = "Number of employee";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 14F);
            this.label3.Location = new System.Drawing.Point(930, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 60);
            this.label3.TabIndex = 32;
            this.label3.Text = "Min of workers in shop";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DepartmentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(25F, 48F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1080, 530);
            this.Controls.Add(this.tbNumPpl);
            this.Controls.Add(this.tbMiniShop);
            this.Controls.Add(this.tbMaxHour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bCreate);
            this.Controls.Add(this.bClose);
            this.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "DepartmentInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DepartmentInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.TextBox tbMaxHour;
        private System.Windows.Forms.TextBox tbNumPpl;
        private System.Windows.Forms.TextBox tbMiniShop;
        private System.Windows.Forms.Button bCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}