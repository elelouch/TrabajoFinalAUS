namespace MissTortas.Desktop.Forms.Users
{
    partial class formUserPermission
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
            tableLayoutPanel2 = new TableLayoutPanel();
            btnRemovePermission = new Button();
            btnAddPermission = new Button();
            txtAvailablePermissions = new TextBox();
            txtAddedPermissions = new TextBox();
            listBoxAvailablePermissions = new ListBox();
            listBoxAddedPermissions = new ListBox();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
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
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(800, 450);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // btnRemovePermission
            // 
            btnRemovePermission.Dock = DockStyle.Top;
            btnRemovePermission.Location = new Point(323, 238);
            btnRemovePermission.Name = "btnRemovePermission";
            btnRemovePermission.Size = new Size(154, 23);
            btnRemovePermission.TabIndex = 9;
            btnRemovePermission.Text = "<<<";
            btnRemovePermission.UseVisualStyleBackColor = true;
            // 
            // btnAddPermission
            // 
            btnAddPermission.Dock = DockStyle.Bottom;
            btnAddPermission.Location = new Point(323, 209);
            btnAddPermission.Name = "btnAddPermission";
            btnAddPermission.Size = new Size(154, 23);
            btnAddPermission.TabIndex = 8;
            btnAddPermission.Text = ">>>";
            btnAddPermission.UseVisualStyleBackColor = true;
            // 
            // txtAvailablePermissions
            // 
            txtAvailablePermissions.Dock = DockStyle.Fill;
            txtAvailablePermissions.Location = new Point(3, 3);
            txtAvailablePermissions.Name = "txtAvailablePermissions";
            txtAvailablePermissions.ReadOnly = true;
            txtAvailablePermissions.Size = new Size(314, 23);
            txtAvailablePermissions.TabIndex = 4;
            txtAvailablePermissions.Text = "Available Permissions";
            // 
            // txtAddedPermissions
            // 
            txtAddedPermissions.Dock = DockStyle.Fill;
            txtAddedPermissions.Location = new Point(483, 3);
            txtAddedPermissions.Name = "txtAddedPermissions";
            txtAddedPermissions.ReadOnly = true;
            txtAddedPermissions.Size = new Size(314, 23);
            txtAddedPermissions.TabIndex = 5;
            txtAddedPermissions.Text = "Added Permissions";
            // 
            // listBoxAvailablePermissions
            // 
            listBoxAvailablePermissions.Dock = DockStyle.Fill;
            listBoxAvailablePermissions.FormattingEnabled = true;
            listBoxAvailablePermissions.Location = new Point(3, 23);
            listBoxAvailablePermissions.Name = "listBoxAvailablePermissions";
            tableLayoutPanel2.SetRowSpan(listBoxAvailablePermissions, 2);
            listBoxAvailablePermissions.Size = new Size(314, 424);
            listBoxAvailablePermissions.TabIndex = 10;
            // 
            // listBoxAddedPermissions
            // 
            listBoxAddedPermissions.Dock = DockStyle.Fill;
            listBoxAddedPermissions.FormattingEnabled = true;
            listBoxAddedPermissions.Location = new Point(483, 23);
            listBoxAddedPermissions.Name = "listBoxAddedPermissions";
            tableLayoutPanel2.SetRowSpan(listBoxAddedPermissions, 2);
            listBoxAddedPermissions.Size = new Size(314, 424);
            listBoxAddedPermissions.TabIndex = 11;
            // 
            // formUserPermission
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel2);
            Name = "formUserPermission";
            Text = "User Permission";
            Load += formUserPermission_Load;
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private Button btnRemovePermission;
        private Button btnAddPermission;
        private TextBox txtAvailablePermissions;
        private TextBox txtAddedPermissions;
        private ListBox listBoxAvailablePermissions;
        private ListBox listBoxAddedPermissions;
    }
}