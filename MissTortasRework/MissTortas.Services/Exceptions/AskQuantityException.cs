namespace MissTortas.Services.Exceptions
{
    public class AskQuantityException : BusinessException
    {
        public AskQuantityException(string message, string? code = null) : base(message, code) { }
    }

}
