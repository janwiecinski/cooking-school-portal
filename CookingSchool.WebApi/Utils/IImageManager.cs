using CookingSchool.DAL.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CookingSchool.WebApi.Utils
{
    public interface IImageManager
    {
          Task<IEnumerable<Image>> UploadImages(HttpRequestMessage request);
    }
}
