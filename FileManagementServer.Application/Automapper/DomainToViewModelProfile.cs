using AutoMapper;
using FileManagementServer.Application.Shared.ViewModels;
using FileManagementServer.Application.ViewModels;
using FileManagementServer.Domain.Models;
using FileManagementServer.Domain.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManagementServer.Application.Automapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<FilesMetaData, FilesMetaDataViewModel>();
            CreateMap<FilesMetaDataFilterViewModel, FilesMetaDataFilterModel>();
            CreateMap<Settings, SettingsViewModel>();
        }
    }
}
