using System;
using System.Collections.Generic;
using System.Text;

namespace FileManagementServer.Domain.Models
{
    public class FilesMetaData : BaseModel
    {
        public string Url { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public decimal Size { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }
}
