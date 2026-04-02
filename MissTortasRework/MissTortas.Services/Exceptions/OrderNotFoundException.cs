namespace MissTortas.Services.Exceptions
{
    public class OrderNotFoundException(string message) : EntityNotFoundException(message)
    {
    }
}
