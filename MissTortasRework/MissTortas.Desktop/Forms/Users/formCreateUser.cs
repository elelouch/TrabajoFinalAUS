using MissTortas.Desktop.Events;
using MissTortas.Desktop.Model;
using MissTortas.Desktop.Services.AuthService;
using MissTortas.Desktop.Services.DTO;
using MissTortas.Desktop.Services.Shared;
using System.Net.Mail;

namespace MissTortas.Desktop.Forms
{
    public partial class formCreateUser : Form
    {
        private readonly IAuthService _authService;
        public event EventHandler<SignupCompletedArgs> SignUpCompleted;
        public formCreateUser(IAuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }
        private void RaiseSignUpCompleted(User user)
        {
            var handler = SignUpCompleted;
            if (handler == null)
            {
                return;
            }
            handler(this, new SignupCompletedArgs(user));
        }
        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtRepeatPassword.Text != txtPassword.Text)
            {
                MessageBox.Show(
                    "Las contraseñas no coinciden",
                    "Contraseña incorrecta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                txtRepeatPassword.Clear();
                txtPassword.Clear();
                return;
            }
            try
            {
                var mailAddres = new MailAddress(txtEmail.Text);
                var signUpRequest = new SignupRequest
                {
                    Username = txtUsername.Text,
                    Password = txtPassword.Text,
                    Email = txtEmail.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text
                };
                var userId = await _authService.SignUpAsync(signUpRequest);
                MessageBox.Show(
                    "Usuario registrado exitosamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                var newUser = new User
                {
                    Email = signUpRequest.Email,
                    FirstName = signUpRequest.FirstName,
                    LastName = signUpRequest.LastName,
                    UserId = Guid.Parse(userId ?? ""),
                    Enabled = false,
                    Username = signUpRequest.Username
                };
                RaiseSignUpCompleted(newUser);
                DialogResult = DialogResult.OK;
                Dispose();
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "El correo electrónico no es válido",
                    "Correo no válido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
