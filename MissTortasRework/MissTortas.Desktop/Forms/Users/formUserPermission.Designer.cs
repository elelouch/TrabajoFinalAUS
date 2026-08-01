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
            panel1 = new Panel();
            btnCancel = new Button();
            btnSave = new Button();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = SystemColors.ControlLight;
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.75F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.25F));
            tableLayoutPanel2.Controls.Add(btnRemovePermission, 1, 2);
            tableLayoutPanel2.Controls.Add(btnAddPermission, 1, 1);
            tableLayoutPanel2.Controls.Add(txtAvailablePermissions, 0, 0);
            tableLayoutPanel2.Controls.Add(txtAddedPermissions, 2, 0);
            tableLayoutPanel2.Controls.Add(listBoxAvailablePermissions, 0, 1);
            tableLayoutPanel2.Controls.Add(listBoxAddedPermissions, 2, 1);
            tableLayoutPanel2.Controls.Add(panel1, 3, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 19F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(800, 420);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // btnRemovePermission
            // 
            btnRemovePermission.BackColor = SystemColors.ControlLightLight;
            btnRemovePermission.Dock = DockStyle.Top;
            btnRemovePermission.FlatStyle = FlatStyle.Flat;
            btnRemovePermission.Location = new Point(323, 222);
            btnRemovePermission.Name = "btnRemovePermission";
            btnRemovePermission.Size = new Size(74, 21);
            btnRemovePermission.TabIndex = 9;
            btnRemovePermission.Text = "<<<";
            btnRemovePermission.UseVisualStyleBackColor = false;
            btnRemovePermission.Click += btnRemovePermissions_Click;
            // 
            // btnAddPermission
            // 
            btnAddPermission.BackColor = SystemColors.ControlLightLight;
            btnAddPermission.Dock = DockStyle.Bottom;
            btnAddPermission.FlatStyle = FlatStyle.Flat;
            btnAddPermission.Location = new Point(323, 195);
            btnAddPermission.Name = "btnAddPermission";
            btnAddPermission.Size = new Size(74, 21);
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
            txtAvailablePermissions.Size = new Size(314, 15);
            txtAvailablePermissions.TabIndex = 4;
            txtAvailablePermissions.Text = "Permisos disponibles";
            // 
            // txtAddedPermissions
            // 
            txtAddedPermissions.BackColor = Color.RosyBrown;
            txtAddedPermissions.Dock = DockStyle.Fill;
            txtAddedPermissions.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtAddedPermissions.ForeColor = SystemColors.Window;
            txtAddedPermissions.Location = new Point(403, 3);
            txtAddedPermissions.Name = "txtAddedPermissions";
            txtAddedPermissions.ReadOnly = true;
            txtAddedPermissions.Size = new Size(304, 22);
            txtAddedPermissions.TabIndex = 5;
            txtAddedPermissions.Text = "Permisos asignados";
            // 
            // listBoxAvailablePermissions
            // 
            listBoxAvailablePermissions.Dock = DockStyle.Fill;
            listBoxAvailablePermissions.FormattingEnabled = true;
            listBoxAvailablePermissions.Location = new Point(3, 22);
            listBoxAvailablePermissions.Name = "listBoxAvailablePermissions";
            tableLayoutPanel2.SetRowSpan(listBoxAvailablePermissions, 2);
            listBoxAvailablePermissions.Size = new Size(314, 395);
            listBoxAvailablePermissions.TabIndex = 10;
            // 
            // listBoxAddedPermissions
            // 
            listBoxAddedPermissions.Dock = DockStyle.Fill;
            listBoxAddedPermissions.FormattingEnabled = true;
            listBoxAddedPermissions.Location = new Point(403, 22);
            listBoxAddedPermissions.Name = "listBoxAddedPermissions";
            tableLayoutPanel2.SetRowSpan(listBoxAddedPermissions, 2);
            listBoxAddedPermissions.Size = new Size(304, 395);
            listBoxAddedPermissions.TabIndex = 11;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnCancel);
            panel1.Controls.Add(btnSave);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(713, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(84, 194);
            panel1.TabIndex = 12;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.Dock = DockStyle.Top;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(0, 21);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(84, 21);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.ControlLightLight;
            btnSave.Dock = DockStyle.Top;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(0, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(84, 21);
            btnSave.TabIndex = 0;
            btnSave.Text = "Guardar";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // formUserPermission
            // 
            AcceptButton = btnSave;
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 420);
            Controls.Add(tableLayoutPanel2);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "formUserPermission";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Permisos del usuario";
            Load += formUserPermission_Load;
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
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
        private Panel panel1;
        private Button btnCancel;
        private Button btnSave;
    }
}