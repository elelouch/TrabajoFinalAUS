using System.Text.Json;

namespace Misstortas.Frontend.Services
{
    public static class MissTortasJsonOpts
    {
        public static JsonSerializerOptions SerializerOptions { get; } = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
}
