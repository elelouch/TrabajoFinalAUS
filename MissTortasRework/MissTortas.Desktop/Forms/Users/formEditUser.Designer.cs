namespace MissTortas.Desktop.Forms.Users
{
    partial class formEditUser
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
            btnRemoveRole = new Button();
            btnAddRole = new Button();
            txtAvailableRoles = new TextBox();
            txtAddedRole = new TextBox();
            listBoxAvailableRoles = new ListBox();
            listBoxAddedRoles = new ListBox();
            panel9 = new Panel();
            btnUserPermissions = new Button();
            btnCancel = new Button();
            btnSave = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            panel1 = new Panel();
            panel7 = new Panel();
            lblLastName = new Label();
            txtLastName = new TextBox();
            panel3 = new Panel();
            txtFirstName = new TextBox();
            lblFirstName = new Label();
            panel2 = new Panel();
            txtUsername = new TextBox();
            lblUsername = new Label();
            panel10 = new Panel();
            panel8 = new Panel();
            txtEmail = new TextBox();
            lblEmail = new Label();
            panel6 = new Panel();
            lblRepeatPassword = new Label();
            txtRepeatPassword = new TextBox();
            chkEnabled = new CheckBox();
            panel4 = new Panel();
            panel5 = new Panel();
            label1 = new Label();
            txtUserId = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel9.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel10.SuspendLayout();
            panel8.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
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
            tableLayoutPanel1.Controls.Add(panel9, 2, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 0);
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
            tableLayoutPanel2.Controls.Add(btnRemoveRole, 1, 2);
            tableLayoutPanel2.Controls.Add(btnAddRole, 1, 1);
            tableLayoutPanel2.Controls.Add(txtAvailableRoles, 0, 0);
            tableLayoutPanel2.Controls.Add(txtAddedRole, 2, 0);
            tableLayoutPanel2.Controls.Add(listBoxAvailableRoles, 0, 1);
            tableLayoutPanel2.Controls.Add(listBoxAddedRoles, 2, 1);
            tableLayoutPanel2.Location = new Point(203, 217);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 19F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(394, 200);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // btnRemoveRole
            // 
            btnRemoveRole.BackColor = SystemColors.ControlLightLight;
            btnRemoveRole.Dock = DockStyle.Top;
            btnRemoveRole.FlatStyle = FlatStyle.Flat;
            btnRemoveRole.Location = new Point(160, 112);
            btnRemoveRole.Name = "btnRemoveRole";
            btnRemoveRole.Size = new Size(72, 21);
            btnRemoveRole.TabIndex = 9;
            btnRemoveRole.Text = "<<<";
            btnRemoveRole.UseVisualStyleBackColor = false;
            btnRemoveRole.Click += btnRemoveRole_Click;
            // 
            // btnAddRole
            // 
            btnAddRole.BackColor = SystemColors.ControlLightLight;
            btnAddRole.Dock = DockStyle.Bottom;
            btnAddRole.FlatStyle = FlatStyle.Flat;
            btnAddRole.Location = new Point(160, 85);
            btnAddRole.Name = "btnAddRole";
            btnAddRole.Size = new Size(72, 21);
            btnAddRole.TabIndex = 8;
            btnAddRole.Text = ">>>";
            btnAddRole.UseVisualStyleBackColor = false;
            btnAddRole.Click += btnAddRole_Click;
            // 
            // txtAvailableRoles
            // 
            txtAvailableRoles.BackColor = Color.RosyBrown;
            txtAvailableRoles.BorderStyle = BorderStyle.None;
            txtAvailableRoles.Dock = DockStyle.Fill;
            txtAvailableRoles.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAvailableRoles.ForeColor = SystemColors.Window;
            txtAvailableRoles.Location = new Point(3, 3);
            txtAvailableRoles.Name = "txtAvailableRoles";
            txtAvailableRoles.ReadOnly = true;
            txtAvailableRoles.Size = new Size(151, 15);
            txtAvailableRoles.TabIndex = 4;
            txtAvailableRoles.Text = "Roles disponibles";
            // 
            // txtAddedRole
            // 
            txtAddedRole.BackColor = Color.RosyBrown;
            txtAddedRole.BorderStyle = BorderStyle.None;
            txtAddedRole.Dock = DockStyle.Fill;
            txtAddedRole.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAddedRole.ForeColor = SystemColors.Window;
            txtAddedRole.Location = new Point(238, 3);
            txtAddedRole.Name = "txtAddedRole";
            txtAddedRole.ReadOnly = true;
            txtAddedRole.Size = new Size(153, 15);
            txtAddedRole.TabIndex = 5;
            txtAddedRole.Text = "Roles asignados";
            // 
            // listBoxAvailableRoles
            // 
            listBoxAvailableRoles.BorderStyle = BorderStyle.None;
            listBoxAvailableRoles.Dock = DockStyle.Fill;
            listBoxAvailableRoles.FormattingEnabled = true;
            listBoxAvailableRoles.Location = new Point(3, 22);
            listBoxAvailableRoles.Name = "listBoxAvailableRoles";
            tableLayoutPanel2.SetRowSpan(listBoxAvailableRoles, 2);
            listBoxAvailableRoles.Size = new Size(151, 175);
            listBoxAvailableRoles.TabIndex = 10;
            // 
            // listBoxAddedRoles
            // 
            listBoxAddedRoles.BorderStyle = BorderStyle.None;
            listBoxAddedRoles.Dock = DockStyle.Fill;
            listBoxAddedRoles.FormattingEnabled = true;
            listBoxAddedRoles.Location = new Point(238, 22);
            listBoxAddedRoles.Name = "listBoxAddedRoles";
            tableLayoutPanel2.SetRowSpan(listBoxAddedRoles, 2);
            listBoxAddedRoles.Size = new Size(153, 175);
            listBoxAddedRoles.TabIndex = 11;
            // 
            // panel9
            // 
            panel9.Controls.Add(btnUserPermissions);
            panel9.Controls.Add(btnCancel);
            panel9.Controls.Add(btnSave);
            panel9.Dock = DockStyle.Fill;
            panel9.Location = new Point(603, 3);
            panel9.Name = "panel9";
            panel9.Size = new Size(194, 208);
            panel9.TabIndex = 11;
            // 
            // btnUserPermissions
            // 
            btnUserPermissions.BackColor = SystemColors.ControlLightLight;
            btnUserPermissions.Dock = DockStyle.Bottom;
            btnUserPermissions.FlatStyle = FlatStyle.Flat;
            btnUserPermissions.Location = new Point(0, 184);
            btnUserPermissions.Name = "btnUserPermissions";
            btnUserPermissions.RightToLeft = RightToLeft.No;
            btnUserPermissions.Size = new Size(194, 24);
            btnUserPermissions.TabIndex = 9;
            btnUserPermissions.Text = "Permisos del usuario";
            btnUserPermissions.UseVisualStyleBackColor = false;
            btnUserPermissions.Click += btnUserPermissions_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.Dock = DockStyle.Top;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(0, 23);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(194, 27);
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
            btnSave.Size = new Size(194, 23);
            btnSave.TabIndex = 7;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = Color.WhiteSmoke;
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(panel1, 0, 0);
            tableLayoutPanel3.Controls.Add(panel10, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(203, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(394, 208);
            tableLayoutPanel3.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(191, 202);
            panel1.TabIndex = 9;
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(lblLastName);
            panel7.Controls.Add(txtLastName);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 76);
            panel7.Name = "panel7";
            panel7.Size = new Size(191, 45);
            panel7.TabIndex = 7;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(3, 0);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(49, 14);
            lblLastName.TabIndex = 10;
            lblLastName.Text = "Apellido";
            // 
            // txtLastName
            // 
            txtLastName.BorderStyle = BorderStyle.None;
            txtLastName.Dock = DockStyle.Bottom;
            txtLastName.Location = new Point(0, 28);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(189, 15);
            txtLastName.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(txtFirstName);
            panel3.Controls.Add(lblFirstName);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 35);
            panel3.Name = "panel3";
            panel3.Size = new Size(191, 41);
            panel3.TabIndex = 1;
            // 
            // txtFirstName
            // 
            txtFirstName.BorderStyle = BorderStyle.None;
            txtFirstName.Dock = DockStyle.Bottom;
            txtFirstName.Location = new Point(0, 24);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(189, 15);
            txtFirstName.TabIndex = 1;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Dock = DockStyle.Top;
            lblFirstName.Location = new Point(0, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(50, 14);
            lblFirstName.TabIndex = 9;
            lblFirstName.Text = "Nombre";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(txtUsername);
            panel2.Controls.Add(lblUsername);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(191, 35);
            panel2.TabIndex = 0;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Dock = DockStyle.Bottom;
            txtUsername.Location = new Point(0, 18);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(189, 15);
            txtUsername.TabIndex = 0;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Dock = DockStyle.Top;
            lblUsername.Location = new Point(0, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(46, 14);
            lblUsername.TabIndex = 7;
            lblUsername.Text = "Usuario";
            // 
            // panel10
            // 
            panel10.Controls.Add(panel8);
            panel10.Controls.Add(panel6);
            panel10.Controls.Add(chkEnabled);
            panel10.Controls.Add(panel4);
            panel10.Location = new Point(200, 3);
            panel10.Name = "panel10";
            panel10.Size = new Size(191, 202);
            panel10.TabIndex = 10;
            // 
            // panel8
            // 
            panel8.BorderStyle = BorderStyle.FixedSingle;
            panel8.Controls.Add(txtEmail);
            panel8.Controls.Add(lblEmail);
            panel8.Dock = DockStyle.Top;
            panel8.Location = new Point(0, 76);
            panel8.Name = "panel8";
            panel8.Size = new Size(191, 45);
            panel8.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Dock = DockStyle.Bottom;
            txtEmail.Location = new Point(0, 28);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(189, 15);
            txtEmail.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(-3, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(43, 14);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Correo";
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(lblRepeatPassword);
            panel6.Controls.Add(txtRepeatPassword);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 35);
            panel6.Name = "panel6";
            panel6.Size = new Size(191, 41);
            panel6.TabIndex = 3;
            // 
            // lblRepeatPassword
            // 
            lblRepeatPassword.AutoSize = true;
            lblRepeatPassword.Dock = DockStyle.Top;
            lblRepeatPassword.Location = new Point(0, 0);
            lblRepeatPassword.Name = "lblRepeatPassword";
            lblRepeatPassword.Size = new Size(110, 14);
            lblRepeatPassword.TabIndex = 12;
            lblRepeatPassword.Text = "Repetir contraseña";
            // 
            // txtRepeatPassword
            // 
            txtRepeatPassword.BorderStyle = BorderStyle.None;
            txtRepeatPassword.Dock = DockStyle.Bottom;
            txtRepeatPassword.Location = new Point(0, 24);
            txtRepeatPassword.Name = "txtRepeatPassword";
            txtRepeatPassword.PasswordChar = '*';
            txtRepeatPassword.Size = new Size(189, 15);
            txtRepeatPassword.TabIndex = 5;
            // 
            // chkEnabled
            // 
            chkEnabled.AutoSize = true;
            chkEnabled.FlatAppearance.BorderSize = 0;
            chkEnabled.FlatStyle = FlatStyle.Flat;
            chkEnabled.Location = new Point(6, 152);
            chkEnabled.Name = "chkEnabled";
            chkEnabled.Size = new Size(65, 18);
            chkEnabled.TabIndex = 6;
            chkEnabled.Text = "Habilitar";
            chkEnabled.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(lblPassword);
            panel4.Controls.Add(txtPassword);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(191, 35);
            panel4.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Controls.Add(label1);
            panel5.Controls.Add(txtUserId);
            panel5.Location = new Point(0, 40);
            panel5.Name = "panel5";
            panel5.Size = new Size(140, 30);
            panel5.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(50, 14);
            label1.TabIndex = 14;
            label1.Text = "User Id:";
            // 
            // txtUserId
            // 
            txtUserId.Location = new Point(22, 8);
            txtUserId.Name = "txtUserId";
            txtUserId.ReadOnly = true;
            txtUserId.Size = new Size(100, 22);
            txtUserId.TabIndex = 13;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Dock = DockStyle.Top;
            lblPassword.Location = new Point(0, 0);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(105, 14);
            lblPassword.TabIndex = 11;
            lblPassword.Text = "Nueva contraseña";
            lblPassword.Click += lblPassword_Click;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Dock = DockStyle.Bottom;
            txtPassword.Location = new Point(0, 18);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(189, 15);
            txtPassword.TabIndex = 2;
            // 
            // formEditUser
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 420);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "formEditUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Editar usuario";
            Load += formEditUser_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel9.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnRemoveRole;
        private Button btnAddRole;
        private TextBox txtAvailableRoles;
        private TextBox txtAddedRole;
        private TextBox txtUsername;
        private TextBox txtFirstName;
        private TextBox txtEmail;
        private TextBox txtLastName;
        private CheckBox chkEnabled;
        private TextBox txtPassword;
        private TextBox txtRepeatPassword;
        private Label lblUsername;
        private Label lblEmail;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblPassword;
        private Label lblRepeatPassword;
        private Button btnSave;
        private TextBox txtUserId;
        private Label label1;
        private ListBox listBoxAvailableRoles;
        private ListBox listBoxAddedRoles;
        private Button btnCancel;
        private Button btnUserPermissions;
        private Panel panel1;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel6;
        private Panel panel9;
        private Panel panel7;
        private Panel panel8;
        private TableLayoutPanel tableLayoutPanel3;
        private Panel panel10;
    }
}