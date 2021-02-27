using FileManagementServer.Tests.Mocking;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace FileManagementServer.Tests
{
    public class FilesMetaDataTests
    {
        
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsAcceptable_FileType_ReturnsIsTrue()
        {
            FilesMetaDataMock filesMetaDataMock = new FilesMetaDataMock();
            string path = filesMetaDataMock.GetFilePath();
            List<string> acceptableFileTypes = filesMetaDataMock.GetAcceptableFileTypes();
            string pathType = path.Substring(path.LastIndexOf('.') + 1);

            bool exists = false;
            if (acceptableFileTypes.Contains(pathType))
            {
                exists = true;
            }

            Assert.IsTrue(exists);
        }

        [Test]
        public void Exceeded_MaxFileSize_ReturnsIsTrue()
        {
            FilesMetaDataMock filesMetaDataMock = new FilesMetaDataMock();
            string path = filesMetaDataMock.GetFilePath();

            bool notExceedsMaxFileSize = false;

            long length = new FileInfo(path).Length;

            if(length <= filesMetaDataMock.MaxFileSize)
            {
                notExceedsMaxFileSize = true;
            }

            Assert.IsTrue(notExceedsMaxFileSize);
        }
    }
}