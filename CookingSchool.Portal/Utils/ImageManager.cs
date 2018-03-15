using CookingSchool.DAL.Repositories;
using CookingSchool.DAL.Models;
using System.Threading.Tasks;
using System.Collections;
using System.Net.Http;
using System.IO;
using System.Web;
using System;
using System.Collections.Generic;
using CookingSchool.Portal.Providers;
using System.Web.Http;
using System.Net;

namespace CookingSchool.Portal.Utils
{
    public class ImageManager :IImageManager
    {
        private IRepository<Image> _imageRepository;

        private IFileNameHelper _fileNameHelper;

        public ImageManager(IRepository<Image> imageRepository, IFileNameHelper fileNameHelper)
        {
            _fileNameHelper = fileNameHelper;
            _imageRepository = imageRepository;
        }

        public async Task<IEnumerable<Image>> UploadImages(HttpRequestMessage request)
        {
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data/images"), Guid.NewGuid().ToString());

            Directory.CreateDirectory(path);

            var images = new List<Image>();

            if(request.Content.IsMimeMultipartContent())
            {
                var streamProvider = new CustomMultipartFormDataStreamProvider(_fileNameHelper, path);
                await request.Content.ReadAsMultipartAsync(streamProvider).ContinueWith
                    (t =>
                    {
                        if (t.IsFaulted || t.IsCanceled)
                        {
                            throw new HttpResponseException(HttpStatusCode.InternalServerError);
                        }

                        foreach (var file in streamProvider.FileData)
                        {
                            var fileInfo = new FileInfo(file.LocalFileName);
                            var newImage = new Image { Name = fileInfo.Name, FullPath = fileInfo.FullName };
                            _imageRepository.Add(newImage);
                            images.Add(newImage);
                        }
                    });
                return images;
            }
            else
            {
                throw new HttpResponseException(request.CreateResponse(HttpStatusCode.NotAcceptable, "This request is not properly formatted"));
            }
        }
    }
}