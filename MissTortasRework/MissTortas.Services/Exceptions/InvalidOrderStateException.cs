namespace MissTortas.Services.Exceptions
{
    public class InvalidOrderStateException(string message) : InvalidStateException(message)
    {
    }
}
