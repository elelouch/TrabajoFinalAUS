namespace MissTortas.Services.Exceptions
{
    public class EntityNotFoundException : BusinessException
    {
        public EntityNotFoundException(string message, string? code = null) : base(message, code) { }
    }
}
