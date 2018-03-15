using CookingSchool.DAL.Repositories;
using CookingSchool.DAL.Models;
using CookingSchool.Portal.Utils;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using CookingSchool.Portal.Models;
using System.Net.Http;
using System.IO;
using System.Net;
using System.Net.Http.Headers;

namespace CookingSchool.Portal.Controllers
{
    [RoutePrefix("images")]
    public class ImagesController : ApiController
    {
        IRepository<Image> _imagesRepository;
        IImageManager _imageManager;

        public ImagesController(IRepository<Image> imageRepository, IImageManager imageManager)
        {
            _imagesRepository = imageRepository;
            _imageManager = imageManager;
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> UploadImage()
        {
            var image = (await _imageManager.UploadImages(Request)).FirstOrDefault();
             
            return Ok(
                new UploadImageResponse()
                {
                    Id = image.Id
                }
            );
        }
        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage GetImage(int id)
        {
            var image = _imagesRepository.GetById(id);

            if (image == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            System.Drawing.Image img = System.Drawing.Image.FromFile(image.FullPath);

            return GetResponseMessage(img);
        }

       
        [Route("{id}/thumbnail")]
        public HttpResponseMessage GetImageThumbnail(int id, int width, int height)
        {
            var image = _imagesRepository.GetById(id);

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
