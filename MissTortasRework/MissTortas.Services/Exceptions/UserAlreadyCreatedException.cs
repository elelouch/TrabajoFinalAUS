namespace MissTortas.Services.Exceptions
{
    public class UserAlreadyCreatedException : BusinessException
    {
        public UserAlreadyCreatedException(string message, string? code = null) : base(message, code) { }
    }
}
