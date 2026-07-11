namespace MissTortas.Services.Exceptions
{
    public class InvalidStateException : BusinessException
    {
        public InvalidStateException(string message, string? code = null) : base(message, code) { }
    }
}
