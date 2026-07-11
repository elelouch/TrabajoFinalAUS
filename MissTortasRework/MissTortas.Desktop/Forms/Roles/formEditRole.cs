using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.PermissionService;
using MissTortas.Desktop.Services.RoleService;
using MissTortas.Desktop.Services.Shared;
using MissTortas.Desktop.Services.UserService;
using System.ComponentModel;
using System.Data;

namespace MissTortas.Desktop.Forms.Roles
{
    public partial class formEditRole : Form
    {
        private readonly string roleId = string.Empty;
        private readonly IRoleService roleService;
        private readonly IPermissionService permissionService;
        private BindingList<string> AvailablePermissions { get; set; }
        private BindingList<string> AddedPermissions { get; set; }

        public formEditRole(string roleId, IRoleService roleService, IPermissionService permissionService)
        {
            InitializeComponent();
            this.roleId = roleId;
            this.roleService = roleService;
            this.permissionService = permissionService;
            AvailablePermissions = [];
            AddedPermissions = [];
        }

        private void fillEditForm(Role role, List<string> permissionsAvailable)
        {
            txtRoleId.Text = role.Id;
            txtRoleName.Text = role.Name;
            AvailablePermissions = [.. permissionsAvailable.Except(role.Permissions)];
            AddedPermissions = [.. role.Permissions];
            listBoxAddedPermissions.DataSource = AddedPermissions;
            listBoxAvailablePermissions.DataSource = AvailablePermissions;
        }

        private async void formEditRole_Load(object sender, EventArgs e)
        {
            try
            {
                var role = await roleService.GetRoleAsync(roleId) ?? throw new InvalidOperationException("The roled loaded is invalid.");
                var permissionsAvailable = await permissionService.GetAllPermissionsAsync();
                fillEditForm(role, permissionsAvailable);
            }
            catch(ApiException exc)
            {
                ErrorDisplay.Show(this, exc);
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var roleId = txtRoleId.Text;
            var roleName = txtRoleName.Text;
            var rolesToAdd = AddedPermissions.ToList();

            var role = new Role { Id = roleId, Name = roleName, Permissions = rolesToAdd };
            try
            {
                await roleService.ModifyRoleAsync(role);
                MessageBox.Show("Role modificated successfully.", "Role modification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dispose();
            }
            catch(HttpRequestException err)
            {
                MessageBox.Show($"Error during role modification. Error:{err.Message}", "Role modification failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
