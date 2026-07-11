namespace MissTortas.Services.Exceptions
{
    public class ProductNotFoundException : BusinessException
    {
        public ProductNotFoundException(string message, string? code = null) : base(message, code) { }
    }
}
