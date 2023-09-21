using Amazon.Extensions.CognitoAuthentication;
using AutoMapper;
using User.API.AWS.Cognito.Service.AutoMapper.CustomResolvers;
using Core = User.API.Core.Models;

namespace User.API.AWS.Cognito.Service.AutoMapper;

internal class AwsCognitoServiceProfile : Profile
{
    public AwsCognitoServiceProfile()
    {
        CreateMap<CognitoUser, Core::User>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserID))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(new UserFirstNameResolver()))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(new UserLastNameResolver()))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(new UserEmailResolver()))
            .ForMember(dest => dest.ContactNumber, opt => opt.MapFrom(new UserContactNumberResolver()));
    }
}