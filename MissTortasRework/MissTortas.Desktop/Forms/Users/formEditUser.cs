using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.UserService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MissTortas.Desktop.Forms.Users
{
    public partial class formEditUser : Form
    {
        private readonly string _userId = string.Empty;
        private readonly IUserService _userService;
        public formEditUser(string userId, IUserService userService)
        {
            InitializeComponent();
            _userId = userId;
            _userService = userService;
        }

        private void fillEditUserForm(User dto, string[] roles)
        {
            txtUserId.Text = dto.UserId.ToString();
            txtUsername.Text = dto.Username;
            chkEnabled.Checked = dto.Enabled;
            txtFirstName.Text = dto.FirstName;
            txtLastName.Text = dto.LastName;
            txtEmail.Text = dto.Email;
            listBoxAddedRoles.DataSource = dto.Roles;
            listBoxAvailableRoles.DataSource = roles;
        }

        private class FillUserFormDTO
        {
            public string UserId { get; set; } = string.Empty;
            public string Username { get; set; } = string.Empty;
            public string FirstName { get; set; } = string.Empty;
            public string LastName { get; set; } = string.Empty;
            public bool Enabled { get; set; }
            public List<string> Roles { get; set; } = [];
        }

        private async void formEditUser_Load(object sender, EventArgs e)
        {
            var user = await _userService.FindUserByIdAsync(_userId);
            if(user == null)
            {
                MessageBox.Show("User not found. Or error during fetching.");
                this.Dispose();
                return;
            }
            var roles = await _userService.GetRolesAsync();
            fillEditUserForm(user, [..roles.Select(r => r.Name)]);
        }
    }
}
