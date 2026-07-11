using System;
using System.Collections.Generic;
using System.Text;

namespace MissTortas.Services.Exceptions
{
    public abstract class BusinessException : Exception
    {
        public string? Code { get; }
        public IDictionary<string, object?> Extensions { get; } = new Dictionary<string, object?>();

        protected BusinessException(string message, string? code = null) : base(message)
        {
            Code = code;
        }
    }
}
