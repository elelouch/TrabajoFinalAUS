namespace MissTortas.Desktop.Forms
{
    partial class formUsers
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
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            dgvUsers = new DataGridView();
            userBindingSource = new BindingSource(components);
            btnAddUser = new Button();
            btnRefreshUsers = new Button();
            btnEditUser = new Button();
            btnRemoveUser = new Button();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            UserId = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            Enabled = new DataGridViewCheckBoxColumn();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(dgvUsers, 0, 0);
            tableLayoutPanel1.Controls.Add(btnAddUser, 0, 2);
            tableLayoutPanel1.Controls.Add(btnRefreshUsers, 3, 0);
            tableLayoutPanel1.Controls.Add(btnEditUser, 2, 2);
            tableLayoutPanel1.Controls.Add(btnRemoveUser, 1, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { emailDataGridViewTextBoxColumn, Username, UserId, FirstName, LastName, Enabled });
            tableLayoutPanel1.SetColumnSpan(dgvUsers, 3);
            dgvUsers.DataSource = userBindingSource;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(3, 3);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            tableLayoutPanel1.SetRowSpan(dgvUsers, 2);
            dgvUsers.Size = new Size(730, 415);
            dgvUsers.TabIndex = 0;
            // 
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(Model.User);
            // 
            // btnAddUser
            // 
            btnAddUser.Location = new Point(3, 424);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(75, 23);
            btnAddUser.TabIndex = 1;
            btnAddUser.Text = "Add";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnRefreshUsers
            // 
            btnRefreshUsers.Location = new Point(739, 3);
            btnRefreshUsers.Name = "btnRefreshUsers";
            btnRefreshUsers.Size = new Size(58, 23);
            btnRefreshUsers.TabIndex = 5;
            btnRefreshUsers.Text = "Refresh";
            btnRefreshUsers.UseVisualStyleBackColor = true;
            btnRefreshUsers.Click += btnRefreshUsers_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.Location = new Point(165, 424);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(75, 23);
            btnEditUser.TabIndex = 6;
            btnEditUser.Text = "Edit";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnRemoveUser
            // 
            btnRemoveUser.Location = new Point(84, 424);
            btnRemoveUser.Name = "btnRemoveUser";
            btnRemoveUser.Size = new Size(75, 23);
            btnRemoveUser.TabIndex = 2;
            btnRemoveUser.Text = "Remove";
            btnRemoveUser.UseVisualStyleBackColor = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Username
            // 
            Username.DataPropertyName = "Username";
            Username.HeaderText = "Username";
            Username.Name = "Username";
            Username.ReadOnly = true;
            // 
            // UserId
            // 
            UserId.DataPropertyName = "UserId";
            UserId.HeaderText = "UserId";
            UserId.Name = "UserId";
            UserId.ReadOnly = true;
            // 
            // FirstName
            // 
            FirstName.DataPropertyName = "FirstName";
            FirstName.HeaderText = "FirstName";
            FirstName.Name = "FirstName";
            FirstName.ReadOnly = true;
            // 
            // LastName
            // 
            LastName.DataPropertyName = "LastName";
            LastName.HeaderText = "LastName";
            LastName.Name = "LastName";
            LastName.ReadOnly = true;
            // 
            // Enabled
            // 
            Enabled.DataPropertyName = "Enabled";
            Enabled.HeaderText = "Enabled";
            Enabled.Name = "Enabled";
            Enabled.ReadOnly = true;
            // 
            // formUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "formUsers";
            Text = "Users";
            Load += formUsers_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dgvUsers;
        private Button btnAddUser;
        private Button btnRemoveUser;
        private DataGridViewTextBoxColumn guidDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isEnabledDataGridViewCheckBoxColumn;
        private BindingSource userBindingSource;
        private Button btnRefreshUsers;
        private Button btnEditUser;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn UserId;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewCheckBoxColumn Enabled;
    }
}