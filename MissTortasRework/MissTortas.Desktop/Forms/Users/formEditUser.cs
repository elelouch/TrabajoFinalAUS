using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.Shared;
using MissTortas.Desktop.Services.UserService;
using System.ComponentModel;
using System.Data;

namespace MissTortas.Desktop.Forms.Users
{
    public partial class formEditUser : Form
    {
        private readonly string _userId = string.Empty;
        private readonly IUserService _userService;
        private BindingList<string> AvailableRoles { get; set; }
        private BindingList<string> AddedRoles { get; set; }

        public formEditUser(string userId, IUserService userService)
        {
            InitializeComponent();
            _userId = userId;
            _userService = userService;
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
                var user = await _userService.FindUserByIdAsync(_userId);
                if (user == null)
                {
                    MessageBox.Show("User not found. Or error during fetching.");
                    this.Dispose();
                    return;
                }
                var roles = await _userService.GetRolesAsync();
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
                await _userService.ModifyUserAsync(userId, user);
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
    }
}
