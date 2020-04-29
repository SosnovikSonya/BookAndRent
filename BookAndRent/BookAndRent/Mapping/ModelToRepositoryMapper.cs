using AutoMapper;
using BookAndRent.DependencyResolving;
using BookAndRent.Models.Intefaces;
using BookAndRent.Repository.SqlRepository;

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

            CreateMap<IPicture, Picture>();

            CreateMap<Picture, IPicture>()
                .ConstructUsing(dbEntity => DependencyContainer.Resolve<IPicture>());

            CreateMap<IAvailableDate, AvailableDate>();

            CreateMap<AvailableDate, IAvailableDate>()
                .ConstructUsing(dbEntity => DependencyContainer.Resolve<IAvailableDate>());

            CreateMap<IApartment, Apartment>()
                .ForMember(apartment => apartment.User, mapper => mapper.MapFrom(src => src.HouseHolder))
                .ForMember(apartment => apartment.Facilities, mapper => mapper.MapFrom(src => src.Facilities))
                .ForMember(apartment => apartment.AvailableDates, mapper => mapper.MapFrom(src => src.AvailableDates));

            CreateMap<Apartment, IApartment>()
                .ConstructUsing(dbEntity => DependencyContainer.Resolve<IApartment>())
                .ForMember(iApartment => iApartment.Facilities, mapper => mapper.MapFrom(src => src.Facilities))
                .ForMember(iApartment => iApartment.AvailableDates, mapper => mapper.MapFrom(src => src.AvailableDates))
                .ForMember(iApartment => iApartment.HouseHolder, mapper => mapper.MapFrom(src => src.User));

            CreateMap<IContract, Contract>();

            CreateMap<Contract, IContract>()
                .ConstructUsing(dbEntity => DependencyContainer.Resolve<IContract>());

            //TODO: add more mapping for other entities
        }
    }
}
