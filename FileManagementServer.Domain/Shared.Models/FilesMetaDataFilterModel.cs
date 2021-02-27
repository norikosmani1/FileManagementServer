using System;
using System.Collections.Generic;
using System.Text;

namespace FileManagementServer.Domain.Shared.Models
{
    public class FilesMetaDataFilterModel
    {
        public int First { get; set; }

        public int Rows { get; set; }

        public int SortOrder { get; set; }

        public string SortField { get; set; }

        public string FileType { get; set; }
    }
}
