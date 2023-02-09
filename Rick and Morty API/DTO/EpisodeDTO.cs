namespace Rick_and_Morty_API.DTO;

public class EpisodeDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public List<string> Characters { get; set; }
}
