using MissTortas.Desktop.Services.AuthService;
using MissTortas.Desktop.Services.DTO;
using MissTortas.Desktop.Services.Shared;

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
            catch (ApiException ex) when (ex.Problem.Code == "USR2F1")
            {
                // requires two-factor — handle distinctly from a generic error
                // e.g. open a 2FA form here instead of showing a message box
                ErrorDisplay.Show(this, ex);
            }
            catch (Exception ex)
            {
                ErrorDisplay.Show(this, ex);
            }
        }
    }
}
