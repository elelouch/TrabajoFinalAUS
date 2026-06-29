namespace MissTortas.Desktop.Forms.Roles
{
    partial class formRoles
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
            dgvRoles = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            roleBindingSource = new BindingSource(components);
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnRefresh = new Button();
            btnSave = new Button();
            btnCancel = new Button();
            btnEditRole = new Button();
            userBindingSource = new BindingSource(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRoles).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roleBindingSource).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)userBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(dgvRoles, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 3, 0);
            tableLayoutPanel1.Controls.Add(btnEditRole, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvRoles
            // 
            dgvRoles.AllowUserToOrderColumns = true;
            dgvRoles.AutoGenerateColumns = false;
            dgvRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoles.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn });
            tableLayoutPanel1.SetColumnSpan(dgvRoles, 3);
            dgvRoles.DataSource = roleBindingSource;
            dgvRoles.Dock = DockStyle.Fill;
            dgvRoles.Location = new Point(3, 3);
            dgvRoles.Name = "dgvRoles";
            dgvRoles.Size = new Size(713, 415);
            dgvRoles.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // roleBindingSource
            // 
            roleBindingSource.DataSource = typeof(Model.Role);
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnRefresh);
            flowLayoutPanel1.Controls.Add(btnSave);
            flowLayoutPanel1.Controls.Add(btnCancel);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(722, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(75, 415);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(3, 3);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 23);
            btnRefresh.TabIndex = 0;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefreshUsers_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(3, 32);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(3, 61);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnEditRole
            // 
            btnEditRole.Location = new Point(3, 424);
            btnEditRole.Name = "btnEditRole";
            btnEditRole.Size = new Size(75, 23);
            btnEditRole.TabIndex = 6;
            btnEditRole.Text = "Edit";
            btnEditRole.UseVisualStyleBackColor = true;
            // 
            // userBindingSource
            // 
            userBindingSource.DataSource = typeof(Model.User);
            // 
            // formRoles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "formRoles";
            Text = "Roles";
            Load += formRoles_Load;
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRoles).EndInit();
            ((System.ComponentModel.ISupportInitialize)roleBindingSource).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)userBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridViewTextBoxColumn guidDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn isEnabledDataGridViewCheckBoxColumn;
        private BindingSource userBindingSource;
        private Button btnEditRole;
        private DataGridView dgvRoles;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnRefresh;
        private Button btnCancel;
        private BindingSource roleBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private Button btnSave;
    }
}