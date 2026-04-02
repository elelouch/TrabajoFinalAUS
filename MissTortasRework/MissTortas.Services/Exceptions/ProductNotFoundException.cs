namespace MissTortas.Services.Exceptions
{
    public class ProductNotFoundException(string message) : EntityNotFoundException(message)
    {
    }
}
