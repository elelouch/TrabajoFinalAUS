namespace MissTortas.Desktop.Forms.Products
{
    partial class formCreateCategory
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
            txtCategoryName = new TextBox();
            chkFinalCategory = new CheckBox();
            btnConfirm = new Button();
            btnCancel = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1.SuspendLayout();
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
            // txtCategoryName
            // 
            txtCategoryName.BorderStyle = BorderStyle.None;
            txtCategoryName.Dock = DockStyle.Bottom;
            txtCategoryName.Location = new Point(0, 23);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(173, 16);
            txtCategoryName.TabIndex = 1;
            // 
            // chkFinalCategory
            // 
            chkFinalCategory.AutoSize = true;
            chkFinalCategory.Location = new Point(138, 228);
            chkFinalCategory.Name = "chkFinalCategory";
            chkFinalCategory.Size = new Size(211, 52);
            chkFinalCategory.TabIndex = 2;
            chkFinalCategory.Text = "Categoria Final\r\n(Esto habilitara a la \r\nCategoria a contener productos)";
            chkFinalCategory.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.White;
            btnConfirm.FlatAppearance.BorderColor = Color.Black;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Location = new Point(149, 329);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 24);
            btnConfirm.TabIndex = 3;
            btnConfirm.Text = "Confirmar";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(247, 329);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 24);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnConfirm);
            panel1.Controls.Add(chkFinalCategory);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(163, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 474);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Transparent;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txtCategoryName);
            panel2.Controls.Add(lblCategoryName);
            panel2.Location = new Point(148, 118);
            panel2.Name = "panel2";
            panel2.Size = new Size(175, 41);
            panel2.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(148, 45);
            label1.Name = "label1";
            label1.Size = new Size(175, 16);
            label1.TabIndex = 5;
            label1.Text = "Cree una nueva categoria";
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
            tableLayoutPanel1.Size = new Size(800, 480);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // formCreateCategory
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 480);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Tahoma", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "formCreateCategory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Crear Categoria";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblCategoryName;
        private TextBox txtCategoryName;
        private CheckBox chkFinalCategory;
        private Button btnConfirm;
        private Button btnCancel;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Panel panel2;
    }
}