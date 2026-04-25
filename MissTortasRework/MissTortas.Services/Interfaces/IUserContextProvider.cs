using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Interfaces
{
    public interface IUserContextProvider
    {
        public Task<UserContext> GetCurrentAsync();
    }
}
