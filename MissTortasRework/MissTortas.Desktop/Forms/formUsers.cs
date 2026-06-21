using MissTortas.Desktop.Services.UserService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MissTortas.Desktop.Forms
{
    public partial class formUsers : Form
    {
        private readonly IUserService _usersService;
        public formUsers(IUserService usersService)
        {
            InitializeComponent();
            _usersService = usersService;
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void formUsers_Load(object sender, EventArgs e)
        {
            var allUsers = await _usersService.GetAllUsersAsync();
            dgvUsers.DataSource = allUsers;
        }
    }
}
