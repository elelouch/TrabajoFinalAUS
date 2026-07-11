namespace MissTortas.Services.Exceptions
{
    public class ProductCategoryNotFoundException : BusinessException
    {
        public ProductCategoryNotFoundException(string message, string? code = null) : base(message, code) { }
    }
}
