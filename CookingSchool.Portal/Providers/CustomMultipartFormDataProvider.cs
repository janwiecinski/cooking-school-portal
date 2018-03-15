using CookingSchool.Portal.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace CookingSchool.Portal.Providers
{
    public class CustomMultipartFormDataStreamProvider: MultipartFormDataStreamProvider
    {
        private IFileNameHelper _fileNameHelper { get; set; }
        
        public CustomMultipartFormDataStreamProvider(IFileNameHelper fileNameHelper, string path) : base(path)
        {
            _fileNameHelper = fileNameHelper;
        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            return _fileNameHelper.GetCleanFileName(headers.ContentDisposition.FileName);
        }
    }
}