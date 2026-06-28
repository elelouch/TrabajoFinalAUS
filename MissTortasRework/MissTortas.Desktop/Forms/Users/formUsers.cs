using MissTortas.Desktop.Forms.Users;
using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.AuthService;
using MissTortas.Desktop.Services.UserService;
using System.ComponentModel;

namespace MissTortas.Desktop.Forms
{
    public partial class formUsers : Form
    {
        private readonly IUserService usersService;
        private readonly IAuthService authService;
        private List<User> users = [];
        private BindingList<User> shownUsers = [];
        private bool filtered;
        public formUsers(IUserService usersService, IAuthService authService)
        {
            InitializeComponent();
            this.authService = authService;
            this.usersService = usersService;
            dgvUsers.DataSource = shownUsers;
        }

        private async void formUsers_Load(object sender, EventArgs e)
        {
            await LoadDataGridView();
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            var createUser = new formCreateUser(authService);
            createUser.SignUpCompleted += CreateUser_SignUpCompleted;
            createUser.ShowDialog();
        }

        private void CreateUser_SignUpCompleted(object? sender, Events.SignupCompletedArgs e)
        {
            users.Add(e.User);
            if(!filtered)
            {
                shownUsers.Add(e.User);
            }
        }

        private async void btnRefreshUsers_Click(object sender, EventArgs e)
        {
            await LoadDataGridView();
        }

        private async Task LoadDataGridView()
        {
            var allUsers = await usersService.GetAllUsersAsync();
            users = allUsers;
            shownUsers = new(allUsers);
            dgvUsers.DataSource = shownUsers;
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count <= 0)
            {
                return;
            }
            if (dgvUsers.SelectedRows[0].DataBoundItem is not User user)
            {
                return;
            }
            var editUserForm = new formEditUser(user.UserId.ToString(), usersService);
            editUserForm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if(filtered)
            {
                shownUsers = new(users);
                dgvUsers.DataSource = shownUsers;
                filtered = false;
            }
            else
            {
                shownUsers = new([.. shownUsers.Where(u => u.Enabled)]);
                dgvUsers.DataSource = shownUsers;
                filtered = true;
            }
        }
    }
}
