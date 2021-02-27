using System;
using System.Collections.Generic;
using System.Text;

namespace FileManagementServer.Domain.Models
{
    public class Settings : BaseModel
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
