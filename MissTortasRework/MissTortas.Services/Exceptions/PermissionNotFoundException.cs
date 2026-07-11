namespace MissTortas.Services.Exceptions
{
    public class PermissionNotFoundException : BusinessException
    {
        public PermissionNotFoundException(string message, string? code = null) : base(message, code) { }
    }
}
