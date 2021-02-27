using FileManagementServer.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementServer.Application.Interfaces
{
    public interface ISettingsService
    {
        Task<IEnumerable<SettingsViewModel>> GetSettings();
    }
}
