using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManagementServer.Infrastructure.Data.Interfaces
{
    public interface IFilesRepository
    {
        string SaveFile(IFormFile file);
    }
}
