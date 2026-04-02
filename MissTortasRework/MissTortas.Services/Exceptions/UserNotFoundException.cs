namespace MissTortas.Services.Exceptions
{
    public class UserNotFoundException(string message) : EntityNotFoundException(message)
    {
    }
}
