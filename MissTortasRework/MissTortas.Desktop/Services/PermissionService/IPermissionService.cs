namespace MissTortas.Desktop.Services.PermissionService
{
    public interface IPermissionService
    {
        public Task<List<string>> GetAllPermissionsAsync();
    }
}
