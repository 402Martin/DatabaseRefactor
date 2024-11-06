using BusinessLogic;
using Domain;
using Dtos;

namespace BuisnessLogic.Tests;

[TestClass]
public class MovieLogicTests
{
    private MovieLogic _movieLogic;
    private List<Movie> _movies;
    private MovieDto _movieDto;

    [TestInitialize]
    public void Setup()
    {
         _movies = new List<Movie>();
        _movieLogic = new MovieLogic(_movies);
        _movieDto = new MovieDto()
        {
            Title = "Inception",
            Director = new DirectorDto() { Name = "Christopher Nolan" },
            Categories = new List<CategoryDto> { new CategoryDto { Name = "Sci-Fi" } }
        };
    }

    [TestMethod]
    public void AddMovie_ShouldAddMovieToList()
    {

        _movieLogic.AddMovie(_movieDto);

        Assert.AreEqual(1, _movies.Count);
        Assert.AreEqual("Inception", _movies[0].Title);
    }

    [TestMethod]
    public void GetAllMovies_ShouldReturnAllMovies()
    {
        var secondMovie = new Movie(){
            Title = "The Matrix",
            Director = new Director { Name = "Wachowski Sisters" },
            Categories = new List<Category> { new Category { Name = "Action" } }
        };

        _movies.Add(_movieDto.ToEntity());
        _movies.Add(secondMovie);

        var allMovies = _movieLogic.GetAllMovies();

        Assert.AreEqual(2, allMovies.Count);
        Assert.IsTrue(allMovies.Any(m => m.Title == "Inception"));
        Assert.IsTrue(allMovies.Any(m => m.Title == "The Matrix"));
    }
}