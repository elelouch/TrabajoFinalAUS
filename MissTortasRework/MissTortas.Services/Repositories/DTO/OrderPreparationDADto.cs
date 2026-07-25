using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Repositories.DTO
{
    public class OrderPreparationDADto
    {
        public long Id { get; set; }
        public string Detail { get; set; } = string.Empty;
        public bool Done { get; set; }
        public long AssigneeId { get; set; }
    }
}
