using MissTortas.Desktop.Services.AuthService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MissTortas.Desktop.Forms
{
    public partial class formCreateUser : Form
    {
        private readonly IAuthService _authService;
        public formCreateUser(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtRepeatPassword.Text != txtPassword.Text)
            {
                MessageBox.Show(
                    "Passwords don't match",
                    "Wrong password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtRepeatPassword.Clear();
                txtPassword.Clear();
                return;
            }
            try
            {
                var mailAddres = new MailAddress(txtEmail.Text);
                var signUpRequest = new SignupRequest
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Email = txtEmail.Text
                };
                var success = await _authService.SignUpAsync(signUpRequest);
                if (success)
                {
                    MessageBox.Show(
                        "User successfully registered.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    DialogResult = DialogResult.OK;
                    Dispose();
                }
                else
                {
                    MessageBox.Show(
                        "Error. Try again.",
                        "Try again",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }

            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Email is not valid",
                    "EmailNotValid",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }

        }
    }
}
