using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Headers;
using MissTortas.Desktop.Services.AuthService;

namespace MissTortas.Desktop.Services
{
    public sealed class MissTortasHttpClient
    {
        private static MissTortasHttpClient? misstortasHttpClient;
        private readonly HttpClient _Client = new();

        public HttpClient Client
        {
            get { return _Client; }
        }

        public static MissTortasHttpClient Instance
        {
            get
            {
                if (misstortasHttpClient is null)
                {
                    misstortasHttpClient = new MissTortasHttpClient();
                    misstortasHttpClient.ConfigureClient();
                }

                misstortasHttpClient.SetAuthorizationHeader();
                return misstortasHttpClient;
            }
        }
        private void ConfigureClient()
        {
            _Client.DefaultRequestHeaders.Accept.Clear();
            _Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            _Client.BaseAddress = new Uri("https://localhost:7245/");
        }
        private void SetAuthorizationHeader()
        {
            if (!string.IsNullOrEmpty(MissTortasToken.AccessToken))
            {
                _Client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", MissTortasToken.AccessToken);
            }
            else
            {
                _Client.DefaultRequestHeaders.Authorization = null;
            }
        }
    }
}
