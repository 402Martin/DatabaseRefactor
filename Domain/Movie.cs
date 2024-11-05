namespace Domain;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Director? Director { get; set; }
    public List<Category> Categories { get; set; } = new List<Category>();
}