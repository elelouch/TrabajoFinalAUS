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
            panel1 = new Panel();
            btnCancel = new Button();
            btnModifyCategory = new Button();
            btnUnselect = new Button();
            btnCreateCategory = new Button();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tvCategories
            // 
            tvCategories.BackColor = SystemColors.Window;
            tvCategories.BorderStyle = BorderStyle.None;
            tvCategories.Dock = DockStyle.Fill;
            tvCategories.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tvCategories.ForeColor = SystemColors.Window;
            tvCategories.FullRowSelect = true;
            tvCategories.Location = new Point(3, 3);
            tvCategories.Name = "tvCategories";
            tvCategories.Size = new Size(542, 462);
            tvCategories.TabIndex = 0;
            tvCategories.NodeMouseClick += tvCategories_NodeMouseClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.2636F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.7363968F));
            tableLayoutPanel1.Controls.Add(tvCategories, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(827, 468);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnModifyCategory);
            panel1.Controls.Add(btnUnselect);
            panel1.Controls.Add(btnCreateCategory);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(551, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(273, 462);
            panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(3, 116);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(148, 31);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnModifyCategory
            // 
            btnModifyCategory.Location = new Point(3, 79);
            btnModifyCategory.Name = "btnModifyCategory";
            btnModifyCategory.Size = new Size(148, 31);
            btnModifyCategory.TabIndex = 2;
            btnModifyCategory.Text = "Modificar Categoria";
            btnModifyCategory.UseVisualStyleBackColor = true;
            btnModifyCategory.Click += btnModifyCategory_Click;
            // 
            // btnUnselect
            // 
            btnUnselect.Location = new Point(3, 42);
            btnUnselect.Name = "btnUnselect";
            btnUnselect.Size = new Size(148, 31);
            btnUnselect.TabIndex = 1;
            btnUnselect.Text = "Deseleccionar Categoria";
            btnUnselect.UseVisualStyleBackColor = true;
            btnUnselect.Click += btnDeseleccionar_Click;
            // 
            // btnCreateCategory
            // 
            btnCreateCategory.Location = new Point(0, 3);
            btnCreateCategory.Name = "btnCreateCategory";
            btnCreateCategory.Size = new Size(151, 33);
            btnCreateCategory.TabIndex = 0;
            btnCreateCategory.Text = "Crear Categoria";
            btnCreateCategory.UseVisualStyleBackColor = true;
            btnCreateCategory.Click += btnAddChild_Click;
            // 
            // formCategories
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            CancelButton = btnCancel;
            ClientSize = new Size(827, 468);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "formCategories";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Categories";
            WindowState = FormWindowState.Maximized;
            Load += formCategories_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TreeView tvCategories;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Button button1;
        private Button btnDeseleccionar;
        private Button button2;
        private Button button3;
        private Button btnCreateCategory;
        private Button btnUnselect;
        private Button btnModifyCategory;
        private Button btnCancel;
    }
}