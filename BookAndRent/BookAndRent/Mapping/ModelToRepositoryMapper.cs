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
                .ConstructUsing(dbEntity => DependencyContainer.Resolve<IUser>());

            CreateMap<IPicture, Picture>();

            CreateMap<Picture, IPicture>()
                .ConstructUsing(dbEntity => DependencyContainer.Resolve<IPicture>());

            CreateMap<IAvailableDate, AvailableDate>();

            CreateMap<AvailableDate, IAvailableDate>()
                .ConstructUsing(dbEntity => DependencyContainer.Resolve<IAvailableDate>());

            CreateMap<IComment, Comment>()
                .ForMember(comment => comment.UserId, mapper => mapper.MapFrom(src => src.CommentatorId));

            CreateMap<Comment, IComment>()
                .ConstructUsing(dbEntity => DependencyContainer.Resolve<IComment>())
                .ForMember(comment => comment.CommentatorId, mapper => mapper.MapFrom(src => src.UserId));            

            CreateMap<IApartment, Apartment>()
                .ForMember(apartment => apartment.User, mapper => mapper.MapFrom(src => src.HouseHolder))
                .ForMember(apartment => apartment.Facilities, mapper => mapper.MapFrom(src => src.Facilities))
                .ForMember(apartment => apartment.AvailableDates, mapper => mapper.MapFrom(src => src.AvailableDates))
                .ForMember(apartment => apartment.Comments, mapper => mapper.MapFrom(src => src.Comments))
                .ForMember(apartment => apartment.Contracts, mapper => mapper.MapFrom(src => src.Contracts))
                .ForMember(apartment => apartment.Pictures, mapper => mapper.MapFrom(src => src.Pictures));

            CreateMap<Apartment, IApartment>()
                .ConstructUsing(dbEntity => DependencyContainer.Resolve<IApartment>())
                .ForMember(iApartment => iApartment.Facilities, mapper => mapper.MapFrom(src => src.Facilities))
                .ForMember(iApartment => iApartment.AvailableDates, mapper => mapper.MapFrom(src => src.AvailableDates))
                .ForMember(iApartment => iApartment.HouseHolder, mapper => mapper.MapFrom(src => src.User))
                .ForMember(iApartment => iApartment.Comments, mapper => mapper.MapFrom(src => src.Comments))
                .ForMember(iApartment => iApartment.Contracts, mapper => mapper.MapFrom(src => src.Contracts))
                .ForMember(iApartment => iApartment.Pictures, mapper => mapper.MapFrom(src => src.Pictures));

            CreateMap<IContract, Contract>()
                .ForMember(contract => contract.ContractStatus, mapper => mapper.MapFrom(src => src.ContractStatus));


            CreateMap<Contract, IContract>()
                .ForMember(icontract => icontract.ContractStatus, mapper => mapper.MapFrom(src => src.ContractStatus))
                .ConstructUsing(dbEntity => DependencyContainer.Resolve<IContract>());
        }
    }
}
