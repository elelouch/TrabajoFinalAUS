namespace MissTortas.Data.Entity.Security.Orders
{
    public class PermissionOrder : Permission
    {
        public required CreateOrderPermission CreateOrderPermission { get; set; }
    }
}
