using AutoMapper;
using Newtonsoft.Json;
using Rick_and_Morty_API.DTO;

namespace Rick_and_Morty_API.Services;

public interface IRickAndMortyService
{
    Task<bool> CheckPerson(string personName, string episodeName);
    Task<IEnumerable<GetCharacterDTO>> GetCharacters(string personName);
}

public class RickAndMortyService : IRickAndMortyService
{
    private readonly HttpClient _client;
    private readonly IMapper _mapper;

    public RickAndMortyService(HttpClient client, IMapper mapper)
    {
        _client = client;
        _mapper = mapper;
    }

    public async Task<bool> CheckPerson(string personName, string episodeName)
    {
        var charactersResponse = await _client.GetAsync($"character/?name={personName}");
        var characters =  charactersResponse.IsSuccessStatusCode ? 
            JsonConvert.DeserializeObject<CheckCharactersDTO>(await charactersResponse.Content.ReadAsStringAsync()) : null;
        
        var episodeResponse = await _client.GetAsync($"episode/?name={episodeName}");
        var episodes = episodeResponse.IsSuccessStatusCode
            ? JsonConvert.DeserializeObject<EpisodesDTO>(await episodeResponse.Content.ReadAsStringAsync())
            : null;

        if (characters == null || episodes == null || !characters.Results.Any(c => c.Name.Equals(personName)))
        {
            throw new Exception("404 not found");
        }

        return characters.Results.Where(c => c.Name.Equals(personName))
            .Any(character => episodes.Results[0].Characters.Contains(character.Url));
    }

    public async Task<IEnumerable<GetCharacterDTO>> GetCharacters(string personName)
    {
        var charactersResponse = await _client.GetAsync($"character/?name={personName}");
        var characters =  charactersResponse.IsSuccessStatusCode ? 
            JsonConvert.DeserializeObject<CheckCharactersDTO>(await charactersResponse.Content.ReadAsStringAsync()) : null;

        if (characters == null || !characters.Results.Any(c => c.Name.Equals(personName)))
        {
            throw new Exception("404 not found");
        }
        
        foreach (var character in characters.Results.Where(r => r.Name.Equals(personName)))
        {
            var originUrl = character.Origin.Url[_client.BaseAddress.AbsoluteUri.Length..];
            var originResponse = await _client.GetAsync(originUrl);
            var origin =  charactersResponse.IsSuccessStatusCode ? 
                JsonConvert.DeserializeObject<Location>(await originResponse.Content.ReadAsStringAsync()) : null;
            character.Origin = origin;
        }
        return characters.Results.Select(c => _mapper.Map<GetCharacterDTO>(c)).ToList();
    }
}
