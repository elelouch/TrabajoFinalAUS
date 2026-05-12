using MissTortas.Domain.Security.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Repositories.DTO
{
    public class ProductCategoryRightsDto
    {
        public long ProductCategoryId { get; set; }
        public IEnumerable<Right> Rights { get; set; } = [];
        public bool IsFinal { get; set; }
    }
}
