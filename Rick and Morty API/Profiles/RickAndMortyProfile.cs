using AutoMapper;
using Rick_and_Morty_API.DTO;

namespace Rick_and_Morty_API.Profiles;

public class RickAndMortyProfile : Profile
{
    public RickAndMortyProfile()
    {
        CreateMap<Character, GetCharacterDTO>();
        CreateMap<Location, OriginDTO>();
    }
}