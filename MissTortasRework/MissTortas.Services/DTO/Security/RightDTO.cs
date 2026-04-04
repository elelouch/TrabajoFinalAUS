using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.DTO.Security
{
    public class RightDTO
    {
        public long ResourceId;
        public long SubjectId;
        public int AccessType;
        public bool Transferable;
    }
}
