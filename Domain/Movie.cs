namespace Domain;

public class Movie
{
    public string Title { get; set; } = string.Empty;
    public Director? Director { get; set; }
    public List<Category> Categories { get; set; } = new List<Category>();
}