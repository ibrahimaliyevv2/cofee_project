using CofeeProject.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;

namespace CofeeProject.Helpers
{
    public class FileManager
    {
        public static string Save(string root, string folder, IFormFile file)
        {
            var newFIleName = Guid.NewGuid().ToString() + (file.FileName.Length>64?file.FileName.Substring(file.FileName.Length - 64, 64):file.FileName);
            string path = Path.Combine(root, folder, newFIleName);

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return newFIleName;
        }

        public static bool Delete(string root, string folder, string filename)
        {
            string path = Path.Combine(root, folder, filename);

            if(File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }
    }
}
