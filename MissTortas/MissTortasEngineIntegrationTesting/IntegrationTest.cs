using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MissTortasMid2.BakeryTasks.Dto;
using MissTortasMid2.BakeryTasks.Controllers;
using MissTortasMid2;
using Newtonsoft.Json.Linq;

namespace MissTortasEngineIntegrationTesting
{
    public class IntegrationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        public IntegrationTest(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/tasks")]
        public async Task Post_EndpointReturnSuccessAndCorrectContentType(string url)
        {
            var client = _factory.CreateClient();
            var bakeryTask = new BakeryTaskDto { Description = "testing", Name = "Name" };
            var response = await client.PostAsJsonAsync(url, bakeryTask);

            response.EnsureSuccessStatusCode();

            var returnValue = await response.Content.ReadAsStringAsync();
            Assert.True(returnValue.Length > 0);
        }

        [Theory]
        [InlineData("/tasks")]
        public async Task PostEndpointReturnFailed(string url)
        {
            var client = _factory.CreateClient();
            var bakeryTask = new BakeryTaskDto { Description = "", Name = "" };
            var response = await client.PostAsJsonAsync(url, bakeryTask);

            Assert.True(!response.IsSuccessStatusCode);

            var returnValue = await response.Content.ReadAsStringAsync();
            Assert.True(returnValue.Length > 0);
        }

    }
}