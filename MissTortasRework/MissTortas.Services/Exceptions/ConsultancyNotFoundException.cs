namespace MissTortas.Services.Exceptions
{
    public class ConsultancyNotFoundException(string message) : EntityNotFoundException(message)
    {
    }
}
