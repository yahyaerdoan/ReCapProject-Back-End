using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class ImageFileHelper
    {
        private static string directory = Environment.CurrentDirectory + "\\wwwroot";
        private static string path = @"\Images\";
        public static string Add(IFormFile file)
        {
            string extension = Path.GetExtension(file.FileName);
            string newGUID = CreateGuid() + extension;          
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string imagePath;
            using (FileStream fileStream = File.Create(directory + path + newGUID))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                imagePath = directory + path + newGUID;
            }
            return newGUID;
        }

        public static string Update(IFormFile file, string OldImagePath)
        {
            Delete(OldImagePath);
            return Add(file);            
        }
        
        public static void Delete(string ImagePath)
        {
            if (File.Exists(ImagePath.Replace("/", "\\")))  //&& Path.GetFileName(ImagePath) != "default.png")
            {
                File.Delete(ImagePath.Replace("/", "\\"));
            }
        }

        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString("N") + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year;
        }
    }
}
