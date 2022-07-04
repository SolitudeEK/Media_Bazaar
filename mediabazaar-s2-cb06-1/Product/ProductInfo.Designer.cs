
namespace mediabazaar_s2_cb06_1.Product
{
    partial class ProductInfo
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
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.lblProductCategory = new System.Windows.Forms.Label();
            this.cbProductCategory = new System.Windows.Forms.ComboBox();
            this.lblBarcode = new System.Windows.Forms.Label();
            this.tbBarcode = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.lblStockAmount = new System.Windows.Forms.Label();
            this.tbStockAmount = new System.Windows.Forms.TextBox();
            this.bProductSave = new System.Windows.Forms.Button();
            this.bProductRemove = new System.Windows.Forms.Button();
            this.bProductClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbProductName
            // 
            this.tbProductName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tbProductName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbProductName.Font = new System.Drawing.Font("Verdana", 16F);
            this.tbProductName.ForeColor = System.Drawing.Color.DarkGray;
            this.tbProductName.Location = new System.Drawing.Point(31, 24);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(160, 52);
            this.tbProductName.TabIndex = 0;
            this.tbProductName.Text = "Product Name";
            // 
            // lblProductCategory
            // 
            this.lblProductCategory.AutoSize = true;
            this.lblProductCategory.BackColor = System.Drawing.Color.Transparent;
            this.lblProductCategory.Font = new System.Drawing.Font("Verdana", 15.75F);
            this.lblProductCategory.ForeColor = System.Drawing.Color.White;
            this.lblProductCategory.Location = new System.Drawing.Point(26, 79);
            this.lblProductCategory.Name = "lblProductCategory";
            this.lblProductCategory.Size = new System.Drawing.Size(231, 51);
            this.lblProductCategory.TabIndex = 1;
            this.lblProductCategory.Text = "Category:";
            // 
            // cbProductCategory
            // 
            this.cbProductCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.cbProductCategory.Font = new System.Drawing.Font("Verdana", 14F);
            this.cbProductCategory.ForeColor = System.Drawing.Color.White;
            this.cbProductCategory.FormattingEnabled = true;
            this.cbProductCategory.Items.AddRange(new object[] {
            "Smartphones",
            "Graphic Card",
            "Televisions",
            "Computers",
            "Laptops",
            "Headphones"});
            this.cbProductCategory.Location = new System.Drawing.Point(223, 78);
            this.cbProductCategory.Name = "cbProductCategory";
            this.cbProductCategory.Size = new System.Drawing.Size(220, 53);
            this.cbProductCategory.TabIndex = 2;
            // 
            // lblBarcode
            // 
            this.lblBarcode.AutoSize = true;
            this.lblBarcode.BackColor = System.Drawing.Color.Transparent;
            this.lblBarcode.Font = new System.Drawing.Font("Verdana", 15.75F);
            this.lblBarcode.ForeColor = System.Drawing.Color.White;
            this.lblBarcode.Location = new System.Drawing.Point(26, 129);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(211, 51);
            this.lblBarcode.TabIndex = 3;
            this.lblBarcode.Text = "Barcode:";
            // 
            // tbBarcode
            // 
            this.tbBarcode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tbBarcode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbBarcode.ForeColor = System.Drawing.Color.LightGray;
            this.tbBarcode.Location = new System.Drawing.Point(223, 129);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.Size = new System.Drawing.Size(220, 49);
            this.tbBarcode.TabIndex = 4;
            this.tbBarcode.Text = "Enter barcode";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.BackColor = System.Drawing.Color.Transparent;
            this.lblPrice.Font = new System.Drawing.Font("Verdana", 15.75F);
            this.lblPrice.ForeColor = System.Drawing.Color.White;
            this.lblPrice.Location = new System.Drawing.Point(26, 179);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(223, 51);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "Price (€):";
            // 
            // tbPrice
            // 
            this.tbPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tbPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbPrice.ForeColor = System.Drawing.Color.LightGray;
            this.tbPrice.Location = new System.Drawing.Point(223, 179);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(220, 49);
            this.tbPrice.TabIndex = 6;
            this.tbPrice.Text = "0.00";
            // 
            // lblStockAmount
            // 
            this.lblStockAmount.AutoSize = true;
            this.lblStockAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblStockAmount.Font = new System.Drawing.Font("Verdana", 15.75F);
            this.lblStockAmount.ForeColor = System.Drawing.Color.White;
            this.lblStockAmount.Location = new System.Drawing.Point(26, 229);
            this.lblStockAmount.Name = "lblStockAmount";
            this.lblStockAmount.Size = new System.Drawing.Size(387, 51);
            this.lblStockAmount.TabIndex = 7;
            this.lblStockAmount.Text = "Amount in stock:";
            // 
            // tbStockAmount
            // 
            this.tbStockAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.tbStockAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbStockAmount.ForeColor = System.Drawing.Color.LightGray;
            this.tbStockAmount.Location = new System.Drawing.Point(223, 229);
            this.tbStockAmount.Name = "tbStockAmount";
            this.tbStockAmount.Size = new System.Drawing.Size(220, 49);
            this.tbStockAmount.TabIndex = 8;
            this.tbStockAmount.Text = "Enter a number";
            // 
            // bProductSave
            // 
            this.bProductSave.BackgroundImage = global::mediabazaar_s2_cb06_1.Properties.Resources.Asset_6_1_77x;
            this.bProductSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bProductSave.Font = new System.Drawing.Font("Verdana", 14F);
            this.bProductSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.bProductSave.Location = new System.Drawing.Point(579, 392);
            this.bProductSave.Name = "bProductSave";
            this.bProductSave.Size = new System.Drawing.Size(76, 37);
            this.bProductSave.TabIndex = 9;
            this.bProductSave.Text = "save";
            this.bProductSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bProductSave.UseVisualStyleBackColor = true;
            this.bProductSave.Click += new System.EventHandler(this.bProductSave_Click);
            // 
            // bProductRemove
            // 
            this.bProductRemove.BackgroundImage = global::mediabazaar_s2_cb06_1.Properties.Resources.Asset_7_1_77x;
            this.bProductRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bProductRemove.Font = new System.Drawing.Font("Verdana", 14F);
            this.bProductRemove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.bProductRemove.Location = new System.Drawing.Point(661, 392);
            this.bProductRemove.Name = "bProductRemove";
            this.bProductRemove.Size = new System.Drawing.Size(98, 37);
            this.bProductRemove.TabIndex = 10;
            this.bProductRemove.Text = "remove";
            this.bProductRemove.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bProductRemove.UseVisualStyleBackColor = true;
            // 
            // bProductClose
            // 
            this.bProductClose.BackColor = System.Drawing.Color.Transparent;
            this.bProductClose.BackgroundImage = global::mediabazaar_s2_cb06_1.Properties.Resources.Asset_5_1_77x;
            this.bProductClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bProductClose.FlatAppearance.BorderSize = 0;
            this.bProductClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bProductClose.Location = new System.Drawing.Point(763, 12);
            this.bProductClose.Name = "bProductClose";
            this.bProductClose.Size = new System.Drawing.Size(25, 25);
            this.bProductClose.TabIndex = 11;
            this.bProductClose.Text = "button1";
            this.bProductClose.UseVisualStyleBackColor = false;
            this.bProductClose.Click += new System.EventHandler(this.bProductClose_Click);
            // 
            // ProductInfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bProductClose);
            this.Controls.Add(this.bProductRemove);
            this.Controls.Add(this.bProductSave);
            this.Controls.Add(this.tbStockAmount);
            this.Controls.Add(this.lblStockAmount);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.tbBarcode);
            this.Controls.Add(this.lblBarcode);
            this.Controls.Add(this.cbProductCategory);
            this.Controls.Add(this.lblProductCategory);
            this.Controls.Add(this.tbProductName);
            this.Font = new System.Drawing.Font("Verdana", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductInfo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.Label lblProductCategory;
        private System.Windows.Forms.ComboBox cbProductCategory;
        private System.Windows.Forms.Label lblBarcode;
        private System.Windows.Forms.TextBox tbBarcode;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label lblStockAmount;
        private System.Windows.Forms.TextBox tbStockAmount;
        private System.Windows.Forms.Button bProductSave;
        private System.Windows.Forms.Button bProductRemove;
        private System.Windows.Forms.Button bProductClose;
    }
}