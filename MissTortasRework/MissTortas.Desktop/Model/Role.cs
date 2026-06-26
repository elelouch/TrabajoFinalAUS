using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Desktop.Model
{
    public class Role
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public IEnumerable<string> Permissions { get; set; } = [];
    }
}
