using System;
using System.Collections.Generic;
using System.Text;

namespace FileManagementServer.Application.ViewModels
{
    public class FilesMetaDataViewModel : BaseViewModel
    {
        public string Url { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public decimal Size { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
