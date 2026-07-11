namespace MissTortas.Services.Exceptions
{
    public class AlreadyCreatedException : BusinessException
    {
        public AlreadyCreatedException(string message, string? code = null) : base(message, code) { }
    }
}
