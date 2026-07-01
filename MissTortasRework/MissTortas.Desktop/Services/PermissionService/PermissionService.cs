using MissTortas.Desktop.Services.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.PermissionService
{
    public class PermissionService : IPermissionService
    {
        private readonly IMissTortasHttpClient httpClient;
        public PermissionService(IMissTortasHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<string>> GetAllPermissionsAsync()
        {
            var permissions = await httpClient.GetAsync<string[]>("permissions");
            return permissions is null? [] : [..permissions];
        }
    }
}
