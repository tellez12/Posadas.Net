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
            
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, file),
                Tags = tags,
                Folder = folder,
              
            };

            var uploadResult = Servers[index].Upload(uploadParams);

            return new UploadResult(uploadResult,index);
        }

        private static Cloudinary[] _servers;
        public static Cloudinary[] Servers
        {
            get
            {
                if (_servers == null)
                {
                    InitServers();
                }
                    return _servers;
            }
        }

        private static void InitServers()
        {
            var numServers = CloudinaryKey.Split(',').Length;
            _servers=new Cloudinary[numServers];
            var names = CloudinaryName.Split(',');
            var keys =CloudinaryKey.Split(',');
            var secret = CloudinarySecret.Split(',');
            for (var i = 0; i < numServers; i++)
            {
                var account = new Account(
              names[i],
              keys[i],
              secret[i]);

               _servers[i] = new Cloudinary(account);
            }
            
        }
    }
}
