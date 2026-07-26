using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.PermissionService;
using MissTortas.Desktop.Services.Shared;
using MissTortas.Desktop.Services.UserService;
using System.ComponentModel;
using System.Data;

namespace MissTortas.Desktop.Forms.Users
{
    public partial class formEditUser : Form
    {
        private readonly string userId = string.Empty;
        private readonly IUserService userService;
        private BindingList<string> AvailableRoles { get; set; }
        private BindingList<string> AddedRoles { get; set; }
        private readonly IPermissionService? permissionService;
        private User? userFetched;

        public formEditUser(string userId, IUserService userService) : this(userId, userService, null) { }
        public formEditUser(string userId, IUserService userService, IPermissionService? permissionService)
        {
            InitializeComponent();
            this.userId = userId;
            this.userService = userService;
            this.permissionService = permissionService;
            AvailableRoles = [];
            AddedRoles = [];
        }

        private void fillEditUserForm(User dto, string[] roles)
        {
            txtUserId.Text = dto.UserId.ToString();
            txtUsername.Text = dto.Username;
            chkEnabled.Checked = dto.Enabled;
            txtFirstName.Text = dto.FirstName;
            txtLastName.Text = dto.LastName;
            txtEmail.Text = dto.Email;

            AddedRoles = [.. dto.Roles];
            AvailableRoles = [.. roles.Except(AddedRoles)];
            listBoxAddedRoles.DataSource = AddedRoles;
            listBoxAvailableRoles.DataSource = AvailableRoles;
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
            try
            {
                var user = await userService.FindUserByIdAsync(userId);
                if (user == null)
                {
                    MessageBox.Show("User not found. Or error during fetching.");
                    this.Dispose();
                    return;
                }
                userFetched = user;
                var roles = await userService.GetRolesAsync();
                fillEditUserForm(user, [.. roles.Select(r => r.Name)]);
            }
            catch (ApiException exc)
            {
                ErrorDisplay.Show(this, exc);
                if (exc.StatusCode == System.Net.HttpStatusCode.Forbidden || exc.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Dispose();
                }
            }
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            var selectedRole = listBoxAvailableRoles.GetItemText(listBoxAvailableRoles.SelectedItem);
            if (selectedRole != null)
            {
                AddedRoles.Add(selectedRole);
                AvailableRoles.Remove(selectedRole);
            }
        }

        private void btnRemoveRole_Click(object sender, EventArgs e)
        {
            var selectedRole = listBoxAddedRoles.GetItemText(listBoxAddedRoles.SelectedItem);
            if (selectedRole != null)
            {
                AddedRoles.Remove(selectedRole);
                AvailableRoles.Add(selectedRole);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var newPassword = txtPassword.Text;
            var repeatPassword = txtRepeatPassword.Text;
            var newPasswordNotEmpty = !string.IsNullOrEmpty(newPassword);
            var repeatPasswordNotEmpty = !string.IsNullOrEmpty(newPassword);
            if ((newPasswordNotEmpty || repeatPasswordNotEmpty) && newPassword != repeatPassword)
            {
                MessageBox.Show("Passwords don't match");
                return;
            }
            var user = new UserModificationDTO
            {
                FirstName = txtFirstName.Text,
                Enabled = chkEnabled.Checked,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Username = txtUsername.Text,
                Roles = [.. AddedRoles],
                NewPassword = newPassword
            };
            var userId = txtUserId.Text;
            try
            {
                await userService.ModifyUserAsync(userId, user);
                MessageBox.Show("Modification was successful.");
                Dispose();
            }
            catch (ApiException exc)
            {
                ErrorDisplay.Show(this, exc);
                if (exc.StatusCode == System.Net.HttpStatusCode.Forbidden || exc.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    Dispose();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnUserPermissions_Click(object sender, EventArgs e)
        {
            if(userFetched == null)
            {
                MessageBox.Show("User not not fetched yet to read its permissions.");
                return;
            }
            if(permissionService == null)
            {
                MessageBox.Show("Permissions service not available.");
                return;
            }
            var formPermissions = new formUserPermission(userService, permissionService, [.. userFetched.Permissions]);
            formPermissions.ShowDialog();
        }
    }
}
