using AutoMapper;
using AutoMapper.Configuration;
using SimpleInjector;
using System.Linq;

namespace CookingSchool.WebApi
{
    public class MapperProvider
    {
        public IMapper GetMapper()
        {
            var mapperConfigExpression = new MapperConfigurationExpression();
            var profiles = typeof(MyProfile).Assembly.GetTypes()
                            .Where(t => typeof(Profile).IsAssignableFrom(t)).ToList();

            mapperConfigExpression.AddProfiles(profiles);

            var mc = new MapperConfiguration(mapperConfigExpression);

            mc.AssertConfigurationIsValid();

            return new Mapper(mc);
        }
    }
}