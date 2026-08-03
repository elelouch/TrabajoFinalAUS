namespace MissTortas.Desktop.Forms.Roles
{
    partial class formEditRole
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
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnRemovePermission = new Button();
            btnAddPermission = new Button();
            txtAvailablePermissions = new TextBox();
            txtAddedPermissions = new TextBox();
            listBoxAvailablePermissions = new ListBox();
            listBoxAddedPermissions = new ListBox();
            panel3 = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            panel4 = new Panel();
            panel6 = new Panel();
            label1 = new Label();
            panel5 = new Panel();
            panel2 = new Panel();
            lblRoleName = new Label();
            txtRoleName = new TextBox();
            panel1 = new Panel();
            lblRoleId = new Label();
            txtRoleId = new MaskedTextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlLight;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(panel3, 2, 0);
            tableLayoutPanel1.Controls.Add(panel4, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49F));
            tableLayoutPanel1.Size = new Size(800, 420);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.WhiteSmoke;
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.Controls.Add(btnRemovePermission, 1, 2);
            tableLayoutPanel2.Controls.Add(btnAddPermission, 1, 1);
            tableLayoutPanel2.Controls.Add(txtAvailablePermissions, 0, 0);
            tableLayoutPanel2.Controls.Add(txtAddedPermissions, 2, 0);
            tableLayoutPanel2.Controls.Add(listBoxAvailablePermissions, 0, 1);
            tableLayoutPanel2.Controls.Add(listBoxAddedPermissions, 2, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(203, 217);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 19F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(394, 200);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // btnRemovePermission
            // 
            btnRemovePermission.BackColor = Color.White;
            btnRemovePermission.Dock = DockStyle.Top;
            btnRemovePermission.FlatStyle = FlatStyle.Flat;
            btnRemovePermission.Location = new Point(160, 112);
            btnRemovePermission.Name = "btnRemovePermission";
            btnRemovePermission.Size = new Size(72, 21);
            btnRemovePermission.TabIndex = 9;
            btnRemovePermission.Text = "<<<";
            btnRemovePermission.UseVisualStyleBackColor = false;
            btnRemovePermission.Click += btnRemovePermissions_Click;
            // 
            // btnAddPermission
            // 
            btnAddPermission.BackColor = Color.White;
            btnAddPermission.Dock = DockStyle.Bottom;
            btnAddPermission.FlatStyle = FlatStyle.Flat;
            btnAddPermission.Location = new Point(160, 85);
            btnAddPermission.Name = "btnAddPermission";
            btnAddPermission.Size = new Size(72, 21);
            btnAddPermission.TabIndex = 8;
            btnAddPermission.Text = ">>>";
            btnAddPermission.UseVisualStyleBackColor = false;
            btnAddPermission.Click += btnAddPermission_Click;
            // 
            // txtAvailablePermissions
            // 
            txtAvailablePermissions.BackColor = Color.RosyBrown;
            txtAvailablePermissions.BorderStyle = BorderStyle.None;
            txtAvailablePermissions.Dock = DockStyle.Fill;
            txtAvailablePermissions.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAvailablePermissions.ForeColor = SystemColors.Window;
            txtAvailablePermissions.Location = new Point(3, 3);
            txtAvailablePermissions.Name = "txtAvailablePermissions";
            txtAvailablePermissions.ReadOnly = true;
            txtAvailablePermissions.Size = new Size(151, 15);
            txtAvailablePermissions.TabIndex = 4;
            txtAvailablePermissions.Text = "Permisos disponibles";
            // 
            // txtAddedPermissions
            // 
            txtAddedPermissions.BackColor = Color.RosyBrown;
            txtAddedPermissions.BorderStyle = BorderStyle.None;
            txtAddedPermissions.Dock = DockStyle.Fill;
            txtAddedPermissions.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAddedPermissions.ForeColor = Color.White;
            txtAddedPermissions.Location = new Point(238, 3);
            txtAddedPermissions.Name = "txtAddedPermissions";
            txtAddedPermissions.ReadOnly = true;
            txtAddedPermissions.Size = new Size(153, 15);
            txtAddedPermissions.TabIndex = 5;
            txtAddedPermissions.Text = "Permisos asignados";
            // 
            // listBoxAvailablePermissions
            // 
            listBoxAvailablePermissions.BorderStyle = BorderStyle.None;
            listBoxAvailablePermissions.Dock = DockStyle.Fill;
            listBoxAvailablePermissions.FormattingEnabled = true;
            listBoxAvailablePermissions.Location = new Point(3, 22);
            listBoxAvailablePermissions.Name = "listBoxAvailablePermissions";
            tableLayoutPanel2.SetRowSpan(listBoxAvailablePermissions, 2);
            listBoxAvailablePermissions.Size = new Size(151, 175);
            listBoxAvailablePermissions.TabIndex = 10;
            // 
            // listBoxAddedPermissions
            // 
            listBoxAddedPermissions.BorderStyle = BorderStyle.None;
            listBoxAddedPermissions.Dock = DockStyle.Fill;
            listBoxAddedPermissions.FormattingEnabled = true;
            listBoxAddedPermissions.Location = new Point(238, 22);
            listBoxAddedPermissions.Name = "listBoxAddedPermissions";
            tableLayoutPanel2.SetRowSpan(listBoxAddedPermissions, 2);
            listBoxAddedPermissions.Size = new Size(153, 175);
            listBoxAddedPermissions.TabIndex = 11;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnCancel);
            panel3.Controls.Add(btnSave);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(603, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(194, 208);
            panel3.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.Dock = DockStyle.Top;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(0, 35);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(194, 35);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ControlLightLight;
            btnSave.Dock = DockStyle.Top;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(0, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(194, 35);
            btnSave.TabIndex = 7;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.WhiteSmoke;
            panel4.Controls.Add(panel6);
            panel4.Controls.Add(panel5);
            panel4.Location = new Point(203, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(394, 208);
            panel4.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(label1);
            panel6.Location = new Point(123, 9);
            panel6.Name = "panel6";
            panel6.Size = new Size(180, 40);
            panel6.TabIndex = 13;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(180, 40);
            label1.TabIndex = 0;
            label1.Text = "Editando rol";
            // 
            // panel5
            // 
            panel5.Controls.Add(panel2);
            panel5.Controls.Add(panel1);
            panel5.Location = new Point(123, 73);
            panel5.Name = "panel5";
            panel5.Size = new Size(180, 94);
            panel5.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblRoleName);
            panel2.Controls.Add(txtRoleName);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 35);
            panel2.Name = "panel2";
            panel2.Size = new Size(180, 42);
            panel2.TabIndex = 1;
            // 
            // lblRoleName
            // 
            lblRoleName.AutoSize = true;
            lblRoleName.Dock = DockStyle.Top;
            lblRoleName.Location = new Point(0, 0);
            lblRoleName.Name = "lblRoleName";
            lblRoleName.Size = new Size(50, 14);
            lblRoleName.TabIndex = 0;
            lblRoleName.Text = "Nombre";
            // 
            // txtRoleName
            // 
            txtRoleName.Dock = DockStyle.Bottom;
            txtRoleName.Location = new Point(0, 18);
            txtRoleName.Name = "txtRoleName";
            txtRoleName.Size = new Size(178, 22);
            txtRoleName.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblRoleId);
            panel1.Controls.Add(txtRoleId);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(180, 35);
            panel1.TabIndex = 0;
            // 
            // lblRoleId
            // 
            lblRoleId.AutoSize = true;
            lblRoleId.Dock = DockStyle.Top;
            lblRoleId.Location = new Point(0, 0);
            lblRoleId.Name = "lblRoleId";
            lblRoleId.Size = new Size(75, 14);
            lblRoleId.TabIndex = 0;
            lblRoleId.Text = "Identificador";
            // 
            // txtRoleId
            // 
            txtRoleId.BorderStyle = BorderStyle.None;
            txtRoleId.Dock = DockStyle.Bottom;
            txtRoleId.Location = new Point(0, 18);
            txtRoleId.Name = "txtRoleId";
            txtRoleId.ReadOnly = true;
            txtRoleId.Size = new Size(178, 15);
            txtRoleId.TabIndex = 1;
            // 
            // formEditRole
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 420);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "formEditRole";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar rol";
            Load += formEditRole_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnRemovePermission;
        private Button btnAddPermission;
        private TextBox txtAvailablePermissions;
        private TextBox txtAddedPermissions;
        private Button btnSave;
        private ListBox listBoxAvailablePermissions;
        private ListBox listBoxAddedPermissions;
        private Button btnCancel;
        private Label lblRoleId;
        private MaskedTextBox txtRoleId;
        private Label lblRoleName;
        private TextBox txtRoleName;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Label label1;
    }
}