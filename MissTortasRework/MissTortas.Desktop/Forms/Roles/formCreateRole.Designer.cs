namespace MissTortas.Desktop.Forms.Roles
{
    partial class formCreateRole
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
            lblFirstName = new Label();
            txtRoleName = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btnConfirm = new Button();
            SuspendLayout();
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Location = new Point(220, 157);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(68, 15);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "Role Name:";
            lblFirstName.Click += lblFirstName_Click;
            // 
            // txtRoleName
            // 
            txtRoleName.Location = new Point(330, 154);
            txtRoleName.Name = "txtRoleName";
            txtRoleName.Size = new Size(184, 23);
            txtRoleName.TabIndex = 0;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(309, 301);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 23);
            btnConfirm.TabIndex = 10;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // formCreateRole
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConfirm);
            Controls.Add(txtRoleName);
            Controls.Add(lblFirstName);
            Name = "formCreateRole";
            Text = "Create Role";
            Load += formCreateUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFirstName;
        private TextBox txtRoleName;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnConfirm;
    }
}