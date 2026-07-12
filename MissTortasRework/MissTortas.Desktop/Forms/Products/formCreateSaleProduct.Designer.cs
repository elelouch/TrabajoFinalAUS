namespace MissTortas.Desktop.Forms.Products
{
    partial class formCreateSaleProduct
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
            lblProductName = new Label();
            lblCategory = new Label();
            label4 = new Label();
            comboBoxCategory = new ComboBox();
            txtProductName = new TextBox();
            chkManageQtyAsInteger = new CheckBox();
            txtQuantity = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();
            btnConfirm = new Button();
            btnCancel = new Button();
            txtUnitName = new TextBox();
            lblUnitName = new Label();
            chkEnabled = new CheckBox();
            ofdFiles = new OpenFileDialog();
            openFilesList = new ListBox();
            btnUpload = new Button();
            btnRemove = new Button();
            txtPrice = new TextBox();
            lblPrice = new Label();
            SuspendLayout();
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(254, 29);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(84, 15);
            lblProductName.TabIndex = 0;
            lblProductName.Text = "Product Name";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(254, 106);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(55, 15);
            lblCategory.TabIndex = 1;
            lblCategory.Text = "Category";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(254, 146);
            label4.Name = "label4";
            label4.Size = new Size(53, 15);
            label4.TabIndex = 3;
            label4.Text = "Quantity";
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new Point(345, 103);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new Size(121, 23);
            comboBoxCategory.TabIndex = 2;
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(345, 28);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(119, 23);
            txtProductName.TabIndex = 0;
            // 
            // chkManageQtyAsInteger
            // 
            chkManageQtyAsInteger.AutoSize = true;
            chkManageQtyAsInteger.Location = new Point(334, 268);
            chkManageQtyAsInteger.Name = "chkManageQtyAsInteger";
            chkManageQtyAsInteger.Size = new Size(170, 19);
            chkManageQtyAsInteger.TabIndex = 6;
            chkManageQtyAsInteger.Text = "Manage quantity as integer";
            chkManageQtyAsInteger.UseVisualStyleBackColor = true;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(345, 143);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(121, 23);
            txtQuantity.TabIndex = 3;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(254, 67);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(67, 15);
            lblDescription.TabIndex = 8;
            lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(345, 64);
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(121, 23);
            txtDescription.TabIndex = 1;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(295, 331);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 8;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(429, 331);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtUnitName
            // 
            txtUnitName.Location = new Point(347, 183);
            txtUnitName.Name = "txtUnitName";
            txtUnitName.Size = new Size(119, 23);
            txtUnitName.TabIndex = 4;
            // 
            // lblUnitName
            // 
            lblUnitName.AutoSize = true;
            lblUnitName.Location = new Point(254, 186);
            lblUnitName.Name = "lblUnitName";
            lblUnitName.Size = new Size(64, 15);
            lblUnitName.TabIndex = 13;
            lblUnitName.Text = "Unit Name";
            // 
            // chkEnabled
            // 
            chkEnabled.AutoSize = true;
            chkEnabled.Location = new Point(334, 293);
            chkEnabled.Name = "chkEnabled";
            chkEnabled.Size = new Size(61, 19);
            chkEnabled.TabIndex = 7;
            chkEnabled.Text = "Enable";
            chkEnabled.UseVisualStyleBackColor = true;
            // 
            // ofdFiles
            // 
            ofdFiles.FileName = "saleFiles";
            // 
            // openFilesList
            // 
            openFilesList.FormattingEnabled = true;
            openFilesList.Location = new Point(606, 41);
            openFilesList.Name = "openFilesList";
            openFilesList.Size = new Size(147, 229);
            openFilesList.TabIndex = 14;
            // 
            // btnUpload
            // 
            btnUpload.Location = new Point(606, 277);
            btnUpload.Name = "btnUpload";
            btnUpload.Size = new Size(75, 23);
            btnUpload.TabIndex = 10;
            btnUpload.Text = "Upload";
            btnUpload.UseVisualStyleBackColor = true;
            btnUpload.Click += btnUpload_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(678, 277);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 11;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(347, 229);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(119, 23);
            txtPrice.TabIndex = 5;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(254, 237);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(33, 15);
            lblPrice.TabIndex = 18;
            lblPrice.Text = "Price";
            // 
            // formCreateSaleProduct
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 450);
            Controls.Add(lblPrice);
            Controls.Add(txtPrice);
            Controls.Add(btnRemove);
            Controls.Add(btnUpload);
            Controls.Add(openFilesList);
            Controls.Add(chkEnabled);
            Controls.Add(lblUnitName);
            Controls.Add(txtUnitName);
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(txtDescription);
            Controls.Add(lblDescription);
            Controls.Add(txtQuantity);
            Controls.Add(chkManageQtyAsInteger);
            Controls.Add(txtProductName);
            Controls.Add(comboBoxCategory);
            Controls.Add(label4);
            Controls.Add(lblCategory);
            Controls.Add(lblProductName);
            Name = "formCreateSaleProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Product";
            Load += formCreateStockProduct_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProductName;
        private Label lblCategory;
        private Label label4;
        private ComboBox comboBoxCategory;
        private TextBox txtProductName;
        private CheckBox chkManageQtyAsInteger;
        private TextBox txtQuantity;
        private Label lblDescription;
        private TextBox txtDescription;
        private Button btnConfirm;
        private Button btnCancel;
        private TextBox txtUnitName;
        private Label lblUnitName;
        private CheckBox chkEnabled;
        private OpenFileDialog ofdFiles;
        private ListBox openFilesList;
        private Button btnUpload;
        private Button btnRemove;
        private TextBox txtPrice;
        private Label lblPrice;
    }
}