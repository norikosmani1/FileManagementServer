using FileManagementServer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementServer.Infrastructure.Data.Interfaces
{
    public interface ISettingsRepository
    {
        Task<IEnumerable<Settings>> GetSettings();
    }
}
