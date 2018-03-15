using System.Web.Http;

namespace CookingSchool.WebApi.Controllers
{
    [RoutePrefix("ping")]
    public class PingController : ApiController
    {
       
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok("pong2");
        }
    }
}
