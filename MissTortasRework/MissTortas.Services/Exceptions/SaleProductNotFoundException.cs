namespace MissTortas.Services.Exceptions
{
    public class SaleProductNotFoundException(string message) : EntityNotFoundException(message)
    {
    }
}
