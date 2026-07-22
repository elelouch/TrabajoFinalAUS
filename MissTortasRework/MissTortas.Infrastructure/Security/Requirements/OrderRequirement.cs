using Microsoft.AspNetCore.Authorization;

namespace MissTortas.Infrastructure.Security.Requirements
{
    public class OrderRequirement(OrderOperation operation) : IAuthorizationRequirement
    {
        public OrderOperation Operation { get; set; } = operation; 
    }
    public enum OrderOperation
    {
        Read,
        Write,
        Delete
    }
}
