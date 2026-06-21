using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Headers;

namespace MissTortas.Desktop.Services
{
    public sealed class MissTortasHttpClient
    {
        private static MissTortasHttpClient? misstortasHttpClient;
        private HttpClient _Client = new();

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
                    misstortasHttpClient._Client.DefaultRequestHeaders.Accept.Clear();
                    misstortasHttpClient._Client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json")
                        );
                    misstortasHttpClient._Client.BaseAddress = new Uri("https://localhost:7245/");
                }
                return misstortasHttpClient;
            }
        }
    }
}
