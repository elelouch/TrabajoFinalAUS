namespace MissTortas.Services.Exceptions
{
    public class UserNotFoundException : BusinessException
    {
        public UserNotFoundException(string message, string? code = null) : base(message, code) { }
    }
}
