namespace MissTortas.Services.Exceptions
{
    public class ParentIsFinalException : BusinessException
    {
        public ParentIsFinalException(string message, string? code = null) : base(message, code) { }
    }
}
