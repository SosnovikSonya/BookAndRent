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
                .ConstructUsing(viewEntity => DependencyContainer.Resolve<IUser>());

            CreateMap<IUser, Views.ViewModels.UserRegistration>();

            CreateMap<Views.ViewModels.CreateApartment, IApartment>()
                .ConstructUsing(viewEntity => DependencyContainer.Resolve<IApartment>());

            CreateMap<IApartment, Views.ViewModels.CreateApartment>();


            //CreateMap<IFacility, Views.ViewModels.Facility>();

            //CreateMap<Views.ViewModels.Facility, IFacility>()
            //    .ConstructUsing(viewEntity => DependencyContainer.Resolve<IFacility>());

            CreateMap<IPicture, Views.ViewModels.ApartmentPicture>();

            CreateMap<Views.ViewModels.ApartmentPicture, IPicture>()
                .ConstructUsing(viewEntity => DependencyContainer.Resolve<IPicture>());

            CreateMap<IAvailableDate, Views.ViewModels.AvailableDates>();

            CreateMap<Views.ViewModels.AvailableDates, IAvailableDate>()
                .ConstructUsing(viewEntity => DependencyContainer.Resolve<IAvailableDate>());

            //TODO: add more mapping for other entities

        }
    }
}
