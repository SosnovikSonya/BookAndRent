using AutoMapper;
using BookAndRent.DependencyResolving;
using BookAndRent.Models.Intefaces;
using BookAndRent.Repository.SqlRepository;
using System.Linq;

namespace BookAndRent.Mapping
{
    public class ModelToRepositoryMapper : Profile
    {
        public ModelToRepositoryMapper()
        {
            CreateMap<IUser, User>()
                .ForMember(user => user.Id, mapper => mapper.MapFrom(src => src.Id));

            CreateMap<User, IUser>()
                .ConstructUsing(dbEntity => DependencyContainer.Resolve<IUser>())
                .ForMember(iUser => iUser.Id, mapper => mapper.MapFrom(src => src.Id));

            //CreateMap<IFacility, Facility>()
            //   .ForMember(facility => facility.FacilityId, mapper => mapper.MapFrom(src => src.Id));

            //CreateMap<Facility, IFacility>()
            //    .ConstructUsing(dbEntity => DependencyContainer.Resolve<IFacility>())
            //    .ForMember(iFacility => iFacility.Id, mapper => mapper.MapFrom(src => src.FacilityId));

            CreateMap<IApartment, Apartment>()
               .ForMember(apartment => apartment.UserId, mapper => mapper.MapFrom(src => src.HouseHolder.Id))
               .ForMember(apartment => apartment.Facilities, mapper => mapper.MapFrom(src => src.Facilities));

               //.ForMember(
               // apartment => apartment.ApartmentFacilities,
               // mapper => mapper.MapFrom(src => src.Facilities.Select(ifuc => new ApartmentFacility
               //     { ApartmentId = src.Id, FacilityId = ifuc.Id})));

            CreateMap<Apartment, IApartment>()
                .ConstructUsing(dbEntity => DependencyContainer.Resolve<IApartment>())
                .ForMember(iApartment => iApartment.Id, mapper => mapper.MapFrom(src => src.Id))
                .ForMember(iApartment => iApartment.Facilities, mapper => mapper.MapFrom(src => src.Facilities));


            CreateMap<IPicture, Picture>();

            CreateMap<Picture, IPicture>()
                .ConstructUsing(dbEntity => DependencyContainer.Resolve<IPicture>());

            CreateMap<IAvailableDate, AvailableDate>();

            CreateMap<AvailableDate, IAvailableDate>()
                .ConstructUsing(dbEntity => DependencyContainer.Resolve<IAvailableDate>());

            //TODO: add more mapping for other entities
        }
    }
}
