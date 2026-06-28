using MissTortas.Desktop.Services.AuthService;
using MissTortas.Desktop.Services.DTO;

namespace MissTortas.Desktop.Forms
{
    public partial class formLogin : Form
    {
        private IAuthService _authService;
        public formLogin(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            var dto = new SigninRequest
            {
                Email = this.txtUsername.Text,
                Password = this.txtPassword.Text
            };
            try
            {
                await _authService.SignInAsync(dto);
                this.DialogResult = DialogResult.OK;
            }
            catch (HttpRequestException exc)
            {
                MessageBox.Show(
                    $"Username or password invalid. Try again. Error: {exc.Message}",
                    "SignIn",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
