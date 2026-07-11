using System.Text.Json;
using System.Text.Json.Serialization;

namespace MissTortas.Desktop.Services.DTO
{
    public class ProblemDetailsDto
    {
        public string? Type { get; set; }
        public string? Title { get; set; }
        public int? Status { get; set; }
        public string? Detail { get; set; }
        public string? Instance { get; set; }

        [JsonExtensionData]
        public Dictionary<string, JsonElement>? Extensions { get; set; }

        public string? Code =>
            Extensions?.TryGetValue("code", out var v) == true ? v.GetString() : null;

        public string? TraceId =>
            Extensions?.TryGetValue("traceId", out var v) == true ? v.GetString() : null;
    }
}
