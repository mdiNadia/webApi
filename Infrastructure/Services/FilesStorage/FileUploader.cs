using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.FilesStorage
{
    public class FileUploader : IFileUploader
    {
        public async Task<string> UploadFile(IFormFile file)
        {
            string path = "";
            try
            {
                if (file.Length > 0)
                {
                    path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, "UploadedFiles/Images"));
                    var filename =Path.GetFileNameWithoutExtension(file.FileName) + Guid.NewGuid();
                    var extension = Path.GetExtension(file.FileName);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (var fileStream = new FileStream(Path.Combine(path, filename + extension), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return filename + extension;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("File Copy Failed", ex);
            }
        }
    }
}
