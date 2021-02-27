using AutoMapper;
using FileManagementServer.Application.Interfaces;
using FileManagementServer.Application.ViewModels;
using FileManagementServer.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementServer.Application.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _settingsRepository;
        private readonly IMapper _mapper;

        public SettingsService(ISettingsRepository settingsRepository, IMapper mapper)
        {
            _settingsRepository = settingsRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SettingsViewModel>> GetSettings()
        {
            var result = await _settingsRepository.GetSettings();
            return _mapper.Map<IEnumerable<SettingsViewModel>>(result);
        }
    }
}
