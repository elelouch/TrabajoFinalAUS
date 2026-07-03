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
            tvCategories = new TreeView();
            SuspendLayout();
            // 
            // tvCategories
            // 
            tvCategories.Location = new Point(12, 12);
            tvCategories.Name = "tvCategories";
            tvCategories.Size = new Size(376, 410);
            tvCategories.TabIndex = 0;
            // 
            // formProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tvCategories);
            Name = "formProducts";
            Text = "Products";
            Load += formProducts_Load;
            ResumeLayout(false);
        }

        #endregion

        private TreeView tvCategories;
    }
}