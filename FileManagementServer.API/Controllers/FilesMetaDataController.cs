using FileManagementServer.Application.Interfaces;
using FileManagementServer.Application.Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileManagementServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesMetaDataController : ControllerBase
    {
        private readonly IFilesMetaDataService _filesMetaDataService;

        public FilesMetaDataController(IFilesMetaDataService filesMetaDataService)
        {
            _filesMetaDataService = filesMetaDataService;
        }

        [HttpPost("addFiles")]
        public async Task<IActionResult> AddFiles()
        {
            try
            {
                var files = await _filesMetaDataService.AddFiles(Request.Form.Files);
                return Ok(files);
            }
            catch (Exception ex)
            {
                return BadRequest("Something failed, couldn't upload files!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetFiles([FromQuery] FilesMetaDataFilterViewModel filter)
        {
            var result = await _filesMetaDataService.GetFiles(filter);

            return Ok(new { results = result.FilesMetaData, totalRecords = result.TotalRecords, type = filter.FileType });
        }
    }
}
