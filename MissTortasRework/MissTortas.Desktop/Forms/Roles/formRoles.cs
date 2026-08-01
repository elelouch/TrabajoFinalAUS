using MissTortas.Desktop.Events;
using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.PermissionService;
using MissTortas.Desktop.Services.RoleService;
using MissTortas.Desktop.Services.Shared;
using System.ComponentModel;

namespace MissTortas.Desktop.Forms.Roles
{
    public partial class formRoles : Form
    {
        private readonly IRoleService roleService;
        private readonly IPermissionService permissionService;
        private List<Role> roles = [];
        private BindingList<Role> showRoles = [];
        public formRoles(IRoleService roleService, IPermissionService permissionService)
        {
            InitializeComponent();
            this.roleService = roleService;
            this.permissionService = permissionService;
            dgvRoles.DataSource = showRoles;
        }

        private async void btnRefreshUsers_Click(object sender, EventArgs e)
        {
            await LoadDataGridView();
        }

        private async Task LoadDataGridView()
        {
            try
            {
                var allRoles = await roleService.GetRolesAsync();
                roles = allRoles;
                showRoles = new(allRoles);
                dgvRoles.DataSource = showRoles;
                if (showRoles.Count > 0)
                {
                    var firstRow = dgvRoles.Rows[0];
                    firstRow.Selected = true;
                    dgvRoles.CurrentCell = firstRow.Cells[0];
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void formRoles_Load(object sender, EventArgs e)
        {
            await LoadDataGridView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var createRoleForm = new formCreateRole(roleService);
            createRoleForm.OnRoleCreated += CreateRoleForm_RoleCreated;
            createRoleForm.ShowDialog();
        }

        private void CreateRoleForm_RoleCreated(object? sender, RoleCreatedArgs e)
        {
            showRoles.Add(e.Role);
        }

        private void btnEditRole_Click(object sender, EventArgs e)
        {
            if (dgvRoles.SelectedRows.Count <= 0)
            {
                return;
            }
            if (dgvRoles.SelectedRows[0].DataBoundItem is not Role role)
            {
                return;
            }
            var editRoleForm = new formEditRole(role.Id, roleService, permissionService);
            editRoleForm.ShowDialog();
        }
    }
}
