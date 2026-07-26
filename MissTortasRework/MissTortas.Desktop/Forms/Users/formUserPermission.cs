using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.PermissionService;
using MissTortas.Desktop.Services.Shared;
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
    public partial class formUserPermission : Form
    {
        private readonly IUserService userService;
        private readonly IPermissionService permissionService;
        private readonly List<string> permissionsAssigned;
        private BindingList<string> AvailablePermissions { get; set; }
        private BindingList<string> AddedPermissions { get; set; }
        public formUserPermission(IUserService userService, IPermissionService permissionService, List<string> permissionsAssigned)
        {
            InitializeComponent();
            this.userService = userService;
            this.permissionService = permissionService;
            this.permissionsAssigned = permissionsAssigned;
            AvailablePermissions = [];
            AddedPermissions = [];
            this.listBoxAddedPermissions.DataSource = AvailablePermissions;
            this.listBoxAvailablePermissions.DataSource = AddedPermissions;
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
    }
}
