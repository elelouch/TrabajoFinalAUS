namespace MissTortas.Data.Entity.Security.Permissions
{
    public class PermissionCreateOrder : Permission
    {
        public CreateOrderPermission CreateOrderPermission { get; set; }
    }
    public enum CreateOrderPermission
    {
        CreateOrder = 1,
        CreateOrderOBO = 2
    }
}
