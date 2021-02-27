using FileManagementServer.Domain.Context;
using FileManagementServer.Domain.Models;
using FileManagementServer.Domain.Shared.Models;
using FileManagementServer.Infrastructure.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FileManagementServer.Infrastructure.Data.Repositories
{
    public class FilesMetaDataRepository : GenericRepository, IFilesMetaDataRepository
    {
        private readonly FileManagementDBContext _ctx;
        private readonly IFilesRepository _filesRepository;

        public FilesMetaDataRepository(FileManagementDBContext ctx, IFilesRepository filesRepository) : base(ctx)
        {
            _ctx = ctx;
            _filesRepository = filesRepository;
        }

        public async Task<IEnumerable<FilesMetaData>> AddFiles(IFormFileCollection files)
        {
            List<FilesMetaData> filesList = new List<FilesMetaData>();

            foreach (var file in files)
            {
                string url = _filesRepository.SaveFile(file);
                if (!string.IsNullOrEmpty(url))
                {
                    FilesMetaData fileMetaData = new FilesMetaData();
                    fileMetaData.Url = url;
                    fileMetaData.Name = file.Name;
                    fileMetaData.Type = file.Name.Substring(file.Name.LastIndexOf('.') + 1);
                    fileMetaData.Size = file.Length / 1024;

                    await base.InsertAsync(fileMetaData);
                    await base.SaveChangesAsync();

                    filesList.Add(fileMetaData);
                }
            }

            return filesList;
        }

        public async Task<(IEnumerable<FilesMetaData> FilesMetaData, int TotalRecords)> GetFiles(FilesMetaDataFilterModel filter)
        {
            var filesMetaData = _ctx.FilesMetaData.Where(x => x.Type == filter.FileType);

            SortOrder(ref filesMetaData, filter.SortField, filter.SortOrder);

            var filesMetaDataList = await filesMetaData.Skip(filter.First).Take(filter.Rows).ToListAsync();

            //var filesMetaData = await _ctx.FilesMetaData
            //    .Where(x => x.Type == filter.FileType)
            //    .Skip(filter.First)
            //    .Take(filter.Rows)
            //    .ToListAsync();

            var totalRecords = await _ctx.FilesMetaData
                .Where(x => x.Type == filter.FileType)
                .CountAsync();

            return (filesMetaDataList, totalRecords);
        }

        private void SortOrder(ref IQueryable<FilesMetaData> files, string sortField, int sortOrder)
        {
            switch (sortField)
            {
                case "name":
                    files = sortOrder == 1 ? files.OrderBy(f => f.Name) : files.OrderByDescending(f => f.Name);
                    break;
                case "size":
                    files = sortOrder == 1 ?  files.OrderBy(f => f.Size) : files.OrderByDescending(f => f.Size);
                    break;
                case "createdAt":
                    files = sortOrder == 1 ? files.OrderBy(f => f.CreatedAt) : files.OrderByDescending(f => f.CreatedAt);
                    break;
                default:
                    files = files.OrderByDescending(s => s.CreatedAt);
                    break;
            }
        }
    }
}
