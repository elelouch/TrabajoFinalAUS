namespace MissTortas.Desktop.Forms.Products
{
    partial class formModifyCategory
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
            lblCategoryName = new Label();
            btnConfirm = new Button();
            btnCancel = new Button();
            txtCategoryName = new TextBox();
            comboMoveParent = new ComboBox();
            lblSelectParent = new Label();
            chkEnabled = new CheckBox();
            panel1 = new Panel();
            panel4 = new Panel();
            lblModifyCategory = new Label();
            panel3 = new Panel();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Dock = DockStyle.Top;
            lblCategoryName.Location = new Point(0, 0);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(52, 16);
            lblCategoryName.TabIndex = 0;
            lblCategoryName.Text = "Nombre";
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = SystemColors.ControlLightLight;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Location = new Point(139, 339);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 25);
            btnConfirm.TabIndex = 3;
            btnConfirm.Text = "Confirmar";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(265, 339);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 25);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtCategoryName
            // 
            txtCategoryName.Dock = DockStyle.Bottom;
            txtCategoryName.Location = new Point(0, 25);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(201, 23);
            txtCategoryName.TabIndex = 1;
            // 
            // comboMoveParent
            // 
            comboMoveParent.Dock = DockStyle.Bottom;
            comboMoveParent.FlatStyle = FlatStyle.Flat;
            comboMoveParent.FormattingEnabled = true;
            comboMoveParent.Location = new Point(0, 24);
            comboMoveParent.Name = "comboMoveParent";
            comboMoveParent.Size = new Size(201, 24);
            comboMoveParent.TabIndex = 0;
            // 
            // lblSelectParent
            // 
            lblSelectParent.AutoSize = true;
            lblSelectParent.Dock = DockStyle.Top;
            lblSelectParent.Location = new Point(0, 0);
            lblSelectParent.Name = "lblSelectParent";
            lblSelectParent.Size = new Size(136, 16);
            lblSelectParent.TabIndex = 0;
            lblSelectParent.Text = "Nueva categoria padre";
            // 
            // chkEnabled
            // 
            chkEnabled.AutoSize = true;
            chkEnabled.FlatStyle = FlatStyle.Flat;
            chkEnabled.Location = new Point(174, 287);
            chkEnabled.Name = "chkEnabled";
            chkEnabled.Size = new Size(127, 20);
            chkEnabled.TabIndex = 2;
            chkEnabled.Text = "Habilitar categoria";
            chkEnabled.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(chkEnabled);
            panel1.Controls.Add(btnConfirm);
            panel1.Controls.Add(btnCancel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(163, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 474);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblModifyCategory);
            panel4.Location = new Point(136, 42);
            panel4.Name = "panel4";
            panel4.Size = new Size(205, 36);
            panel4.TabIndex = 10;
            // 
            // lblModifyCategory
            // 
            lblModifyCategory.Dock = DockStyle.Fill;
            lblModifyCategory.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblModifyCategory.Location = new Point(0, 0);
            lblModifyCategory.Name = "lblModifyCategory";
            lblModifyCategory.Size = new Size(205, 36);
            lblModifyCategory.TabIndex = 0;
            lblModifyCategory.Text = "label1";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblSelectParent);
            panel3.Controls.Add(comboMoveParent);
            panel3.Location = new Point(138, 192);
            panel3.Name = "panel3";
            panel3.Size = new Size(203, 50);
            panel3.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblCategoryName);
            panel2.Controls.Add(txtCategoryName);
            panel2.Location = new Point(138, 106);
            panel2.Name = "panel2";
            panel2.Size = new Size(203, 50);
            panel2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlLight;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 480F));
            tableLayoutPanel1.Size = new Size(800, 480);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // formModifyCategory
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 480);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "formModifyCategory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += formModifyCategory_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblCategoryName;
        private Button btnConfirm;
        private Button btnCancel;
        private TextBox txtCategoryName;
        private ComboBox comboMoveParent;
        private Label lblSelectParent;
        private CheckBox chkEnabled;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblModifyCategory;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
    }
}