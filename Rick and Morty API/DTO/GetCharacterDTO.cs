namespace Rick_and_Morty_API.DTO;

public class GetCharacterDTO
{
    public string Name { get; set; }
    public string Status { get; set; }
    public string Species { get; set; }
    public string Type { get; set; }
    public string Gender { get; set; }
    public OriginDTO Origin { get; set; }
}