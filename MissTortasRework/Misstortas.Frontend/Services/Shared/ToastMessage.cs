namespace Misstortas.Frontend.Services.Shared
{
    public class ToastMessage
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string Message { get; init; } = string.Empty;
        public ToastType Type { get; init; }
        public int DurationMs { get; init; } = 3000;

        public string BackgroundClass => Type switch
        {
            ToastType.Success => "bg-success-subtle",
            ToastType.Error => "bg-danger-subtle",
            ToastType.Warning => "bg-warning-subtle",
            ToastType.Info => "bg-info-subtle",
            _ => string.Empty
        };

        public string TextClass => Type switch
        {
            ToastType.Success => "text-success",
            ToastType.Error => "text-danger",
            ToastType.Warning => "text-warning-emphasis",
            ToastType.Info => "text-info",
            _ => string.Empty
        };
    }

    public enum ToastType
    {
        Success,
        Error,
        Warning,
        Info
    }
}
