using FileManagementServer.Domain.Models;
using FileManagementServer.Domain.Shared.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementServer.Infrastructure.Data.Interfaces
{
    public interface IFilesMetaDataRepository
    {
        Task<(IEnumerable<FilesMetaData> FilesMetaData, int TotalRecords)> GetFiles(FilesMetaDataFilterModel filter);

        Task<IEnumerable<FilesMetaData>> AddFiles(IFormFileCollection files);
    }
}
