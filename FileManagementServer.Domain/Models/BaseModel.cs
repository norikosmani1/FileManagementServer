using System;
using System.Collections.Generic;
using System.Text;

namespace FileManagementServer.Domain.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
    }
}
