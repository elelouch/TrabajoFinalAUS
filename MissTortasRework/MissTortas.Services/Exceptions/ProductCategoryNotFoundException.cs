namespace MissTortas.Services.Exceptions
{
    public class ProductCategoryNotFoundException(string message) : EntityNotFoundException(message)
    {
    }
}
