namespace MissTortas.Desktop.Forms.Products
{
    partial class formSaleProductsFromCategory
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
            saleProductBindingSource = new BindingSource(components);
            tableLayoutPanel1 = new TableLayoutPanel();
            btnAddProduct = new Button();
            btnModifyProduct = new Button();
            productBindingSource = new BindingSource(components);
            StockProductId = new DataGridViewTextBoxColumn();
            Id = new DataGridViewTextBoxColumn();
            Name = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            CategoryId = new DataGridViewTextBoxColumn();
            ManageQuantityAsInteger = new DataGridViewCheckBoxColumn();
            Unit = new DataGridViewTextBoxColumn();
            Enabled = new DataGridViewCheckBoxColumn();
            tlpProductsFromCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)saleProductBindingSource).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productBindingSource).BeginInit();
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
            dgvProducts.Columns.AddRange(new DataGridViewColumn[] { StockProductId, Id, Name, Description, Quantity, CategoryId, ManageQuantityAsInteger, Unit, Enabled });
            tlpProductsFromCategory.SetColumnSpan(dgvProducts, 2);
            dgvProducts.DataSource = saleProductBindingSource;
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.Location = new Point(3, 3);
            dgvProducts.Name = "dgvProducts";
            dgvProducts.ReadOnly = true;
            tlpProductsFromCategory.SetRowSpan(dgvProducts, 2);
            dgvProducts.Size = new Size(682, 444);
            dgvProducts.TabIndex = 0;
            // 
            // saleProductBindingSource
            // 
            saleProductBindingSource.DataSource = typeof(Model.SaleProduct);
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnAddProduct, 0, 0);
            tableLayoutPanel1.Controls.Add(btnModifyProduct, 0, 1);
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
            // productBindingSource
            // 
            productBindingSource.DataSource = typeof(Model.Product);
            // 
            // StockProductId
            // 
            StockProductId.DataPropertyName = "StockProductId";
            StockProductId.HeaderText = "StockProductId";
            StockProductId.Name = "StockProductId";
            StockProductId.ReadOnly = true;
            // 
            // Id
            // 
            Id.DataPropertyName = "Id";
            Id.HeaderText = "Id";
            Id.Name = "Id";
            Id.ReadOnly = true;
            // 
            // Name
            // 
            Name.DataPropertyName = "Name";
            Name.HeaderText = "Name";
            Name.Name = "Name";
            Name.ReadOnly = true;
            // 
            // Description
            // 
            Description.DataPropertyName = "Description";
            Description.HeaderText = "Description";
            Description.Name = "Description";
            Description.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.DataPropertyName = "Quantity";
            Quantity.HeaderText = "Quantity";
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // CategoryId
            // 
            CategoryId.DataPropertyName = "CategoryId";
            CategoryId.HeaderText = "CategoryId";
            CategoryId.Name = "CategoryId";
            CategoryId.ReadOnly = true;
            // 
            // ManageQuantityAsInteger
            // 
            ManageQuantityAsInteger.DataPropertyName = "ManageQuantityAsInteger";
            ManageQuantityAsInteger.HeaderText = "ManageQuantityAsInteger";
            ManageQuantityAsInteger.Name = "ManageQuantityAsInteger";
            ManageQuantityAsInteger.ReadOnly = true;
            // 
            // Unit
            // 
            Unit.DataPropertyName = "Unit";
            Unit.HeaderText = "Unit";
            Unit.Name = "Unit";
            Unit.ReadOnly = true;
            // 
            // Enabled
            // 
            Enabled.DataPropertyName = "Enabled";
            Enabled.HeaderText = "Enabled";
            Enabled.Name = "Enabled";
            Enabled.ReadOnly = true;
            // 
            // formSaleProductsFromCategory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tlpProductsFromCategory);
            Text = "Sale Products";
            Load += formProductsFromCategory_Load;
            tlpProductsFromCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
            ((System.ComponentModel.ISupportInitialize)saleProductBindingSource).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)productBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpProductsFromCategory;
        private DataGridView dgvProducts;
        private BindingSource productBindingSource;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnAddProduct;
        private Button btnModifyProduct;
        private BindingSource saleProductBindingSource;
        private DataGridViewTextBoxColumn StockProductId;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn CategoryId;
        private DataGridViewCheckBoxColumn ManageQuantityAsInteger;
        private DataGridViewTextBoxColumn Unit;
        private DataGridViewCheckBoxColumn Enabled;
    }
}