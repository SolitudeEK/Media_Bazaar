namespace mediabazaar_s2_cb06_1.MailBox
{
    partial class MailsBox
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
            this.pTop = new System.Windows.Forms.Panel();
            this.lblNameAccount = new System.Windows.Forms.Label();
            this.tbMail = new System.Windows.Forms.TextBox();
            this.bSend = new System.Windows.Forms.Button();
            this.cbPeople = new System.Windows.Forms.ComboBox();
            this.pMails = new System.Windows.Forms.Panel();
            this.bTP_close = new System.Windows.Forms.Button();
            this.pTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pTop
            // 
            this.pTop.BackColor = System.Drawing.Color.Black;
            this.pTop.Controls.Add(this.bTP_close);
            this.pTop.Controls.Add(this.lblNameAccount);
            this.pTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTop.Location = new System.Drawing.Point(0, 0);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(980, 34);
            this.pTop.TabIndex = 0;
            // 
            // lblNameAccount
            // 
            this.lblNameAccount.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblNameAccount.Font = new System.Drawing.Font("Verdana", 10F);
            this.lblNameAccount.ForeColor = System.Drawing.Color.White;
            this.lblNameAccount.Location = new System.Drawing.Point(768, 0);
            this.lblNameAccount.Name = "lblNameAccount";
            this.lblNameAccount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNameAccount.Size = new System.Drawing.Size(200, 30);
            this.lblNameAccount.TabIndex = 6;
            this.lblNameAccount.Text = "123";
            this.lblNameAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbMail
            // 
            this.tbMail.Font = new System.Drawing.Font("Verdana", 10F);
            this.tbMail.Location = new System.Drawing.Point(182, 477);
            this.tbMail.Name = "tbMail";
            this.tbMail.Size = new System.Drawing.Size(673, 40);
            this.tbMail.TabIndex = 1;
            // 
            // bSend
            // 
            this.bSend.BackgroundImage = global::mediabazaar_s2_cb06_1.Properties.Resources.Asset_6_1_77x;
            this.bSend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bSend.FlatAppearance.BorderSize = 0;
            this.bSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSend.Font = new System.Drawing.Font("Verdana", 8F);
            this.bSend.ForeColor = System.Drawing.Color.White;
            this.bSend.Location = new System.Drawing.Point(878, 477);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(78, 37);
            this.bSend.TabIndex = 2;
            this.bSend.Text = "Send";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // cbPeople
            // 
            this.cbPeople.Font = new System.Drawing.Font("Verdana", 10F);
            this.cbPeople.FormattingEnabled = true;
            this.cbPeople.Location = new System.Drawing.Point(28, 477);
            this.cbPeople.Name = "cbPeople";
            this.cbPeople.Size = new System.Drawing.Size(138, 40);
            this.cbPeople.TabIndex = 3;
            // 
            // pMails
            // 
            this.pMails.AutoScroll = true;
            this.pMails.Dock = System.Windows.Forms.DockStyle.Top;
            this.pMails.Location = new System.Drawing.Point(0, 34);
            this.pMails.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.pMails.Name = "pMails";
            this.pMails.Size = new System.Drawing.Size(980, 400);
            this.pMails.TabIndex = 4;
            // 
            // bTP_close
            // 
            this.bTP_close.BackgroundImage = global::mediabazaar_s2_cb06_1.Properties.Resources.Asset_3_1_77x;
            this.bTP_close.FlatAppearance.BorderSize = 0;
            this.bTP_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bTP_close.Location = new System.Drawing.Point(15, 10);
            this.bTP_close.Margin = new System.Windows.Forms.Padding(6);
            this.bTP_close.Name = "bTP_close";
            this.bTP_close.Size = new System.Drawing.Size(18, 18);
            this.bTP_close.TabIndex = 5;
            this.bTP_close.UseVisualStyleBackColor = true;
            this.bTP_close.Click += new System.EventHandler(this.bTP_close_Click);
            // 
            // MailsBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(20F, 38F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(980, 530);
            this.Controls.Add(this.pMails);
            this.Controls.Add(this.cbPeople);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.tbMail);
            this.Controls.Add(this.pTop);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MailsBox";
            this.Text = "MailBox";
            this.pTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pTop;
        private System.Windows.Forms.Label lblNameAccount;
        private System.Windows.Forms.TextBox tbMail;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.ComboBox cbPeople;
        private System.Windows.Forms.Panel pMails;
        private System.Windows.Forms.Button bTP_close;
    }
}