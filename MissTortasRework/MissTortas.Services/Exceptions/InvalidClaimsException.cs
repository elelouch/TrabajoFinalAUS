namespace MissTortas.Services.Exceptions
{
    public class InvalidClaimsException : BusinessException
    {
        public InvalidClaimsException(string message, string? code = null) : base(message, code) { }
    }
}
