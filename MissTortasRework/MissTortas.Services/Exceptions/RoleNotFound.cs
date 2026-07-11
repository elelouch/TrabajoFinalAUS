namespace MissTortas.Services.Exceptions
{
    public class RoleNotFound : BusinessException
    {
        public RoleNotFound(string message, string? code = null) : base(message, code) { }
    }
}
