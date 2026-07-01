using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.PermissionService
{
    public interface IPermissionService
    {
        public Task<List<string>> GetAllPermissionsAsync();
    }
}
