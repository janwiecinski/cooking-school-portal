using System.Reflection;
using AutoMapper;

namespace CookingSchool.WebApi
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