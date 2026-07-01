using MissTortas.Desktop.Forms;
using MissTortas.Desktop.Services.AuthService;
using MissTortas.Desktop.Services.PermissionService;
using MissTortas.Desktop.Services.RoleService;
using MissTortas.Desktop.Services.Shared;
using MissTortas.Desktop.Services.UserService;

namespace MissTortas.Desktop
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var httpClient = new MissTortasHttpClient();
            var authService = new AuthService(httpClient);
            var usersService = new UserService(httpClient);
            var rolesService = new RoleService(httpClient);
            var permissionService = new PermissionService(httpClient);
            Application.Run(new formMain(httpClient, usersService, authService, rolesService, permissionService));
            //Application.Run(new formUsers(usersService, authService));
        }
    }
}