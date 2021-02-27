using FileManagementServer.Application.Shared.ViewModels;
using FileManagementServer.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementServer.Application.Interfaces
{
    public interface IFilesMetaDataService
    {
        Task<(IEnumerable<FilesMetaDataViewModel> FilesMetaData, int TotalRecords)> GetFiles(FilesMetaDataFilterViewModel filter);

        Task<IEnumerable<FilesMetaDataViewModel>> AddFiles(IFormFileCollection files);
    }
}
