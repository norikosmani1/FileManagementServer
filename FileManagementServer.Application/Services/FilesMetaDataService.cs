using AutoMapper;
using FileManagementServer.Application.Interfaces;
using FileManagementServer.Application.Shared.ViewModels;
using FileManagementServer.Application.ViewModels;
using FileManagementServer.Domain.Models;
using FileManagementServer.Domain.Shared.Models;
using FileManagementServer.Infrastructure.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementServer.Application.Services
{
    public class FilesMetaDataService : IFilesMetaDataService
    {
        private readonly IMapper _mapper;
        private readonly IFilesMetaDataRepository _filesMetaDataRepository;
        private readonly IFilesRepository _filesRepository;

        public FilesMetaDataService(IMapper mapper, IFilesMetaDataRepository filesMetaDataRepository, IFilesRepository filesRepository)
        {
            _mapper = mapper;
            _filesMetaDataRepository = filesMetaDataRepository;
            _filesRepository = filesRepository;
        }

        public async Task<IEnumerable<FilesMetaDataViewModel>> AddFiles(IFormFileCollection files)
        {
            var result = await _filesMetaDataRepository.AddFiles(files);
            return _mapper.Map<IEnumerable<FilesMetaDataViewModel>>(result);
        }

        public async Task<(IEnumerable<FilesMetaDataViewModel> FilesMetaData, int TotalRecords)> GetFiles(FilesMetaDataFilterViewModel filterViewModel)
        {
            var filter = _mapper.Map<FilesMetaDataFilterModel>(filterViewModel);
            var result = await _filesMetaDataRepository.GetFiles(filter);
            var filesMetaData = _mapper.Map<IEnumerable<FilesMetaDataViewModel>>(result.FilesMetaData);
            return (filesMetaData, result.TotalRecords);
        }
    }
}
