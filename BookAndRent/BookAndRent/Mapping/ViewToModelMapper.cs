using AutoMapper;
using BookAndRent.DependencyResolving;
using BookAndRent.Models.Intefaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace BookAndRent.Mapping
{
    public class ViewToModelMapper : Profile
    {
        public ViewToModelMapper()
        {
            CreateMap<Views.ViewModels.UserModels.UserRegistration, IUser>()
                .ConstructUsing(viewEntity => DependencyContainer.Resolve<IUser>());

            CreateMap<IUser, Views.ViewModels.UserModels.UserRegistration>();

            CreateMap<Views.ViewModels.UserModels.AccountInfo, IUser>()
               .ConstructUsing(viewEntity => DependencyContainer.Resolve<IUser>());

            CreateMap<IUser, Views.ViewModels.UserModels.AccountInfo>();


            CreateMap<Views.ViewModels.ApartmentModels.CreateApartment, IApartment>()
                .ConstructUsing(viewEntity => DependencyContainer.Resolve<IApartment>());

            CreateMap<IApartment, Views.ViewModels.ApartmentModels.CreateApartment>();

            CreateMap<IPicture, Views.ViewModels.ApartmentModels.ApartmentPicture>();

            CreateMap<Views.ViewModels.ApartmentModels.ApartmentPicture, IPicture>()
                .ConstructUsing(viewEntity => DependencyContainer.Resolve<IPicture>());

            CreateMap<IAvailableDate, Views.ViewModels.ApartmentModels.AvailableDates>();

            CreateMap<Views.ViewModels.ApartmentModels.AvailableDates, IAvailableDate>()
                .ConstructUsing(viewEntity => DependencyContainer.Resolve<IAvailableDate>());

            CreateMap<IComment, Views.ViewModels.ApartmentModels.Comment>();

            CreateMap<Views.ViewModels.ApartmentModels.Comment, IComment>()
                .ConstructUsing(viewEntity => DependencyContainer.Resolve<IComment>());

            CreateMap<Facility, Views.ViewModels.ApartmentModels.Facility>()
                .ForMember(facility => facility.Title, mapper => mapper.MapFrom(src => src.ToString()));

            CreateMap<Views.ViewModels.ApartmentModels.Facility, Facility>()
                .ConstructUsing(viewEntity => DependencyContainer.Resolve<Facility>());

            CreateMap<IApartment, Views.ViewModels.ApartmentModels.AvailableApartmentInfo>()               
                .ForMember(apartment => apartment.Comments, mapper => mapper.MapFrom(src => src.Comments))
                .ForMember(apartment => apartment.Pictures, mapper => mapper.MapFrom(src => src.Pictures))
                .ForMember(apartment => apartment.Facilities, mapper => mapper.MapFrom(src =>
                    Enum.GetValues(typeof(Facility))
                      .Cast<Facility>()
                      .Where(option => (src.Facilities & option) == option && option != Facility.None)
                      .Select(option => new Views.ViewModels.ApartmentModels.Facility { Title = option.ToString() })));

            CreateMap<IContract, Views.ViewModels.UserModels.Contract>();

            CreateMap<Views.ViewModels.UserModels.Contract, IContract>()
                .ConstructUsing(viewEntity => DependencyContainer.Resolve<IContract>());
        }
    }
}
