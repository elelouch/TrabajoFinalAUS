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
            tableLayoutPanel3 = new TableLayoutPanel();
            txtUsername = new TextBox();
            txtFirstName = new TextBox();
            txtEmail = new TextBox();
            txtLastName = new TextBox();
            txtPassword = new TextBox();
            textBox6 = new TextBox();
            lblUsername = new Label();
            lblEmail = new Label();
            lblFirstName = new Label();
            lblLastName = new Label();
            lblPassword = new Label();
            txtRepeatPassword = new Label();
            chkEnabled = new CheckBox();
            txtUserId = new TextBox();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 51F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49F));
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
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
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(203, 232);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(394, 215);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // btnRemoveRole
            // 
            btnRemoveRole.Location = new Point(160, 120);
            btnRemoveRole.Name = "btnRemoveRole";
            btnRemoveRole.Size = new Size(72, 23);
            btnRemoveRole.TabIndex = 9;
            btnRemoveRole.Text = "<<<";
            btnRemoveRole.UseVisualStyleBackColor = true;
            btnRemoveRole.Click += btnRemoveRole_Click;
            // 
            // btnAddRole
            // 
            btnAddRole.Dock = DockStyle.Bottom;
            btnAddRole.Location = new Point(160, 91);
            btnAddRole.Name = "btnAddRole";
            btnAddRole.Size = new Size(72, 23);
            btnAddRole.TabIndex = 8;
            btnAddRole.Text = ">>>";
            btnAddRole.UseVisualStyleBackColor = true;
            btnAddRole.Click += btnAddRole_Click;
            // 
            // txtAvailableRoles
            // 
            txtAvailableRoles.Dock = DockStyle.Fill;
            txtAvailableRoles.Location = new Point(3, 3);
            txtAvailableRoles.Name = "txtAvailableRoles";
            txtAvailableRoles.ReadOnly = true;
            txtAvailableRoles.Size = new Size(151, 23);
            txtAvailableRoles.TabIndex = 4;
            txtAvailableRoles.Text = "Available Roles";
            // 
            // txtAddedRole
            // 
            txtAddedRole.Dock = DockStyle.Fill;
            txtAddedRole.Location = new Point(238, 3);
            txtAddedRole.Name = "txtAddedRole";
            txtAddedRole.ReadOnly = true;
            txtAddedRole.Size = new Size(153, 23);
            txtAddedRole.TabIndex = 5;
            txtAddedRole.Text = "Added Roles";
            // 
            // listBoxAvailableRoles
            // 
            listBoxAvailableRoles.Dock = DockStyle.Fill;
            listBoxAvailableRoles.FormattingEnabled = true;
            listBoxAvailableRoles.Location = new Point(3, 23);
            listBoxAvailableRoles.Name = "listBoxAvailableRoles";
            tableLayoutPanel2.SetRowSpan(listBoxAvailableRoles, 2);
            listBoxAvailableRoles.Size = new Size(151, 189);
            listBoxAvailableRoles.TabIndex = 10;
            // 
            // listBoxAddedRoles
            // 
            listBoxAddedRoles.Dock = DockStyle.Fill;
            listBoxAddedRoles.FormattingEnabled = true;
            listBoxAddedRoles.Location = new Point(238, 23);
            listBoxAddedRoles.Name = "listBoxAddedRoles";
            tableLayoutPanel2.SetRowSpan(listBoxAddedRoles, 2);
            listBoxAddedRoles.Size = new Size(153, 189);
            listBoxAddedRoles.TabIndex = 11;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 4;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel3.Controls.Add(txtUsername, 1, 0);
            tableLayoutPanel3.Controls.Add(txtFirstName, 1, 1);
            tableLayoutPanel3.Controls.Add(txtEmail, 3, 0);
            tableLayoutPanel3.Controls.Add(txtLastName, 3, 1);
            tableLayoutPanel3.Controls.Add(txtPassword, 1, 2);
            tableLayoutPanel3.Controls.Add(textBox6, 3, 2);
            tableLayoutPanel3.Controls.Add(lblUsername, 0, 0);
            tableLayoutPanel3.Controls.Add(lblEmail, 2, 0);
            tableLayoutPanel3.Controls.Add(lblFirstName, 0, 1);
            tableLayoutPanel3.Controls.Add(lblLastName, 2, 1);
            tableLayoutPanel3.Controls.Add(lblPassword, 0, 2);
            tableLayoutPanel3.Controls.Add(txtRepeatPassword, 2, 2);
            tableLayoutPanel3.Controls.Add(chkEnabled, 3, 3);
            tableLayoutPanel3.Controls.Add(txtUserId, 1, 3);
            tableLayoutPanel3.Controls.Add(label1, 0, 3);
            tableLayoutPanel3.Location = new Point(203, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 4;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            tableLayoutPanel3.Size = new Size(394, 223);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(81, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(92, 23);
            txtUsername.TabIndex = 0;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(81, 55);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(92, 23);
            txtFirstName.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(277, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(94, 23);
            txtEmail.TabIndex = 3;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(277, 55);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(94, 23);
            txtLastName.TabIndex = 4;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(81, 107);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(92, 23);
            txtPassword.TabIndex = 2;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(277, 107);
            textBox6.Name = "textBox6";
            textBox6.PasswordChar = '*';
            textBox6.Size = new Size(94, 23);
            textBox6.TabIndex = 5;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(3, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 15);
            lblUsername.TabIndex = 7;
            lblUsername.Text = "Username:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(199, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(39, 15);
            lblEmail.TabIndex = 8;
            lblEmail.Text = "Email:";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(3, 52);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(67, 15);
            lblFirstName.TabIndex = 9;
            lblFirstName.Text = "First Name:";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Location = new Point(199, 52);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(66, 15);
            lblLastName.TabIndex = 10;
            lblLastName.Text = "Last Name:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(3, 104);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 15);
            lblPassword.TabIndex = 11;
            lblPassword.Text = "Password:";
            // 
            // txtRepeatPassword
            // 
            txtRepeatPassword.AutoSize = true;
            txtRepeatPassword.Location = new Point(199, 104);
            txtRepeatPassword.Name = "txtRepeatPassword";
            txtRepeatPassword.Size = new Size(60, 30);
            txtRepeatPassword.TabIndex = 12;
            txtRepeatPassword.Text = "Repeat Password:";
            // 
            // chkEnabled
            // 
            chkEnabled.AutoSize = true;
            chkEnabled.Location = new Point(277, 172);
            chkEnabled.Name = "chkEnabled";
            chkEnabled.Size = new Size(68, 19);
            chkEnabled.TabIndex = 6;
            chkEnabled.Text = "Enabled";
            chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtUserId
            // 
            txtUserId.Location = new Point(81, 172);
            txtUserId.Name = "txtUserId";
            txtUserId.ReadOnly = true;
            txtUserId.Size = new Size(100, 23);
            txtUserId.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 169);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 14;
            label1.Text = "User Id:";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Location = new Point(603, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(84, 223);
            flowLayoutPanel1.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(3, 32);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // formEditUser
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "formEditUser";
            Text = "Edit User";
            Load += formEditUser_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnRemoveRole;
        private Button btnAddRole;
        private TextBox txtAvailableRoles;
        private TextBox txtAddedRole;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox txtUsername;
        private TextBox txtFirstName;
        private TextBox txtEmail;
        private TextBox txtLastName;
        private CheckBox chkEnabled;
        private TextBox txtPassword;
        private TextBox textBox6;
        private Label lblUsername;
        private Label lblEmail;
        private Label lblFirstName;
        private Label lblLastName;
        private Label lblPassword;
        private Label txtRepeatPassword;
        private Button btnSave;
        private TextBox txtUserId;
        private Label label1;
        private ListBox listBoxAvailableRoles;
        private ListBox listBoxAddedRoles;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnCancel;
    }
}