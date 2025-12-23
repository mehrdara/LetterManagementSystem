
using Microsoft.AspNetCore.Http;

namespace Application.Interfaces
{
    public interface IFileService
    {
    Task<string> SaveFileAsync(IFormFile file,CancellationToken cancellationToken=default);
    bool RemoveFile(string path);
    }
}