using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileManagementServer.Tests.Mocking
{
    public class FilesMetaDataMock
    {
        public string GetFilePath()
        {
            string path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"Mocking\Files\programmingmovie.jpg");
            return path;
        }

        public List<string> GetAcceptableFileTypes()
        {
            return new List<string>()
            {
               "png","jpg","pptx","docx","xlsx"
            };
        }

        public int MaxFileSize { get; set; } = 10485760;
    }
}