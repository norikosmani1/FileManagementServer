using FileManagementServer.Application.Interfaces;
using FileManagementServer.Application.Services;
using FileManagementServer.Domain.Context;
using FileManagementServer.Domain.Shared.Models;
using FileManagementServer.Infrastructure.Data.Helpers;
using FileManagementServer.Infrastructure.Data.Interfaces;
using FileManagementServer.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace FileManagementServer.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer 
            services.AddScoped<IFilesMetaDataService, FilesMetaDataService>();
            services.AddScoped<ISettingsService, SettingsService>();

            //Infrastructure.Data Layer
            services.AddScoped<IFilesMetaDataRepository, FilesMetaDataRepository>();
            services.AddScoped<IFilesRepository, FilesRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();

            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                    .AddJsonFile(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/appsettings.json").Build();
            var connectionString = configuration.GetConnectionString(DataConstants.AppSettings.ConnectionString);

            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));

            services.AddDbContext<FileManagementDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }
    }
}

