using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.DTO.Orders
{
    public class CreateConsultancyDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IEnumerable<IFormFile> Files { get; set; } = [];
        public string UploadPath { get; set; } = string.Empty;
        public long AssigneeId { get; set; }
        public long ClientId { get; set; }

    }
}
