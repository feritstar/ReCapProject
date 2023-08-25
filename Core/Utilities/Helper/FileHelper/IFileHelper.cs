using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helper.FileHelper
{
    public interface IFileHelper
    {
        string Upload(IFormFile file, string rootDirectory);
        void Delete(string filePath);
        string Update(IFormFile file, string filePath, string rootDirectory);
    }
}
