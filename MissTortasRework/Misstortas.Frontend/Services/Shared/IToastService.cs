namespace Misstortas.Frontend.Services.Shared
{
    public interface IToastService
    {
        event Action<ToastMessage>? OnToast;

        void Success(string message);
        void Error(string message);
        void Warning(string message);
        void Info(string message);
    }
}
