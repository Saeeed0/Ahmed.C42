using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ahmed.C42.BLL.Common.Attachments
{
    public interface IAttatchmentService
    {
        string Upload(IFormFile file ,string folderName);
        bool Delete(string filePath);
    }
}
