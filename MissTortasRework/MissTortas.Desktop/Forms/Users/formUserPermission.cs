using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.PermissionService;
using MissTortas.Desktop.Services.Shared;
using MissTortas.Desktop.Services.UserService;
using System.ComponentModel;

namespace MissTortas.Desktop.Forms.Users
{
    public partial class formUserPermission : Form
    {
        private readonly IUserService userService;
        private readonly IPermissionService permissionService;
        private readonly List<string> permissionsAssigned;
        private BindingList<string> AvailablePermissions { get; set; }
        private BindingList<string> AddedPermissions { get; set; }
        private readonly User user;
        public formUserPermission(IUserService userService, IPermissionService permissionService, User user)
        {
            InitializeComponent();
            this.user = user;
            this.userService = userService;
            this.permissionService = permissionService;
            this.permissionsAssigned = [.. user.Permissions];
            AvailablePermissions = [];
            AddedPermissions = [];
            this.listBoxAddedPermissions.DataSource = AddedPermissions;
            this.listBoxAvailablePermissions.DataSource = AvailablePermissions;
        }

        private async void formUserPermission_Load(object sender, EventArgs e)
        {
            try
            {
                var permissions = await permissionService.GetAllPermissionsAsync();
                AvailablePermissions.Clear();
                foreach (var p in permissions)
                {
                    if (!permissionsAssigned.Contains(p))
                    {
                        AvailablePermissions.Add(p);
                    }
                }
                AddedPermissions.Clear();
                foreach (var p in permissionsAssigned)
                {
                    AddedPermissions.Add(p);
                }

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

        private void btnAddPermission_Click(object sender, EventArgs e)
        {
            var selectedRole = listBoxAvailablePermissions.GetItemText(listBoxAvailablePermissions.SelectedItem);
            if (selectedRole != null)
            {
                AddedPermissions.Add(selectedRole);
                AvailablePermissions.Remove(selectedRole);
            }
        }

        private void btnRemovePermissions_Click(object sender, EventArgs e)
        {
            var selectedRole = listBoxAddedPermissions.GetItemText(listBoxAddedPermissions.SelectedItem);
            if (selectedRole != null)
            {
                AddedPermissions.Remove(selectedRole);
                AvailablePermissions.Add(selectedRole);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                await userService.PostPermissionsAsync(user.UserId.ToString(), [.. AddedPermissions]);
                MessageBox.Show("Permissions modified successfully");
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

    }
}
