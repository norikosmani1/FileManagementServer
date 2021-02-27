using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FileManagementServer.Domain.Shared.Models;
using FileManagementServer.Infrastructure.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileManagementServer.Infrastructure.Data.Repositories
{
    public class FilesRepository : IFilesRepository
    {
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private Cloudinary _cloudinary;

        public FilesRepository(IOptions<CloudinarySettings> cloudinaryConfig)
        {
            _cloudinaryConfig = cloudinaryConfig;

            Account acc = new Account(
               _cloudinaryConfig.Value.CloudName,
               _cloudinaryConfig.Value.ApiKey,
               _cloudinaryConfig.Value.ApiSecret
               );

            _cloudinary = new Cloudinary(acc);
        }

        public string SaveFile(IFormFile file)
        {
            var uploadResult = new RawUploadResult();
            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new RawUploadParams()
                    {
                        File = new FileDescription(file.Name, stream)
                    };

                    uploadResult = _cloudinary.Upload(uploadParams);
                }
            }

            return uploadResult.SecureUrl.ToString();
        }
    }
}
