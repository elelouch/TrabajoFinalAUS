using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Infrastructure.Security.Requirements
{
    public class ManageAssignedPreparationRequirement(PreparationOperationEnum op) : IAuthorizationRequirement
    {
        public PreparationOperationEnum Operation { get; set; } = op;
    }
    public enum PreparationOperationEnum
    {
        Read,
        Write
    }
}
