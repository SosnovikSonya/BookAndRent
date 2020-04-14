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

            //TODO: add more mapping for other entities
        }
    }
}
