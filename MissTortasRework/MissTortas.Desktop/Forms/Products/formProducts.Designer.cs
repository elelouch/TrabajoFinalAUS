namespace MissTortas.Desktop.Forms.Products
{
    partial class formProducts
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
            tabStockProducts = new TabControl();
            tabPageStock = new TabPage();
            tabSaleProducts = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnCancel = new Button();
            tabStockProducts.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabStockProducts
            // 
            tabStockProducts.Controls.Add(tabPageStock);
            tabStockProducts.Controls.Add(tabSaleProducts);
            tabStockProducts.HotTrack = true;
            tabStockProducts.Location = new Point(3, 3);
            tabStockProducts.Name = "tabStockProducts";
            tabStockProducts.SelectedIndex = 0;
            tabStockProducts.Size = new Size(794, 382);
            tabStockProducts.TabIndex = 0;
            // 
            // tabPageStock
            // 
            tabPageStock.Location = new Point(4, 23);
            tabPageStock.Name = "tabPageStock";
            tabPageStock.Padding = new Padding(3);
            tabPageStock.Size = new Size(786, 355);
            tabPageStock.TabIndex = 0;
            tabPageStock.Text = "En stock";
            tabPageStock.UseVisualStyleBackColor = true;
            // 
            // tabSaleProducts
            // 
            tabSaleProducts.Location = new Point(4, 24);
            tabSaleProducts.Name = "tabSaleProducts";
            tabSaleProducts.Padding = new Padding(3);
            tabSaleProducts.Size = new Size(786, 354);
            tabSaleProducts.TabIndex = 1;
            tabSaleProducts.Text = "A la venta";
            tabSaleProducts.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tabStockProducts, 0, 0);
            tableLayoutPanel1.Controls.Add(btnCancel, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 92.38095F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.61904764F));
            tableLayoutPanel1.Size = new Size(800, 420);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.Dock = DockStyle.Right;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(722, 391);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 26);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // formProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 420);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "formProducts";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Productos";
            Load += formProducts_Load;
            tabStockProducts.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabStockProducts;
        private TabPage tabPageStock;
        private TabPage tabSaleProducts;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnCancel;
    }
}