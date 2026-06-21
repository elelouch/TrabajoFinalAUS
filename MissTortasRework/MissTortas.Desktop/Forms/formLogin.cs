using MissTortas.Desktop.Services.AuthService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MissTortas.Desktop.Forms
{
    public partial class formLogin : Form
    {
        private IAuthService _authService;
        public formLogin(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            var dto = new SignInDTO
            {
                Username = this.txtUsername.Text,
                Password = this.txtPassword.Text
            };
            var success = await _authService.SignIn(dto);
            if(success)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Username or password invalid. Try again.", "SignIn", MessageBoxButtons.OK);
            }
        }
    }
}
