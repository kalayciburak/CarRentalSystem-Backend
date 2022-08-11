using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper {
    public class FileHelper : IFileHelper {
        public string AddFile(IFormFile file, string rootPath) {
            if (file == null) {
                return "place-holder-carImage.jpg";
            }
            
            if (!Directory.Exists(rootPath)) {
                Directory.CreateDirectory(rootPath);
            }

            var imageExtension = Path.GetExtension(file.FileName);
            var imageName = Guid.NewGuid() + imageExtension;

            using var fileStream = File.Create(rootPath + imageName);
            
            file.CopyTo(fileStream);
            fileStream.Flush();
            return imageName;

        }

        public string UpdateFile(IFormFile file, string filePath, string rootPath) {
            if (File.Exists(filePath)) {
                File.Delete(filePath);
            }

            return AddFile(file, rootPath);
        }

        public void DeleteFile(string filePath) {
            if (File.Exists(filePath)) {
                File.Delete(filePath);
            }
        }
    }
}