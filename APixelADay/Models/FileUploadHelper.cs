using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APixelADay.Models
{
    public static class FileUploadHelper
    {
         public enum FileTypes
        {
            Photo
        }
        public static bool IsFileEmpty(IFormFile file)
        {
            if(file.Length == 0)
            {
                return true;
            }
            return false;
        }
        //picture validation
        public static bool IsValidExtension(IFormFile file, FileTypes type)
        {
            string extension = Path.GetExtension(file.FileName).ToLower();
            string[] photoExtensions = { ".png", ".gif" };
            if (photoExtensions.Contains(extension))
            {
                return true;
            }

            return false;
        }
    }
}
