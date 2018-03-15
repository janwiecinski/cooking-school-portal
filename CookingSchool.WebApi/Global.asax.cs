using CookingSchool.DAL.Models;
using CookingSchool.DAL.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.IO;
using System.Web;
using CookingSchool.WebApi.Utils;

namespace CookingSchool.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DirectorySetup();
            SetupContainer();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MapperConfig.Config();
            
        }

        private void SetupContainer()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IImageManager, ImageManager>();
            container.Register<IFileNameHelper, FileNameHelper>();
            container.Register<IRepository<Ingredient>, GenericRepository<Ingredient>>(Lifestyle.Scoped);
            container.Register<IRepository<Recipe>, GenericRepository<Recipe>>(Lifestyle.Scoped);
            container.Register<IRepository<Author>, GenericRepository<Author>>(Lifestyle.Scoped);
            container.Register<IRepository<Image>, GenericRepository<Image>>(Lifestyle.Scoped);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            var mapperProvider = new Imapper(container);
            container.RegisterSingleton(() => mapperProvider.GetMapper());

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private void DirectorySetup()
        {
            var path = HttpContext.Current.Server.MapPath("~/App_Data/images");

            bool directory = Directory.Exists(path);

            if (!directory)
            {
                Directory.CreateDirectory(path);
            }
        }

    }
}
