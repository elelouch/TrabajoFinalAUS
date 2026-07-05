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
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            lblRoleId = new Label();
            txtRoleId = new MaskedTextBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            lblRoleName = new Label();
            txtRoleName = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 2, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 0);
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
            tableLayoutPanel2.Controls.Add(btnRemovePermission, 1, 2);
            tableLayoutPanel2.Controls.Add(btnAddPermission, 1, 1);
            tableLayoutPanel2.Controls.Add(txtAvailablePermissions, 0, 0);
            tableLayoutPanel2.Controls.Add(txtAddedPermissions, 2, 0);
            tableLayoutPanel2.Controls.Add(listBoxAvailablePermissions, 0, 1);
            tableLayoutPanel2.Controls.Add(listBoxAddedPermissions, 2, 1);
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
            // btnRemovePermission
            // 
            btnRemovePermission.Location = new Point(160, 120);
            btnRemovePermission.Name = "btnRemovePermission";
            btnRemovePermission.Size = new Size(72, 23);
            btnRemovePermission.TabIndex = 9;
            btnRemovePermission.Text = "<<<";
            btnRemovePermission.UseVisualStyleBackColor = true;
            btnRemovePermission.Click += btnRemovePermissions_Click;
            // 
            // btnAddPermission
            // 
            btnAddPermission.Dock = DockStyle.Bottom;
            btnAddPermission.Location = new Point(160, 91);
            btnAddPermission.Name = "btnAddPermission";
            btnAddPermission.Size = new Size(72, 23);
            btnAddPermission.TabIndex = 8;
            btnAddPermission.Text = ">>>";
            btnAddPermission.UseVisualStyleBackColor = true;
            btnAddPermission.Click += btnAddPermission_Click;
            // 
            // txtAvailablePermissions
            // 
            txtAvailablePermissions.Dock = DockStyle.Fill;
            txtAvailablePermissions.Location = new Point(3, 3);
            txtAvailablePermissions.Name = "txtAvailablePermissions";
            txtAvailablePermissions.ReadOnly = true;
            txtAvailablePermissions.Size = new Size(151, 23);
            txtAvailablePermissions.TabIndex = 4;
            txtAvailablePermissions.Text = "Available Permissions";
            // 
            // txtAddedPermissions
            // 
            txtAddedPermissions.Dock = DockStyle.Fill;
            txtAddedPermissions.Location = new Point(238, 3);
            txtAddedPermissions.Name = "txtAddedPermissions";
            txtAddedPermissions.ReadOnly = true;
            txtAddedPermissions.Size = new Size(153, 23);
            txtAddedPermissions.TabIndex = 5;
            txtAddedPermissions.Text = "Added Roles";
            // 
            // listBoxAvailablePermissions
            // 
            listBoxAvailablePermissions.Dock = DockStyle.Fill;
            listBoxAvailablePermissions.FormattingEnabled = true;
            listBoxAvailablePermissions.Location = new Point(3, 23);
            listBoxAvailablePermissions.Name = "listBoxAvailablePermissions";
            tableLayoutPanel2.SetRowSpan(listBoxAvailablePermissions, 2);
            listBoxAvailablePermissions.Size = new Size(151, 189);
            listBoxAvailablePermissions.TabIndex = 10;
            // 
            // listBoxAddedPermissions
            // 
            listBoxAddedPermissions.Dock = DockStyle.Fill;
            listBoxAddedPermissions.FormattingEnabled = true;
            listBoxAddedPermissions.Location = new Point(238, 23);
            listBoxAddedPermissions.Name = "listBoxAddedPermissions";
            tableLayoutPanel2.SetRowSpan(listBoxAddedPermissions, 2);
            listBoxAddedPermissions.Size = new Size(153, 189);
            listBoxAddedPermissions.TabIndex = 11;
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
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(flowLayoutPanel2, 0, 0);
            tableLayoutPanel3.Controls.Add(flowLayoutPanel3, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(203, 3);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Size = new Size(394, 223);
            tableLayoutPanel3.TabIndex = 9;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(lblRoleId);
            flowLayoutPanel2.Controls.Add(txtRoleId);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(191, 105);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // lblRoleId
            // 
            lblRoleId.AutoSize = true;
            lblRoleId.Location = new Point(3, 0);
            lblRoleId.Name = "lblRoleId";
            lblRoleId.Size = new Size(43, 15);
            lblRoleId.TabIndex = 0;
            lblRoleId.Text = "Role Id";
            // 
            // txtRoleId
            // 
            txtRoleId.Location = new Point(52, 3);
            txtRoleId.Name = "txtRoleId";
            txtRoleId.ReadOnly = true;
            txtRoleId.Size = new Size(100, 23);
            txtRoleId.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(lblRoleName);
            flowLayoutPanel3.Controls.Add(txtRoleName);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(200, 3);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(191, 105);
            flowLayoutPanel3.TabIndex = 1;
            // 
            // lblRoleName
            // 
            lblRoleName.AutoSize = true;
            lblRoleName.Location = new Point(3, 0);
            lblRoleName.Name = "lblRoleName";
            lblRoleName.Size = new Size(65, 15);
            lblRoleName.TabIndex = 0;
            lblRoleName.Text = "Role Name";
            // 
            // txtRoleName
            // 
            txtRoleName.Location = new Point(74, 3);
            txtRoleName.Name = "txtRoleName";
            txtRoleName.Size = new Size(100, 23);
            txtRoleName.TabIndex = 1;
            // 
            // formEditRole
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "formEditRole";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Role";
            Load += formEditRole_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
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
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnCancel;
        private TableLayoutPanel tableLayoutPanel3;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label lblRoleId;
        private MaskedTextBox txtRoleId;
        private Label lblRoleName;
        private TextBox txtRoleName;
    }
}