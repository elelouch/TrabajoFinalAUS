namespace MissTortas.View.DTO.Error
{
    public class ErrorDTO
    {
        public string Message { get; set; } = "";
        public string Code { get; set; } = "";
        public required Object Details { get; set; }
    }
}
