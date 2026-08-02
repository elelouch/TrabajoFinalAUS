using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.AuthService;
using MissTortas.Desktop.Services.PermissionService;
using MissTortas.Desktop.Services.Shared;
using MissTortas.Desktop.Services.UserService;
using System.ComponentModel;

namespace MissTortas.Desktop.Forms.Users
{
    public partial class formUsers : Form
    {
        private readonly IUserService usersService;
        private readonly IAuthService authService;
        private readonly IPermissionService permissionService;
        private List<User> users = [];
        private BindingList<User> shownUsers = [];
        private bool filtered;
        public formUsers(IUserService usersService, IAuthService authService, IPermissionService permissionService)
        {
            InitializeComponent();
            this.authService = authService;
            this.usersService = usersService;
            this.permissionService = permissionService;
            shownUsers = [];
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
            if (!filtered)
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
            try
            {
                var allUsers = await usersService.GetAllUsersAsync();
                users = allUsers;
                shownUsers.Clear();
                foreach (var user in allUsers)
                {
                    shownUsers.Add(user);
                }
                if (shownUsers.Count > 0)
                {
                    var firstRow = dgvUsers.Rows[0];
                    firstRow.Selected = true;
                    dgvUsers.CurrentCell = firstRow.Cells[0];
                }
            }
            catch (ApiException ex)
            {
                ErrorDisplay.Show(this, ex);
                if (ex.StatusCode == System.Net.HttpStatusCode.Forbidden || ex.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Dispose();
                }
            }
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
            var editUserForm = new formEditUser(user.UserId.ToString(), usersService, permissionService);
            editUserForm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
