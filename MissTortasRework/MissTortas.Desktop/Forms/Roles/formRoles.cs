using MissTortas.Desktop.Events;
using MissTortas.Desktop.Forms.Users;
using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.AuthService;
using MissTortas.Desktop.Services.RoleService;
using MissTortas.Desktop.Services.UserService;
using System.ComponentModel;

namespace MissTortas.Desktop.Forms.Roles
{
    public partial class formRoles : Form
    {
        private readonly IRoleService roleService;
        private List<Role> roles = [];
        private List<DataGridViewRow> rolesAux = [];
        private BindingList<Role> showRoles = [];
        public formRoles(IRoleService roleService)
        {
            InitializeComponent();
            this.roleService = roleService;
            dgvRoles.DataSource = showRoles;
            dgvRoles.UserAddedRow += DgvRoles_UserAddedRow;
            dgvRoles.UserDeletedRow += DgvRoles_UserDeletedRow; 
            dgvRoles.KeyDown += DgvRoles_KeyDown;
        }
        private void DgvRoles_KeyDown(object? sender, KeyEventArgs e)
        {
            // Check if Delete key was pressed
            if (e.KeyCode == Keys.Delete)
            {
                // Check if the selected row is read-only
                if (dgvRoles.SelectedRows.Count > 0 && dgvRoles.SelectedRows[0].ReadOnly)
                {
                    e.SuppressKeyPress = true; // Prevent the default delete behavior
                    MessageBox.Show("Cannot delete existing roles. Only newly added rows can be deleted.",
                        "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void DgvRoles_UserDeletedRow(object? sender, DataGridViewRowEventArgs e)
        {
            if(e.Row.ReadOnly)
            {
                rolesAux.Remove(e.Row);
            }
        }

        private void DgvRoles_UserAddedRow(object? sender, DataGridViewRowEventArgs e)
        {
            rolesAux.Add(e.Row);
        }

        private async void btnRefreshUsers_Click(object sender, EventArgs e)
        {
            await LoadDataGridView();
        }

        private async Task LoadDataGridView()
        {
            var allRoles = await roleService.GetRolesAsync();
            roles = allRoles;
            showRoles = new(allRoles);
            dgvRoles.DataSource = showRoles;
            for (int i = 0; i < dgvRoles.Rows.Count - 1; i++)
            {
                dgvRoles.Rows[i].ReadOnly = true;
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

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

    }
}
