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
            tabStockProducts.SuspendLayout();
            SuspendLayout();
            // 
            // tabStockProducts
            // 
            tabStockProducts.Controls.Add(tabPageStock);
            tabStockProducts.Controls.Add(tabSaleProducts);
            tabStockProducts.Dock = DockStyle.Fill;
            tabStockProducts.Location = new Point(0, 0);
            tabStockProducts.Name = "tabStockProducts";
            tabStockProducts.SelectedIndex = 0;
            tabStockProducts.Size = new Size(800, 420);
            tabStockProducts.TabIndex = 0;
            // 
            // tabPageStock
            // 
            tabPageStock.Location = new Point(4, 23);
            tabPageStock.Name = "tabPageStock";
            tabPageStock.Padding = new Padding(3);
            tabPageStock.Size = new Size(792, 393);
            tabPageStock.TabIndex = 0;
            tabPageStock.Text = "En stock";
            tabPageStock.UseVisualStyleBackColor = true;
            // 
            // tabSaleProducts
            // 
            tabSaleProducts.Location = new Point(4, 23);
            tabSaleProducts.Name = "tabSaleProducts";
            tabSaleProducts.Padding = new Padding(3);
            tabSaleProducts.Size = new Size(792, 393);
            tabSaleProducts.TabIndex = 1;
            tabSaleProducts.Text = "A la venta";
            tabSaleProducts.UseVisualStyleBackColor = true;
            // 
            // formProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 420);
            Controls.Add(tabStockProducts);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "formProducts";
            Text = "Productos";
            Load += formProducts_Load;
            tabStockProducts.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabStockProducts;
        private TabPage tabPageStock;
        private TabPage tabSaleProducts;
    }
}