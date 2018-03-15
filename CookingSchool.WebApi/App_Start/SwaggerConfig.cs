using System.Web.Http;
using WebActivatorEx;
using CookingSchool.WebApi;
using Swashbuckle.Application;


namespace CookingSchool.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
           // GlobalConfiguration.Configuration
           //.EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
           //.EnableSwaggerUi();
        }
    }
}