using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;

namespace MyShop.Extensions
{
    public static class FileHelper
    {
        public static async Task<string> SaveFile(this IFormFile file, string FolderName)
        {
            var filetypes = new List<string>()
            {
                ".jpg",
                ".jpeg",
                ".png",
                "heic",
                ".heif"
            };

            if (file is null)
                throw new EntityBadRequestException<Image>();
            string folder = $"Images/{FolderName}/";
            var path = Path.Combine("wwwroot", folder);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var fileExtension = Path.GetExtension(file.FileName);

            if(!filetypes.Contains(fileExtension))
            {
                throw new BadImageFormatException("image is null");
            }
            var FileName = Guid.NewGuid().ToString("N") + fileExtension;
            var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            await File.WriteAllBytesAsync(Path.Combine(path, FileName), ms.ToArray());

            var imagePath = Path.Combine(folder, FileName);

            return imagePath;
        }
    }
}
