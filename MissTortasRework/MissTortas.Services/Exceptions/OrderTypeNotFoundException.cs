namespace MissTortas.Services.Exceptions
{
    public class OrderTypeNotFoundException : BusinessException
    {
        public OrderTypeNotFoundException(string message, string? code = null) : base(message, code) { }
    }
}
