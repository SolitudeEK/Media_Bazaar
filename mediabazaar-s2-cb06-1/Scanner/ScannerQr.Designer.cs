namespace mediabazaar_s2_cb06_1.Scanner
{
    partial class ScannerQr
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
            this.components = new System.ComponentModel.Container();
            this.bClose = new System.Windows.Forms.Button();
            this.cbCameras = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.pbVideo = new System.Windows.Forms.PictureBox();
            this.timerCheck = new System.Windows.Forms.Timer(this.components);
            this.lOut = new System.Windows.Forms.Label();
            this.pbPortret = new System.Windows.Forms.PictureBox();
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPortret)).BeginInit();
            this.SuspendLayout();
            // 
            // bClose
            // 
            this.bClose.BackColor = System.Drawing.Color.Transparent;
            this.bClose.BackgroundImage = global::mediabazaar_s2_cb06_1.Properties.Resources.Asset_5_1_77x;
            this.bClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bClose.FlatAppearance.BorderSize = 0;
            this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bClose.Location = new System.Drawing.Point(1886, 23);
            this.bClose.Margin = new System.Windows.Forms.Padding(6);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(50, 48);
            this.bClose.TabIndex = 16;
            this.bClose.UseVisualStyleBackColor = false;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // cbCameras
            // 
            this.cbCameras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cbCameras.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCameras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCameras.Font = new System.Drawing.Font("Verdana", 14F);
            this.cbCameras.ForeColor = System.Drawing.Color.White;
            this.cbCameras.FormattingEnabled = true;
            this.cbCameras.Location = new System.Drawing.Point(384, 41);
            this.cbCameras.Margin = new System.Windows.Forms.Padding(6);
            this.cbCameras.Name = "cbCameras";
            this.cbCameras.Size = new System.Drawing.Size(698, 53);
            this.cbCameras.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 51);
            this.label1.TabIndex = 34;
            this.label1.Text = "Select Camera:";
            // 
            // bStart
            // 
            this.bStart.BackgroundImage = global::mediabazaar_s2_cb06_1.Properties.Resources.Asset_6_1_77x;
            this.bStart.FlatAppearance.BorderSize = 0;
            this.bStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStart.Font = new System.Drawing.Font("Verdana", 14F);
            this.bStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.bStart.Location = new System.Drawing.Point(1126, 41);
            this.bStart.Margin = new System.Windows.Forms.Padding(6);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(152, 71);
            this.bStart.TabIndex = 35;
            this.bStart.Text = "Start";
            this.bStart.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // pbVideo
            // 
            this.pbVideo.Location = new System.Drawing.Point(34, 117);
            this.pbVideo.Margin = new System.Windows.Forms.Padding(6);
            this.pbVideo.Name = "pbVideo";
            this.pbVideo.Size = new System.Drawing.Size(1058, 846);
            this.pbVideo.TabIndex = 37;
            this.pbVideo.TabStop = false;
            // 
            // timerCheck
            // 
            this.timerCheck.Interval = 1000;
            this.timerCheck.Tick += new System.EventHandler(this.timerCheck_Tick);
            // 
            // lOut
            // 
            this.lOut.AutoSize = true;
            this.lOut.BackColor = System.Drawing.Color.Transparent;
            this.lOut.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lOut.ForeColor = System.Drawing.Color.White;
            this.lOut.Location = new System.Drawing.Point(1350, 567);
            this.lOut.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lOut.Name = "lOut";
            this.lOut.Size = new System.Drawing.Size(0, 51);
            this.lOut.TabIndex = 38;
            // 
            // pbPortret
            // 
            this.pbPortret.Location = new System.Drawing.Point(1346, 103);
            this.pbPortret.Name = "pbPortret";
            this.pbPortret.Size = new System.Drawing.Size(400, 400);
            this.pbPortret.TabIndex = 39;
            this.pbPortret.TabStop = false;
            // 
            // timerClear
            // 
            this.timerClear.Interval = 3000;
            this.timerClear.Tick += new System.EventHandler(this.timerClear_Tick);
            // 
            // ScannerQr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1960, 1019);
            this.Controls.Add(this.pbPortret);
            this.Controls.Add(this.lOut);
            this.Controls.Add(this.pbVideo);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCameras);
            this.Controls.Add(this.bClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "ScannerQr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scanner";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScannerQr_FormClosing);
            this.Load += new System.EventHandler(this.ScannerQr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPortret)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.ComboBox cbCameras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.PictureBox pbVideo;
        private System.Windows.Forms.Timer timerCheck;
        private System.Windows.Forms.Label lOut;
        private System.Windows.Forms.PictureBox pbPortret;
        private System.Windows.Forms.Timer timerClear;
    }
}