using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;


namespace Posadas.Utils
{
    public class CloudinaryService
    {
        public static string CloudinaryName = ConfigurationManager.AppSettings["cloudinaryName"];
        public static string CloudinaryKey = ConfigurationManager.AppSettings["cloudinaryKey"];
        public static string CloudinarySecret = ConfigurationManager.AppSettings["cloudinarySecret"];

        public static UploadResult UploadFile(string fileName,Stream file,string folder="",string tags ="")
        {
            int numServers=CloudinaryKey.Split(',').Length;
            Random rnd = new Random();
            int index = rnd.Next(0, numServers);
            var account = new Account(
              CloudinaryName.Split(',')[index],
              CloudinaryKey.Split(',')[index],
              CloudinarySecret.Split(',')[index]);

            var cloudinary = new Cloudinary(account);
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, file),
                Tags = tags,
                Folder = folder
            };

            var uploadResult = cloudinary.Upload(uploadParams);

            return new UploadResult(uploadResult);
        }
    }
}
