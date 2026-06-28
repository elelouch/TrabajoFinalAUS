namespace MissTortas.Desktop.Services.AuthService
{
    public class UserCapabilities
    {
        public bool CanManageSecurity { get; set; }
        public bool CanManageProducts { get; set; }
        public bool CanManageOrders { get; set; }
        public bool CanManagePayments { get; set; }
    }
}
