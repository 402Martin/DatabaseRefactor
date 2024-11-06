using Domain;

namespace Dtos;

public class MovieDto
{
    public string Title { get; set; } = string.Empty;
    public DirectorDto? Director { get; set; }
    public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

    public MovieDto()
    {
    }

    public MovieDto(Movie movie)
    {
        Title = movie.Title;
        if (movie.Director != null)
            Director = new DirectorDto(movie.Director);
        
        Categories = movie.Categories.Select(cat => new CategoryDto(cat)).ToList();
    }

    public Movie ToEntity()
    {
        var movie = new Movie()
        {
            Title = Title,
            Director = Director?.ToEntity(),
            Categories = Categories.Select(x=> x.ToEntity()).ToList()
        };
        return movie;
    }
}