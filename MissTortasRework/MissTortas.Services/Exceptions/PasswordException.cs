namespace MissTortas.Services.Exceptions
{
    public class PasswordException : BusinessException
    {
        public PasswordException(string message, string? code = null) : base(message, code) { }
    }
}
