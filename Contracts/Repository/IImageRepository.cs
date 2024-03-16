using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Repository
{
    public interface IImageRepository
    {
        Task<string> Upload(IFormFile file);
        bool Delete(string pathFile);
    }
}
