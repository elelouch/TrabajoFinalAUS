namespace MissTortas.Services.Exceptions
{
    public class OrderTypeNotFoundException(string message) : EntityNotFoundException(message)
    {
    }
}
