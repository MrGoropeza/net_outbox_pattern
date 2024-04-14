using Application.Users.SignUp;
using AutoMapper;
using Newtonsoft.Json;
using Persistence.Models;

namespace Application.Users;

public class UsersMapper : Profile
{
    public UsersMapper()
    {
        CreateMap<SignUpRequest, User>();
        CreateMap<SignUpRequest, OutboxMessage>()
            .ForMember(
                dest => dest.Content,
                opt =>
                    opt.MapFrom(
                        src =>
                            JsonConvert.SerializeObject(
                                src,
                                new JsonSerializerSettings
                                {
                                    TypeNameHandling = TypeNameHandling.All
                                }
                            )
                    )
            )
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => UserEvents.UserSignedUp));
    }
}
