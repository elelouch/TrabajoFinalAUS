using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.DTO.Payment
{
    public class PaymentMethodDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
