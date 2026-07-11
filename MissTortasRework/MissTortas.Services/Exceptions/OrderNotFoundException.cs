namespace MissTortas.Services.Exceptions
{
    public class OrderNotFoundException : BusinessException
    {
        public OrderNotFoundException(string message, string? code = null) : base(message, code) { }
    }
}
