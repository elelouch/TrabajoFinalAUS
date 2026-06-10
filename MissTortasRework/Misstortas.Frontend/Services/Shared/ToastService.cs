namespace Misstortas.Frontend.Services.Shared
{
    public class ToastService : IToastService
    {
        public event Action<ToastMessage>? OnToast;

        public void Success(string message)
        {
            OnToast?.Invoke(new ToastMessage
            {
                Message = message,
                Type = ToastType.Success
            });
        }

        public void Error(string message)
        {
            OnToast?.Invoke(new ToastMessage
            {
                Message = message,
                Type = ToastType.Error
            });
        }

        public void Warning(string message)
        {
            OnToast?.Invoke(new ToastMessage
            {
                Message = message,
                Type = ToastType.Warning
            });
        }

        public void Info(string message)
        {
            OnToast?.Invoke(new ToastMessage
            {
                Message = message,
                Type = ToastType.Info
            });
        }
    }
}
