using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper {
    public interface IFileHelper {
        string AddFile(IFormFile file, string rootPath);
        string UpdateFile(IFormFile file, string filePath, string rootPath);
        void DeleteFile(string filePath);
    }
}