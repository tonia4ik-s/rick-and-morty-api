namespace Rick_and_Morty_API.DTO;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    public string Species { get; set; }
    public string Type { get; set; }
    public string Gender { get; set; }
    public Location Origin { get; set; }
    public List<string> Episode { get; set; }
    public string Url { get; set; }
}
