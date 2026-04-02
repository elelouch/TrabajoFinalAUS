namespace MissTortas.Services.Exceptions
{
    public class PermissionNotFound(string message) : EntityNotFoundException(message)
    {
    }
}
