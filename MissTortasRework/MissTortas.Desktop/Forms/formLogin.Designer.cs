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
            welcomingLabel = new Label();
            emailLabel = new Label();
            passwordLabel = new Label();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            loginButton = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // welcomingLabel
            // 
            welcomingLabel.AutoSize = true;
            welcomingLabel.Location = new Point(285, 23);
            welcomingLabel.Name = "welcomingLabel";
            welcomingLabel.Size = new Size(189, 30);
            welcomingLabel.TabIndex = 0;
            welcomingLabel.Text = "Welcome to MissTortas!\r\nPlease, log in with your credentials";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(201, 105);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(97, 15);
            emailLabel.TabIndex = 1;
            emailLabel.Text = "Username/Email:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(201, 160);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(60, 15);
            passwordLabel.TabIndex = 2;
            passwordLabel.Text = "Password:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(349, 102);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(115, 23);
            txtUsername.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(349, 157);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(115, 23);
            txtPassword.TabIndex = 4;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(411, 272);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(75, 23);
            loginButton.TabIndex = 5;
            loginButton.Text = "Log In";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(285, 272);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // formLogin
            // 
            AcceptButton = loginButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(loginButton);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(passwordLabel);
            Controls.Add(emailLabel);
            Controls.Add(welcomingLabel);
            Name = "formLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MissTortas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label welcomingLabel;
        private Label emailLabel;
        private Label passwordLabel;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button loginButton;
        private Button btnCancel;
    }
}