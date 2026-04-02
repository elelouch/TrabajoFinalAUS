namespace MissTortas.Services.Exceptions
{
    public class RoleNotFound(string message) : EntityNotFoundException(message)
    {
    }
}
