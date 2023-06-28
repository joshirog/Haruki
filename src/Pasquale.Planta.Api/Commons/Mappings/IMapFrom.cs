using AutoMapper;

namespace Pasquale.Planta.Api.Commons.Mappings;

public interface IMapFrom<T>
{
    void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType());
    }
}
