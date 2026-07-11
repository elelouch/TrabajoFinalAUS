namespace MissTortas.Services.Exceptions
{
    public class SaleProductAlreadyAssociatedException : BusinessException
    {
        public SaleProductAlreadyAssociatedException(string message, string? code = null) : base(message, code) { }
    }
}
