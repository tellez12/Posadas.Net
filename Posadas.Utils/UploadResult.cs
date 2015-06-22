using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;

namespace Posadas.Utils
{
    public class UploadResult
    {
        public string PublicId { get; set; }
        public string DeleteToken { get; set; }

        public string Url { get; set; }

        public string SecureUrl { get; set; }

        public UploadResult()
        {
            
        }
        public UploadResult(ImageUploadResult result)
        {
            PublicId = result.PublicId;
            Url = result.Uri.AbsoluteUri;
            SecureUrl = result.SecureUri.AbsoluteUri;
            DeleteToken = result.DeleteToken;
        }
      
    }
}
