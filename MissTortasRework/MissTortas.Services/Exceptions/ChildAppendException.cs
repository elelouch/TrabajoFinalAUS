namespace MissTortas.Services.Exceptions
{
    public class ChildAppendException : BusinessException
    {
        public ChildAppendException(string message, string? code = null) : base(message, code) { }
    }
}
