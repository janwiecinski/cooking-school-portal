using AutoMapper;
using AutoMapper.Configuration;
using SimpleInjector;
using System.Linq;

namespace CookingSchool.WebApi
{

    public class MyRegistrar
    {
        public void Register(Container container)
        { 
            //container.Register<IRepository<Ingredient>, GenericRepository<Ingredient>>();

            //container.RegisterSingleton<IRepository<Recipe>, GenericRepository<Recipe>>();

            //container.RegisterSingleton<IRepository<Author>, GenericRepository<Author>>();

            //container.Register<IRepository<Image>, GenericRepository<Image>>();

            container.RegisterSingleton(() => GetMapper(container));
        }

        private IMapper GetMapper(Container container)
        {
            var mp = container.GetInstance<Imapper>();
            return mp.GetMapper();
        }
    }


    public class Imapper
    {
        private readonly Container _container;
        public Imapper(Container container)
        {
            _container = container;
        }
       
        public IMapper GetMapper()
        {
            var mapperConfigExpression = new MapperConfigurationExpression();

            mapperConfigExpression.ConstructServicesUsing(_container.GetInstance);

            var profiles = typeof(MyProfile).Assembly.GetTypes()
                            .Where(t => typeof(Profile).IsAssignableFrom(t)).ToList();

            mapperConfigExpression.AddProfiles(profiles);

            var mc = new MapperConfiguration(mapperConfigExpression);

            mc.AssertConfigurationIsValid();

            IMapper mapper = new Mapper(mc, t => _container.GetInstance(t));

            return mapper;
        }

       
    }
}