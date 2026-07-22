using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Services.DTO
{
    public class CreatePreparationRequest
    {
        public long OrderId { get; set; }
        public string Detail { get; set; } = string.Empty;
        public string AssigneeId { get; set; } = string.Empty;
    }
}
