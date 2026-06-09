namespace Misstortas.Frontend.Services
{
    public class ToastService
    {
        public event Action<string>? OnSuccess;

        public void Success(string message)
        {
            OnSuccess?.Invoke(message);
        }
    }
}
