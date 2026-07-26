namespace MissTortas.Desktop.Forms.Users
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
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            UserId = new DataGridViewTextBoxColumn();
            Enabled = new DataGridViewCheckBoxColumn();
            userBindingSource = new BindingSource(components);
            panel1 = new Panel();
            btnAddUser = new Button();
            btnEditUser = new Button();
            btnRefresh = new Button();
            btnFilter = new Button();
            btnCancel = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(dgvUsers, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToOrderColumns = true;
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { emailDataGridViewTextBoxColumn, Username, UserId, Enabled });
            dgvUsers.DataSource = userBindingSource;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(3, 3);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.Size = new Size(634, 444);
            dgvUsers.TabIndex = 0;
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
            // Enabled
            // 
            Enabled.DataPropertyName = "Enabled";
            Enabled.HeaderText = "Enabled";
            Enabled.Name = "Enabled";
            Enabled.ReadOnly = true;
            // 
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(Model.User);
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAddUser);
            panel1.Controls.Add(btnEditUser);
            panel1.Controls.Add(btnRefresh);
            panel1.Controls.Add(btnFilter);
            panel1.Controls.Add(btnCancel);
            panel1.Location = new Point(643, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(154, 444);
            panel1.TabIndex = 1;
            // 
            // btnAddUser
            // 
            btnAddUser.Dock = DockStyle.Top;
            btnAddUser.Location = new Point(0, 95);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(154, 23);
            btnAddUser.TabIndex = 8;
            btnAddUser.Text = "Add";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnEditUser
            // 
            btnEditUser.Dock = DockStyle.Top;
            btnEditUser.Location = new Point(0, 72);
            btnEditUser.Name = "btnEditUser";
            btnEditUser.Size = new Size(154, 23);
            btnEditUser.TabIndex = 11;
            btnEditUser.Text = "Edit";
            btnEditUser.UseVisualStyleBackColor = true;
            btnEditUser.Click += btnEditUser_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Dock = DockStyle.Top;
            btnRefresh.Location = new Point(0, 49);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(154, 23);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefreshUsers_Click;
            // 
            // btnFilter
            // 
            btnFilter.Dock = DockStyle.Top;
            btnFilter.Location = new Point(0, 23);
            btnFilter.Name = "btnFilter";
            btnFilter.RightToLeft = RightToLeft.No;
            btnFilter.Size = new Size(154, 26);
            btnFilter.TabIndex = 10;
            btnFilter.Text = "Filter Enabled";
            btnFilter.UseVisualStyleBackColor = true;
            btnFilter.Click += btnFilter_Click;
            // 
            // btnCancel
            // 
            btnCancel.Dock = DockStyle.Top;
            btnCancel.Location = new Point(0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(154, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // formUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "formUsers";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Users";
            WindowState = FormWindowState.Maximized;
            Load += formUsers_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridViewTextBoxColumn guidDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isEnabledDataGridViewCheckBoxColumn;
        private BindingSource userBindingSource;
        private DataGridView dgvUsers;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn UserId;
        private DataGridViewCheckBoxColumn Enabled;
        private Panel panel1;
        private Button btnAddUser;
        private Button btnEditUser;
        private Button btnRefresh;
        private Button btnFilter;
        private Button btnCancel;
    }
}