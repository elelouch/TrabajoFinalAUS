using MissTortas.Desktop.Services.AuthService;
using MissTortas.Desktop.Services.Shared;
using MissTortas.Desktop.Services.UserService;
using MissTortas.Desktop.Forms.Users;
using MissTortas.Desktop.Forms.Roles;
using MissTortas.Desktop.Services.RoleService;
using MissTortas.Desktop.Services.PermissionService;

namespace MissTortas.Desktop.Forms
{
    public partial class formMain : Form
    {
        private readonly IMissTortasHttpClient httpClient;
        private readonly IRoleService roleService;
        private readonly IUserService usersService;
        private readonly IAuthService authService;
        private readonly IPermissionService permissionService;

        private formUsers? formUsers;
        private formRoles? formRoles;

        public formMain(
            IMissTortasHttpClient httpClient, 
            IUserService usersService, 
            IAuthService authService,
            IRoleService roleService,
            IPermissionService permissionService
        )
        {
            InitializeComponent();
            this.httpClient = httpClient;
            this.usersService = usersService;
            this.authService = authService;
            this.roleService = roleService;
            this.permissionService = permissionService;
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private async void formMain_Shown(object sender, EventArgs e)
        {
            var authService = new AuthService(httpClient);
            formLogin appLogin = new(authService);
            mainMenuStrip.Visible = false;
            var dialogRes = appLogin.ShowDialog();
            if (dialogRes != DialogResult.OK)
            {
                this.Dispose();
            }
            mainMenuStrip.Visible = true;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(formUsers == null)
            {
                this.formUsers = new formUsers(usersService, authService)
                {
                    MdiParent = this
                };
                this.formUsers.Show();
                this.formUsers.Disposed += FormUsers_Disposed;
            }
            else
            {
                this.formUsers.WindowState = FormWindowState.Normal;
                this.formUsers.BringToFront();
            }
            
        }

        private void FormUsers_Disposed(object? sender, EventArgs e)
        {
            this.formUsers = null;
        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (formRoles == null)
            {
                this.formRoles = new formRoles(roleService, permissionService)
                {
                    MdiParent = this
                };
                this.formRoles.Show();
                this.formRoles.Disposed += FormRoles_Disposed;
            }
            else
            {
                this.formRoles.WindowState = FormWindowState.Normal;
                this.formRoles.BringToFront();
            }

        }

        private void FormRoles_Disposed(object? sender, EventArgs e)
        {
            this.formRoles = null;
        }
    }
}
