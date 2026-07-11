namespace MissTortas.Services.Exceptions
{
    public class SaleProductNotFoundException : BusinessException
    {
        public SaleProductNotFoundException(string message, string? code = null) : base(message, code) { }
    }
}
