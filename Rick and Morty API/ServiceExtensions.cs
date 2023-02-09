using AutoMapper;
using Rick_and_Morty_API.Profiles;

namespace Rick_and_Morty_API;

public static class ServiceExtensions
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        var configures = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new RickAndMortyProfile());
        });

        var mapper = configures.CreateMapper();
        services.AddSingleton(mapper);
    }
}
