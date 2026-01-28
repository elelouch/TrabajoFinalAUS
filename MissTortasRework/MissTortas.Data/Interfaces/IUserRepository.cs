using MissTortas.Data.Entity.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Data.Interfaces
{
    public interface IUserRepository: IRepositoryCrud<ApplicationUser>
    {
    }
}
