using AutoMapper;
using CookingSchool.DAL.Models;
using CookingSchool.DAL.Repositories;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace CookingSchool.WebApi.Controllers
{
    [RoutePrefix("images")]
    public class ImageController : ApiController 
    {
        private IRepository<Image> _imageRepository;
        private IMapper _mapper;


        public ImageController(IRepository<Image> repository, IMapper mapper)
        {
            _imageRepository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetImage(int id)
        {
            var image = _imageRepository.GetById(id);

            if (image == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            System.Drawing.Image img = System.Drawing.Image.FromFile(image.FullPath);

            return GetResponseMessage(img);
        }

        [HttpGet]
        [Route("{id}/thumbnail")]
        public HttpResponseMessage GetImageThumbnail(int id, int width, int height)
        {
            var image = _imageRepository.GetById(id);

            if (image == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            System.Drawing.Image img = System.Drawing.Image.FromFile(image.FullPath);

            var thumbnail = img.GetThumbnailImage(width, height, null, new System.IntPtr());

            return GetResponseMessage(thumbnail);
        }

        public HttpResponseMessage GetResponseMessage(System.Drawing.Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new ByteArrayContent(ms.ToArray());
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                return result;
            }
        }
    }
}
