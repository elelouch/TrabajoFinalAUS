using System.Text;
using System.Text.Json;

namespace Misstortas.Frontend.Services.Auth
{
    public class AuthClient(HttpClient httpClient) : IAuthClient
    {
        public async Task SignInUserAsync(UserSignin userSignin)
        {
            var res = await httpClient.PostAsJsonAsync("/auth/signin",userSignin);
            if(!res.IsSuccessStatusCode)
            {

                StringBuilder sb = new();

                foreach (var header in res.Headers)
                {
                    sb.AppendLine($"{header.Key}: {string.Join(", ", header.Value)}");
                }

                foreach (var header in res.Content.Headers)
                {
                    sb.AppendLine($"{header.Key}: {string.Join(", ", header.Value)}");
                }

                string allHeaders = sb.ToString();
                Console.WriteLine(allHeaders);
            }
        }

        public async Task TestEndpoint()
        {
            Console.WriteLine(httpClient.BaseAddress);
            var res = await httpClient.GetFromJsonAsync<JsonElement>("/auth/test");
            Console.WriteLine(res.ToString());
        }
    }
}
