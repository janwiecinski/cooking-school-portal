using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CookingSchool.DAL.Models;

namespace CookingSchool.Portal.Utils
{
    public interface IImageManager
    {
        Task<IEnumerable<Image>> UploadImages(HttpRequestMessage request);
    }
}
