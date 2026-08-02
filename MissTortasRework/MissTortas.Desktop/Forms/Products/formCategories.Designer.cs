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
            btnRefresh = new Button();
            btnCancel = new Button();
            btnModifyCategory = new Button();
            btnUnselect = new Button();
            btnCreateCategory = new Button();
            panel2 = new Panel();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // tvCategories
            // 
            tvCategories.BackColor = SystemColors.Window;
            tvCategories.BorderStyle = BorderStyle.None;
            tvCategories.Cursor = Cursors.Hand;
            tvCategories.Dock = DockStyle.Fill;
            tvCategories.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tvCategories.ForeColor = SystemColors.Window;
            tvCategories.FullRowSelect = true;
            tvCategories.Indent = 25;
            tvCategories.Location = new Point(3, 46);
            tvCategories.Name = "tvCategories";
            tvCategories.Size = new Size(578, 388);
            tvCategories.TabIndex = 0;
            tvCategories.NodeMouseClick += tvCategories_NodeMouseClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.7376F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.262394F));
            tableLayoutPanel1.Controls.Add(tvCategories, 0, 1);
            tableLayoutPanel1.Controls.Add(panel1, 1, 1);
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.Size = new Size(827, 437);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnModifyCategory);
            panel1.Controls.Add(btnUnselect);
            panel1.Controls.Add(btnCreateCategory);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(587, 46);
            panel1.Name = "panel1";
            panel1.Size = new Size(237, 388);
            panel1.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ControlLightLight;
            btnRefresh.Dock = DockStyle.Top;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Location = new Point(0, 99);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(237, 35);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refrescar";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.Dock = DockStyle.Bottom;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(0, 359);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(237, 29);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnModifyCategory
            // 
            btnModifyCategory.BackColor = SystemColors.ControlLightLight;
            btnModifyCategory.Dock = DockStyle.Top;
            btnModifyCategory.FlatStyle = FlatStyle.Flat;
            btnModifyCategory.Location = new Point(0, 66);
            btnModifyCategory.Name = "btnModifyCategory";
            btnModifyCategory.Size = new Size(237, 33);
            btnModifyCategory.TabIndex = 2;
            btnModifyCategory.Text = "Modificar categoria";
            btnModifyCategory.UseVisualStyleBackColor = false;
            btnModifyCategory.Click += btnModifyCategory_Click;
            // 
            // btnUnselect
            // 
            btnUnselect.BackColor = SystemColors.ControlLightLight;
            btnUnselect.Dock = DockStyle.Top;
            btnUnselect.FlatStyle = FlatStyle.Flat;
            btnUnselect.Location = new Point(0, 33);
            btnUnselect.Name = "btnUnselect";
            btnUnselect.Padding = new Padding(1);
            btnUnselect.Size = new Size(237, 33);
            btnUnselect.TabIndex = 1;
            btnUnselect.Text = "Deseleccionar categoria";
            btnUnselect.UseVisualStyleBackColor = false;
            btnUnselect.Click += btnDeseleccionar_Click;
            // 
            // btnCreateCategory
            // 
            btnCreateCategory.BackColor = SystemColors.ControlLightLight;
            btnCreateCategory.Dock = DockStyle.Top;
            btnCreateCategory.FlatStyle = FlatStyle.Flat;
            btnCreateCategory.Location = new Point(0, 0);
            btnCreateCategory.Name = "btnCreateCategory";
            btnCreateCategory.Size = new Size(237, 33);
            btnCreateCategory.TabIndex = 0;
            btnCreateCategory.Text = "Crear categoria";
            btnCreateCategory.UseVisualStyleBackColor = false;
            btnCreateCategory.Click += btnAddChild_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(578, 37);
            panel2.TabIndex = 2;
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ControlLight;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(578, 37);
            label1.TabIndex = 0;
            label1.Text = "Seleccione las categorias para desplegarlas.\r\nPara crear una categoria raiz, asegurese que ninguna categoria este seleccionada.";
            // 
            // formCategories
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            CancelButton = btnCancel;
            ClientSize = new Size(827, 437);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "formCategories";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Categorias";
            Load += formCategories_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
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
        private Panel panel2;
        private Label label1;
        private Button btnRefresh;
    }
}