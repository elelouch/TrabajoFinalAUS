using Microsoft.Extensions.Options;

namespace Misstortas.Frontend.Services.Files;

public class FileUrlBuilder(IOptions<APIHostsOptions> options) : IFileUrlBuilder
{
    public string GetUploadUrl(string filePath)
    {
        filePath = filePath.TrimStart('/');
        var endpoint = options.Value.APIBaseEndpoint;
        return $"{endpoint}uploads/{filePath}";
    }
}