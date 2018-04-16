using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using CookingSchool.DAL.Repositories;
using CookingSchool.DAL.Models;
using System.Reflection;
using CookingSchool.Portal.Utils;
using System.Web;
using System.IO;
using SimpleInjector.Integration.WebApi;
using CookingSchool.Portal.Providers;
using CookingSchool.Portal.App_Start;

namespace CookingSchool.Portal
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

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<IImageManager, ImageManager>();
            container.Register<IFileNameHelper, FileNameHelper>();
            container.Register<IRepository<Recipe>, GenericRepository<Recipe>>(Lifestyle.Scoped);
            container.Register<IRepository<MealType>, GenericRepository<MealType>>(Lifestyle.Scoped);
            container.Register<IRepository<Image>, GenericRepository<Image>>(Lifestyle.Scoped);
            container.Register<IRepository<Author>, GenericRepository<Author>>(Lifestyle.Scoped);
            

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration, Assembly.GetExecutingAssembly());

            var mapperProvider = new MapperProvider();
            container.RegisterSingleton(() => mapperProvider.GetMapper());

            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver =new SimpleInjectorWebApiDependencyResolver(container);

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
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
