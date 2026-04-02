namespace MissTortas.Services.Exceptions
{
    public class InvalidOrderPreparationStateException(string message) : InvalidStateException(message)
    {
    }
}
