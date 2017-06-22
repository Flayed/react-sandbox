using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace Ufo.Services
{
    public interface IFileService
    {
        string ReadAssetFileContents(string fileName);
    }

    public class FileService : IFileService
    {
        public string ReadAssetFileContents(string fileName)
        {
            string filepath = HostingEnvironment.MapPath($"~/Assets/Data/{fileName}");
            if (string.IsNullOrWhiteSpace(filepath)) return "";
            return !File.Exists(filepath) ? "" : File.ReadAllText(filepath);
        }    
    }
}