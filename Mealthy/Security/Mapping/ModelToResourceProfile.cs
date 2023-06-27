using AutoMapper;
using Mealthy.Security.Domain.Models;
using Mealthy.Security.Domain.Services.Communication;
using Mealthy.Security.Resources;

namespace Mealthy.Security.Mapping;

public class ModelToResourceProfile : Profile
{

    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
        
    }

}
