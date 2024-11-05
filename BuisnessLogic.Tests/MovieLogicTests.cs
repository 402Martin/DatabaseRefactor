using BusinessLogic;
using Domain;
using Dtos;

namespace BuisnessLogic.Tests;

[TestClass]
public class MovieLogicTests
{
    private MovieLogic _movieLogic;
    private readonly List<Movie> _movieList = new List<Movie>();
    private MovieDto _movieDto;

    [TestInitialize]
    public void Setup()
    {
        _movieLogic = new MovieLogic(_movieList);
         _movieDto = new MovieDto()
        {
            Title = "Inception",
            Director = new DirectorDto() { Name = "Christopher Nolan" },
            Categories = new List<CategoryDto> { new CategoryDto() { Name = "Sci-Fi" } }
        };
    }

    [TestMethod]
    public void AddMovie_ShouldAddMovieToList()
    {

        _movieLogic.AddMovie(_movieDto);
        
        Assert.AreEqual(1, _movieList.Count);
        Assert.AreEqual(_movieDto.Title, _movieList[0].Title);
    }

    [TestMethod]
    public void GetAllMovies_ShouldReturnAllMovies()
    {
        var secondMovie = new Movie
        {
            Title = "The Matrix",
            Director = new Director { Name = "Wachowski Sisters" },
            Categories = new List<Category> { new Category { Name = "Action" } }
        };

        _movieList.Add(_movieDto.ToEntity());
        _movieList.Add(secondMovie);

        var allMovies = _movieLogic.GetAllMovies();

        Assert.AreEqual(2, allMovies.Count);
        Assert.IsTrue(allMovies.Any(m => m.Title == _movieDto.Title));
        Assert.IsTrue(allMovies.Any(m => m.Title == secondMovie.Title));
    }

}