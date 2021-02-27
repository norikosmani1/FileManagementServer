using FileManagementServer.Domain.Context;
using FileManagementServer.Domain.Models;
using FileManagementServer.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementServer.Infrastructure.Data.Repositories
{
    public class SettingsRepository : GenericRepository, ISettingsRepository
    {
        private readonly FileManagementDBContext _ctx;

        public SettingsRepository(FileManagementDBContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        public async Task<IEnumerable<Settings>> GetSettings()
        {
            return await base.GetAllAsync<Settings>();
        }
    }
}
