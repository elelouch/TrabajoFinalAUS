namespace MissTortas.Services.Exceptions
{
    public class InvalidOrderPreparationStateException : BusinessException
    {
        public InvalidOrderPreparationStateException(string message, string? code = null) : base(message, code) { }
    }
}
