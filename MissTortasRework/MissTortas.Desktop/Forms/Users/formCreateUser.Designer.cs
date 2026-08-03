namespace MissTortas.Desktop.Forms
{
    partial class formCreateUser
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
            lblLastName = new Label();
            label3 = new Label();
            label4 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtRepeatPassword = new TextBox();
            lblRepeatPassword = new Label();
            btnConfirm = new Button();
            lblEmail = new Label();
            txtEmail = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btnCancel = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            label1 = new Label();
            panel8 = new Panel();
            panel7 = new Panel();
            panel6 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel3 = new Panel();
            panel2 = new Panel();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel8.SuspendLayout();
            panel7.SuspendLayout();
            panel6.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Dock = DockStyle.Top;
            lblFirstName.Location = new Point(0, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(50, 14);
            lblFirstName.TabIndex = 0;
            lblFirstName.Text = "Nombre";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Dock = DockStyle.Top;
            lblLastName.Location = new Point(0, 0);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(49, 14);
            lblLastName.TabIndex = 0;
            lblLastName.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Top;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(110, 14);
            label3.TabIndex = 0;
            label3.Text = "Nombre de usuario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Top;
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(68, 14);
            label4.TabIndex = 0;
            label4.Text = "Contraseña";
            // 
            // txtFirstName
            // 
            txtFirstName.BorderStyle = BorderStyle.None;
            txtFirstName.Dock = DockStyle.Bottom;
            txtFirstName.Location = new Point(0, 18);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(196, 15);
            txtFirstName.TabIndex = 1;
            // 
            // txtLastName
            // 
            txtLastName.BorderStyle = BorderStyle.None;
            txtLastName.Dock = DockStyle.Bottom;
            txtLastName.Location = new Point(0, 18);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(196, 15);
            txtLastName.TabIndex = 0;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Dock = DockStyle.Bottom;
            txtUsername.Location = new Point(0, 18);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(196, 15);
            txtUsername.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Dock = DockStyle.Bottom;
            txtPassword.Location = new Point(0, 18);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(196, 15);
            txtPassword.TabIndex = 0;
            // 
            // txtRepeatPassword
            // 
            txtRepeatPassword.BorderStyle = BorderStyle.None;
            txtRepeatPassword.Dock = DockStyle.Bottom;
            txtRepeatPassword.Location = new Point(0, 18);
            txtRepeatPassword.Name = "txtRepeatPassword";
            txtRepeatPassword.PasswordChar = '*';
            txtRepeatPassword.Size = new Size(196, 15);
            txtRepeatPassword.TabIndex = 0;
            // 
            // lblRepeatPassword
            // 
            lblRepeatPassword.AutoSize = true;
            lblRepeatPassword.Dock = DockStyle.Top;
            lblRepeatPassword.Location = new Point(0, 0);
            lblRepeatPassword.Name = "lblRepeatPassword";
            lblRepeatPassword.Size = new Size(111, 14);
            lblRepeatPassword.TabIndex = 0;
            lblRepeatPassword.Text = "Repetir Contraseña";
            // 
            // btnConfirm
            // 
            btnConfirm.BackColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.Location = new Point(3, 314);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 26);
            btnConfirm.TabIndex = 6;
            btnConfirm.Text = "Confirmar";
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Dock = DockStyle.Top;
            lblEmail.Location = new Point(0, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(43, 14);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Correo";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Dock = DockStyle.Bottom;
            txtEmail.Location = new Point(0, 18);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(196, 15);
            txtEmail.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = SystemColors.ControlLightLight;
            btnCancel.Location = new Point(123, 314);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 29);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancelar";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnClose_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlLight;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 420F));
            tableLayoutPanel1.Size = new Size(800, 420);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.WhiteSmoke;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel8);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(163, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(474, 414);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(132, 18);
            label1.Name = "label1";
            label1.Size = new Size(107, 14);
            label1.TabIndex = 0;
            label1.Text = "Creando usuario";
            // 
            // panel8
            // 
            panel8.Controls.Add(panel7);
            panel8.Controls.Add(btnCancel);
            panel8.Controls.Add(btnConfirm);
            panel8.Controls.Add(panel6);
            panel8.Controls.Add(panel4);
            panel8.Controls.Add(panel5);
            panel8.Controls.Add(panel3);
            panel8.Controls.Add(panel2);
            panel8.Location = new Point(131, 52);
            panel8.Name = "panel8";
            panel8.Size = new Size(198, 343);
            panel8.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(lblRepeatPassword);
            panel7.Controls.Add(txtRepeatPassword);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 175);
            panel7.Name = "panel7";
            panel7.Size = new Size(198, 35);
            panel7.TabIndex = 5;
            // 
            // panel6
            // 
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(label4);
            panel6.Controls.Add(txtPassword);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 140);
            panel6.Name = "panel6";
            panel6.Size = new Size(198, 35);
            panel6.TabIndex = 4;
            // 
            // panel4
            // 
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(txtUsername);
            panel4.Controls.Add(label3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 105);
            panel4.Name = "panel4";
            panel4.Size = new Size(198, 35);
            panel4.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(lblEmail);
            panel5.Controls.Add(txtEmail);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 70);
            panel5.Name = "panel5";
            panel5.Size = new Size(198, 35);
            panel5.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblLastName);
            panel3.Controls.Add(txtLastName);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 35);
            panel3.Name = "panel3";
            panel3.Size = new Size(198, 35);
            panel3.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblFirstName);
            panel2.Controls.Add(txtFirstName);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(198, 35);
            panel2.TabIndex = 0;
            // 
            // formCreateUser
            // 
            AcceptButton = btnConfirm;
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 420);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "formCreateUser";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Crear Usuario";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel8.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblFirstName;
        private Label lblLastName;
        private Label label3;
        private Label label4;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtRepeatPassword;
        private Label lblRepeatPassword;
        private Button btnConfirm;
        private Label lblEmail;
        private TextBox txtEmail;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnCancel;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Panel panel7;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private Panel panel8;
        private Label label1;
    }
}