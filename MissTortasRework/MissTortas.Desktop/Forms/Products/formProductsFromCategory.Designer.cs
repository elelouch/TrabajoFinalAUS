namespace MissTortas.Desktop.Forms.Products
{
    partial class formProductsFromCategory
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
            components = new System.ComponentModel.Container();
            tlpProductsFromCategory = new TableLayoutPanel();
            dgvProducts = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descriptionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            quantityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            categoryIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            manageQuantityAsIntegerDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            unitDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Enabled = new DataGridViewCheckBoxColumn();
            productBindingSource = new BindingSource(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            btnAddProduct = new Button();
            btnModifyProduct = new Button();
            btnRefresh = new Button();
            tlpProductsFromCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tlpProductsFromCategory
            // 
            tlpProductsFromCategory.ColumnCount = 3;
            tlpProductsFromCategory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpProductsFromCategory.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpProductsFromCategory.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 112F));
            tlpProductsFromCategory.Controls.Add(dgvProducts, 0, 0);
            tlpProductsFromCategory.Controls.Add(tableLayoutPanel1, 2, 0);
            tlpProductsFromCategory.Dock = DockStyle.Fill;
            tlpProductsFromCategory.Location = new Point(0, 0);
            tlpProductsFromCategory.Name = "tlpProductsFromCategory";
            tlpProductsFromCategory.RowCount = 2;
            tlpProductsFromCategory.RowStyles.Add(new RowStyle(SizeType.Percent, 61.77778F));
            tlpProductsFromCategory.RowStyles.Add(new RowStyle(SizeType.Percent, 38.22222F));
            tlpProductsFromCategory.Size = new Size(800, 450);
            tlpProductsFromCategory.TabIndex = 0;
            // 
            // dgvProducts
            // 
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.AllowUserToDeleteRows = false;
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, descriptionDataGridViewTextBoxColumn, quantityDataGridViewTextBoxColumn, categoryIdDataGridViewTextBoxColumn, manageQuantityAsIntegerDataGridViewCheckBoxColumn, unitDataGridViewTextBoxColumn, Enabled });
            tlpProductsFromCategory.SetColumnSpan(dgvProducts, 2);
            dgvProducts.DataSource = productBindingSource;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(3, 3);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            tlpProductsFromCategory.SetRowSpan(dgvProducts, 2);
            dgvProducts.Size = new Size(682, 444);
            dgvProducts.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            quantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryIdDataGridViewTextBoxColumn
            // 
            categoryIdDataGridViewTextBoxColumn.DataPropertyName = "CategoryId";
            categoryIdDataGridViewTextBoxColumn.HeaderText = "CategoryId";
            categoryIdDataGridViewTextBoxColumn.Name = "categoryIdDataGridViewTextBoxColumn";
            categoryIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // manageQuantityAsIntegerDataGridViewCheckBoxColumn
            // 
            manageQuantityAsIntegerDataGridViewCheckBoxColumn.DataPropertyName = "ManageQuantityAsInteger";
            manageQuantityAsIntegerDataGridViewCheckBoxColumn.HeaderText = "ManageQuantityAsInteger";
            manageQuantityAsIntegerDataGridViewCheckBoxColumn.Name = "manageQuantityAsIntegerDataGridViewCheckBoxColumn";
            manageQuantityAsIntegerDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // unitDataGridViewTextBoxColumn
            // 
            unitDataGridViewTextBoxColumn.DataPropertyName = "Unit";
            unitDataGridViewTextBoxColumn.HeaderText = "Unit";
            unitDataGridViewTextBoxColumn.Name = "unitDataGridViewTextBoxColumn";
            unitDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Enabled
            // 
            Enabled.DataPropertyName = "Enabled";
            Enabled.HeaderText = "Enabled";
            Enabled.Name = "Enabled";
            Enabled.ReadOnly = true;
            // 
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Model.Product);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnAddProduct, 0, 0);
            tableLayoutPanel1.Controls.Add(btnModifyProduct, 0, 1);
            tableLayoutPanel1.Controls.Add(btnRefresh, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(691, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(106, 272);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Dock = DockStyle.Top;
            btnAddProduct.Location = new Point(3, 3);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(100, 23);
            btnAddProduct.TabIndex = 0;
            btnAddProduct.Text = "Add Product";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // btnModifyProduct
            // 
            btnModifyProduct.Dock = DockStyle.Top;
            btnModifyProduct.Location = new Point(3, 32);
            btnModifyProduct.Name = "btnModifyProduct";
            btnModifyProduct.Size = new Size(100, 23);
            btnModifyProduct.TabIndex = 1;
            btnModifyProduct.Text = "Modify Product";
            btnModifyProduct.UseVisualStyleBackColor = true;
            btnModifyProduct.Click += btnModifyProduct_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Dock = DockStyle.Top;
            btnRefresh.Location = new Point(3, 61);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 23);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // formProductsFromCategory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tlpProductsFromCategory);
            Name = "formProductsFromCategory";
            Text = "Products from Category";
            Load += formProductsFromCategory_Load;
            tlpProductsFromCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpProductsFromCategory;
        private DataGridView dgvProducts;
        private BindingSource productBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn categoryIdDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn manageQuantityAsIntegerDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnAddProduct;
        private Button btnModifyProduct;
        private DataGridViewCheckBoxColumn Enabled;
        private Button btnRefresh;
    }
}