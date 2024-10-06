using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ahmed.C42.BLL.Common.Attachments
{
    public class AttachmentService : IAttatchmentService
    {
        private List<string> _allowedExtensions = new(){ ".png", ".jpg", ".jpeg" };
        private const int _allowedMaxSive = 20_971_52;

        public string Upload(IFormFile file, string folderName)
        {
            var extension = Path.GetExtension(file.FileName);

            if (!_allowedExtensions.Contains(extension))
                //return null;
                throw new InvalidOperationException("Invalid file extension.");

            if (file.Length > _allowedMaxSive)
                //return null;
                throw new InvalidOperationException("File size exceeds the limit.");

            //var folderPath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\files\\{folderName}";
            //var folderPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\files", folderName);
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", folderName);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = $"{Guid.NewGuid()}{extension}";//must be unique

            var filePath = Path.Combine(folderPath, fileName);

            /// streaming : Data Per Time
            using var fileStream = new FileStream(filePath, FileMode.Create);

            //using var fileStream = File.Create(filePath);

            file.CopyTo(fileStream);

            return fileName;
        }
        public bool Delete(string filePath)
        {
            if(File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;    
            }
            return false;

        }

    }
}
