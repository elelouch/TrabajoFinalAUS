namespace MissTortas.Desktop.Services.Shared
{
    public class SessionExpiredException : Exception
    {
        public SessionExpiredException(string message) : base(message) { }
    }

}
