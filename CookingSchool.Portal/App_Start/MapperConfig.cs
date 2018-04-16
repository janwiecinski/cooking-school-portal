using AutoMapper;
using System.Reflection;

namespace CookingSchool.Portal.App_Start
{
    public static class MapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(Assembly.GetExecutingAssembly());
            });
        }
    }
}