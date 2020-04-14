using AutoMapper;
using BookAndRent.DependencyResolving;
using BookAndRent.Models.Intefaces;

namespace BookAndRent.Mapping
{
    public class ViewToModelMapper : Profile
    {
        public ViewToModelMapper()
        {
            CreateMap<Views.ViewModels.UserRegistration, IUser>()
                .ConstructUsing(dbEntity => DependencyContainer.Resolve<IUser>());

            //TODO: add more mapping for other entities

        }
    }
}
