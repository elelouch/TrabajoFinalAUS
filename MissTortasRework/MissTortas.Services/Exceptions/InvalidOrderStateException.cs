namespace MissTortas.Services.Exceptions
{
    public class InvalidOrderStateException : BusinessException
    {
        public InvalidOrderStateException(string message, string? code = null) : base(message, code) { }
    }
}
