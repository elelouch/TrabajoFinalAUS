namespace MissTortas.Desktop.Forms
{
    partial class formLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formLogin));
            welcomingLabel = new Label();
            emailLabel = new Label();
            passwordLabel = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            loginButton = new Button();
            btnCancel = new Button();
            panel1 = new Panel();
            panel5 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // welcomingLabel
            // 
            welcomingLabel.AutoSize = true;
            welcomingLabel.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            welcomingLabel.ForeColor = Color.Transparent;
            welcomingLabel.Location = new Point(20, 88);
            welcomingLabel.Name = "welcomingLabel";
            welcomingLabel.Size = new Size(241, 60);
            welcomingLabel.TabIndex = 0;
            welcomingLabel.Text = "Welcome to MissTortas\r\n\r\nOrder Management System";
            welcomingLabel.TextAlign = ContentAlignment.MiddleCenter;
            welcomingLabel.UseCompatibleTextRendering = true;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Font = new Font("Verdana", 9.75F);
            emailLabel.Location = new Point(23, 5);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(110, 16);
            emailLabel.TabIndex = 1;
            emailLabel.Text = "Username/Email";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Verdana", 9.75F);
            passwordLabel.Location = new Point(23, 9);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(69, 16);
            passwordLabel.TabIndex = 2;
            passwordLabel.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Verdana", 9.75F);
            txtUsername.Location = new Point(23, 24);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(295, 23);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Verdana", 9.75F);
            txtPassword.Location = new Point(23, 28);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(295, 23);
            txtPassword.TabIndex = 4;
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.Pink;
            loginButton.FlatAppearance.BorderColor = Color.White;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 192, 192);
            loginButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 192, 192);
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Verdana", 9.75F);
            loginButton.Location = new Point(461, 321);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(91, 26);
            loginButton.TabIndex = 5;
            loginButton.Text = "LOGIN";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // btnCancel
            // 
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Verdana", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(481, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(34, 26);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "X";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleVioletRed;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(welcomingLabel);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(264, 450);
            panel1.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.BackgroundImage = (Image)resources.GetObject("panel5.BackgroundImage");
            panel5.Location = new Point(33, 179);
            panel5.Name = "panel5";
            panel5.Size = new Size(207, 193);
            panel5.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtUsername);
            panel2.Controls.Add(emailLabel);
            panel2.Location = new Point(291, 106);
            panel2.Name = "panel2";
            panel2.Size = new Size(407, 64);
            panel2.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.Controls.Add(txtPassword);
            panel3.Controls.Add(passwordLabel);
            panel3.Location = new Point(291, 195);
            panel3.Name = "panel3";
            panel3.Size = new Size(407, 70);
            panel3.TabIndex = 9;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnCancel);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(264, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(536, 47);
            panel4.TabIndex = 10;
            // 
            // formLogin
            // 
            AcceptButton = loginButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 450);
            ControlBox = false;
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(loginButton);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MissTortas";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label welcomingLabel;
        private Label emailLabel;
        private Label passwordLabel;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button loginButton;
        private Button btnCancel;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
    }
}