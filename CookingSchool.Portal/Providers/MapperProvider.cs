using AutoMapper;
using AutoMapper.Configuration;
using CookingSchool.Portal.Utils;
using System.Linq;

namespace CookingSchool.Portal.Providers
{
    public class MapperProvider
    {
        public IMapper GetMapper()
        {
            var mapperConfigExpression = new MapperConfigurationExpression();

            var profiles = typeof(MappingProfile).Assembly.GetTypes().Where(
                
                t => typeof(Profile).IsAssignableFrom(t)).ToList();

            mapperConfigExpression.AddProfiles(profiles);

            var mc = new MapperConfiguration(mapperConfigExpression);

            mc.AssertConfigurationIsValid();

            IMapper mapper = new Mapper(mc);

            return mapper;
        }


    }
}