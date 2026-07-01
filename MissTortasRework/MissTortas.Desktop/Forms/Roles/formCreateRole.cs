using MissTortas.Desktop.Events;
using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.AuthService;
using MissTortas.Desktop.Services.DTO;
using MissTortas.Desktop.Services.RoleService;
using System.Net.Mail;

namespace MissTortas.Desktop.Forms.Roles
{
    public partial class formCreateRole : Form
    {
        private readonly IRoleService roleService;
        public event EventHandler<RoleCreatedArgs> OnRoleCreated;
        public formCreateRole(IRoleService roleService)
        {
            InitializeComponent();
            this.roleService = roleService;
        }

        private void RaiseRoleCreated(Role role)
        {
            var handler = OnRoleCreated;
            if (handler == null)
            {
                return;
            }
            handler(this, new RoleCreatedArgs(role));
        }
        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            var roleName = txtRoleName.Text;
            if(roleName.Length > 256 || roleName.Length < 3)
            {
                MessageBox.Show("Role name must be between 3 and 256 characters");
                return;
            }
            try
            {
                var newRole = await roleService.CreateRoleAsync(roleName);
                MessageBox.Show("Creation successful", "Role Creation", MessageBoxButtons.OK);
                RaiseRoleCreated(newRole);
                Dispose();
            }
            catch
            {
                MessageBox.Show("An error happened during role creation");
            }
        }

        private void formCreateUser_Load(object sender, EventArgs e)
        {

        }

        private void lblFirstName_Click(object sender, EventArgs e)
        {

        }
    }
}
