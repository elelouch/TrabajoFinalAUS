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
            guidDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            isEnabledDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            userBindingSource = new BindingSource(components);
            btnAddUser = new Button();
            btnRemoveUser = new Button();
            btnSaveUsers = new Button();
            btnRefreshUsers = new Button();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(dgvUsers, 0, 0);
            tableLayoutPanel1.Controls.Add(btnAddUser, 0, 2);
            tableLayoutPanel1.Controls.Add(btnRemoveUser, 1, 2);
            tableLayoutPanel1.Controls.Add(btnSaveUsers, 2, 0);
            tableLayoutPanel1.Controls.Add(btnRefreshUsers, 2, 1);
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
            dgvUsers.AutoGenerateColumns = false;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Columns.AddRange(new DataGridViewColumn[] { guidDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, isEnabledDataGridViewCheckBoxColumn });
            tableLayoutPanel1.SetColumnSpan(dgvUsers, 2);
            dgvUsers.DataSource = userBindingSource;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.Location = new Point(3, 3);
            dgvUsers.Name = "dgvUsers";
            tableLayoutPanel1.SetRowSpan(dgvUsers, 2);
            dgvUsers.Size = new Size(650, 415);
            dgvUsers.TabIndex = 0;
            // 
            // guidDataGridViewTextBoxColumn
            // 
            guidDataGridViewTextBoxColumn.DataPropertyName = "Guid";
            guidDataGridViewTextBoxColumn.HeaderText = "Guid";
            guidDataGridViewTextBoxColumn.Name = "guidDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // isEnabledDataGridViewCheckBoxColumn
            // 
            isEnabledDataGridViewCheckBoxColumn.DataPropertyName = "IsEnabled";
            isEnabledDataGridViewCheckBoxColumn.HeaderText = "IsEnabled";
            isEnabledDataGridViewCheckBoxColumn.Name = "isEnabledDataGridViewCheckBoxColumn";
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
            // btnSaveUsers
            // 
            btnSaveUsers.Location = new Point(659, 3);
            btnSaveUsers.Name = "btnSaveUsers";
            btnSaveUsers.Size = new Size(75, 23);
            btnSaveUsers.TabIndex = 4;
            btnSaveUsers.Text = "Save";
            btnSaveUsers.UseVisualStyleBackColor = true;
            // 
            // btnRefreshUsers
            // 
            btnRefreshUsers.Location = new Point(659, 32);
            btnRefreshUsers.Name = "btnRefreshUsers";
            btnRefreshUsers.Size = new Size(75, 23);
            btnRefreshUsers.TabIndex = 5;
            btnRefreshUsers.Text = "Refresh";
            btnRefreshUsers.UseVisualStyleBackColor = true;
            // 
            // formUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "formUsers";
            Text = "Users";
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
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isEnabledDataGridViewCheckBoxColumn;
        private BindingSource userBindingSource;
        private Button btnSaveUsers;
        private Button btnRefreshUsers;
    }
}