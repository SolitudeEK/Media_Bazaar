namespace mediabazaar_s2_cb06_1.Employee
{
    partial class PerformanceInfo
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
            this.bClose = new System.Windows.Forms.Button();
            this.pInfo = new System.Windows.Forms.Panel();
            this.bNext = new System.Windows.Forms.Button();
            this.bPrev = new System.Windows.Forms.Button();
            this.lDateInfo = new System.Windows.Forms.Label();
            this.lExpected = new System.Windows.Forms.Label();
            this.lFact = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.Transparent;
            this.bClose.BackgroundImage = global::mediabazaar_s2_cb06_1.Properties.Resources.Asset_5_1_77x;
            this.bClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClose.FlatAppearance.BorderSize = 0;
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.Location = new System.Drawing.Point(917, 12);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(25, 25);
            this.bClose.TabIndex = 16;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // pInfo
            // 
            this.pInfo.BackColor = System.Drawing.Color.Transparent;
            this.pInfo.Location = new System.Drawing.Point(1, 2);
            this.pInfo.Name = "pInfo";
            this.pInfo.Size = new System.Drawing.Size(811, 457);
            this.pInfo.TabIndex = 17;
            // 
            // bNext
            // 
            this.bNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bNext.FlatAppearance.BorderSize = 0;
            this.bNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bNext.Font = new System.Drawing.Font("Verdana", 25F);
            this.bNext.ForeColor = System.Drawing.Color.White;
            this.bNext.Location = new System.Drawing.Point(882, 175);
            this.bNext.Name = "bNext";
            this.bNext.Size = new System.Drawing.Size(50, 50);
            this.bNext.TabIndex = 18;
            this.bNext.Text = ">";
            this.bNext.UseVisualStyleBackColor = true;
            this.bNext.Click += new System.EventHandler(this.bNext_Click);
            // 
            // bPrev
            // 
            this.bPrev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bPrev.FlatAppearance.BorderSize = 0;
            this.bPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bPrev.Font = new System.Drawing.Font("Verdana", 25F);
            this.bPrev.ForeColor = System.Drawing.Color.White;
            this.bPrev.Location = new System.Drawing.Point(826, 175);
            this.bPrev.Name = "bPrev";
            this.bPrev.Size = new System.Drawing.Size(50, 50);
            this.bPrev.TabIndex = 19;
            this.bPrev.Text = "<";
            this.bPrev.UseVisualStyleBackColor = true;
            this.bPrev.Click += new System.EventHandler(this.bPrev_Click);
            // 
            // lDateInfo
            // 
            this.lDateInfo.AutoSize = true;
            this.lDateInfo.Font = new System.Drawing.Font("Verdana", 16F);
            this.lDateInfo.ForeColor = System.Drawing.Color.White;
            this.lDateInfo.Location = new System.Drawing.Point(812, 68);
            this.lDateInfo.Name = "lDateInfo";
            this.lDateInfo.Size = new System.Drawing.Size(110, 52);
            this.lDateInfo.TabIndex = 20;
            this.lDateInfo.Text = "Test";
            this.lDateInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lExpected
            // 
            this.lExpected.AutoSize = true;
            this.lExpected.Font = new System.Drawing.Font("Verdana", 16F);
            this.lExpected.ForeColor = System.Drawing.Color.White;
            this.lExpected.Location = new System.Drawing.Point(811, 281);
            this.lExpected.Name = "lExpected";
            this.lExpected.Size = new System.Drawing.Size(110, 52);
            this.lExpected.TabIndex = 21;
            this.lExpected.Text = "Test";
            this.lExpected.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lFact
            // 
            this.lFact.AutoSize = true;
            this.lFact.Font = new System.Drawing.Font("Verdana", 16F);
            this.lFact.ForeColor = System.Drawing.Color.White;
            this.lFact.Location = new System.Drawing.Point(812, 351);
            this.lFact.Name = "lFact";
            this.lFact.Size = new System.Drawing.Size(110, 52);
            this.lFact.TabIndex = 22;
            this.lFact.Text = "Test";
            this.lFact.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PerformanceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(954, 459);
            this.Controls.Add(this.lFact);
            this.Controls.Add(this.lExpected);
            this.Controls.Add(this.lDateInfo);
            this.Controls.Add(this.bPrev);
            this.Controls.Add(this.bNext);
            this.Controls.Add(this.pInfo);
            this.Controls.Add(this.bClose);
            this.Font = new System.Drawing.Font("Verdana", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PerformanceInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Panel pInfo;
        private System.Windows.Forms.Button bNext;
        private System.Windows.Forms.Button bPrev;
        private System.Windows.Forms.Label lDateInfo;
        private System.Windows.Forms.Label lExpected;
        private System.Windows.Forms.Label lFact;
    }
}