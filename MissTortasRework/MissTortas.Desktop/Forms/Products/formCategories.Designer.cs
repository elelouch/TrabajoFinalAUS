namespace MissTortas.Desktop.Forms.Products
{
    partial class formCategories
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnAddChild = new Button();
            btnCancel = new Button();
            btnRemove = new Button();
            btnModifyCategory = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tvCategories
            // 
            tvCategories.Dock = DockStyle.Fill;
            tvCategories.Location = new Point(3, 3);
            tvCategories.Name = "tvCategories";
            tableLayoutPanel1.SetRowSpan(tvCategories, 2);
            tvCategories.Size = new Size(394, 444);
            tvCategories.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tvCategories, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnAddChild, 0, 0);
            tableLayoutPanel2.Controls.Add(btnRemove, 0, 1);
            tableLayoutPanel2.Controls.Add(btnCancel, 0, 3);
            tableLayoutPanel2.Controls.Add(btnModifyCategory, 0, 2);
            tableLayoutPanel2.Location = new Point(403, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Size = new Size(394, 219);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // btnAddChild
            // 
            btnAddChild.Location = new Point(3, 3);
            btnAddChild.Name = "btnAddChild";
            btnAddChild.Size = new Size(75, 23);
            btnAddChild.TabIndex = 0;
            btnAddChild.Text = "Add Child";
            btnAddChild.UseVisualStyleBackColor = true;
            btnAddChild.Click += btnAddChild_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(3, 165);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(3, 57);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(75, 23);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnModifyCategory
            // 
            btnModifyCategory.Location = new Point(3, 111);
            btnModifyCategory.Name = "btnModifyCategory";
            btnModifyCategory.Size = new Size(75, 23);
            btnModifyCategory.TabIndex = 4;
            btnModifyCategory.Text = "Modify";
            btnModifyCategory.UseVisualStyleBackColor = true;
            btnModifyCategory.Click += btnModifyCategory_Click;
            // 
            // formCategories
            // 
            AcceptButton = btnAddChild;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "formCategories";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Categories";
            WindowState = FormWindowState.Maximized;
            Load += formCategories_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TreeView tvCategories;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnAddChild;
        private Button btnCancel;
        private Button btnRemove;
        private Button btnModifyCategory;
    }
}