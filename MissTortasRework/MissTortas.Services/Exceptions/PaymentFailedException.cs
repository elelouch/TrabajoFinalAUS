namespace MissTortas.Services.Exceptions
{
    public class PaymentFailedException : BusinessException
    {
        public PaymentFailedException(string message, string? code = null) : base(message, code) { }
    }
}
