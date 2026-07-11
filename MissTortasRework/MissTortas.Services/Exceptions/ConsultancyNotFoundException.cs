namespace MissTortas.Services.Exceptions
{
    public class ConsultancyNotFoundException : BusinessException
    {
        public ConsultancyNotFoundException(string message, string? code = null) : base(message, code) { }
    }
}
