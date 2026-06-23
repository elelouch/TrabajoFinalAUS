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

        private void fillEditUserForm(FillUserFormDTO dto)
        {
            txtUserId.Text = dto.UserId;
            txtUsername.Text = dto.Username;
            
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
    }
}
