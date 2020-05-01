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

            CreateMap<IPicture, Views.ViewModels.ApartmentPicture>();

            CreateMap<Views.ViewModels.ApartmentPicture, IPicture>()
                .ConstructUsing(viewEntity => DependencyContainer.Resolve<IPicture>());

            CreateMap<IAvailableDate, Views.ViewModels.AvailableDates>();

            CreateMap<Views.ViewModels.AvailableDates, IAvailableDate>()
                .ConstructUsing(viewEntity => DependencyContainer.Resolve<IAvailableDate>());

            CreateMap<IComment, Views.ViewModels.Comment>();
            CreateMap<Views.ViewModels.Comment, IComment>()
                .ConstructUsing(viewEntity => DependencyContainer.Resolve<IComment>());

            CreateMap<IApartment, Views.ViewModels.AvailableApartmentInfo>()
                .ForMember(apartment => apartment.Facilities, mapper => mapper.MapFrom(src => src.Facilities))
                .ForMember(apartment => apartment.Comments, mapper => mapper.MapFrom(src => src.Comments))
                .ForMember(apartment => apartment.Pictures, mapper => mapper.MapFrom(src => src.Pictures));

            //TODO: add more mapping for other entities

        }
    }
}
