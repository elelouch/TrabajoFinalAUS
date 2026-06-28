namespace MissTortas.Desktop.Services.DTO
{
    public class ErrorDTO
    {
        public string Message { get; set; } = "";
        public string Code { get; set; } = "";
        public Object? Details { get; set; }
    }
}
