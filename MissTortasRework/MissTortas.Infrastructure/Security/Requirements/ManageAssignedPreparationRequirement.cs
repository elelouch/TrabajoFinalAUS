using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Infrastructure.Security.Requirements
{
    public class ManageAssignedPreparationRequirement(long preparationId, long userId) : IAuthorizationRequirement
    {
        public long PreparationId { get; set; } = preparationId;
        public long UserId { get; set; } = userId;
    }
}
