using AutoMapper;
using Mealthy.Security.Domain.Models;
using Mealthy.Security.Domain.Services.Communication;

namespace Mealthy.Security.Mapping;

public class ResourceModelToProfile : Profile
{
    public ResourceModelToProfile()
    {
        CreateMap<RegisterRequest, User>();
        CreateMap<UpdateRequest,User>()
            .ForAllMembers(options=>options.Condition(
                (source, target, property) =>
                {
                    if (property == null) return false;
                    if(property.GetType()==typeof(string)&& string.IsNullOrEmpty((string)property))return false;
                    return true;
                }));
    }
}