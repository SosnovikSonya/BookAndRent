using AutoMapper;
using BookAndRent.Mapping;
using BookAndRent.Models.Implementations;
using BookAndRent.Models.Intefaces;
using StructureMap;

namespace BookAndRent.DependencyResolving
{
    public static class DependencyContainer
    {
        private static Container container;

        public static void RegisterDependencies()
        {
            container = new Container((config) =>
            {
                config.For<IUser>().Use<User>();
                config.For<IApartment>().Use<Apartment>();
                config.For<IFacility>().Use<Facility>();
                config.For<IComment>().Use<Comment>();
                config.For<IContract>().Use<Contract>();
                config.For<IPicture>().Use<Picture>();
                config.For<IAvailableDate>().Use<AvailableDate>();
            });
        }

        public static T Resolve<T>()
        {
            return container.GetInstance<T>();
        }
    }
}
