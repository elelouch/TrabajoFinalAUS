using MissTortas.Desktop.Services.DTO;
using System.Net;

namespace MissTortas.Desktop.Services.Shared
{
    public class ApiException : Exception
    {
        public ProblemDetailsDto Problem { get; }
        public HttpStatusCode StatusCode { get; }

        public ApiException(ProblemDetailsDto problem, HttpStatusCode statusCode)
            : base(problem.Detail ?? problem.Title ?? "Request failed")
        {
            Problem = problem;
            StatusCode = statusCode;
        }
    }
}
