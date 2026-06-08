namespace Misstortas.Frontend.Services.Files;

public interface IFileUrlBuilder
{
    string GetUploadUrl(string filePath);
}