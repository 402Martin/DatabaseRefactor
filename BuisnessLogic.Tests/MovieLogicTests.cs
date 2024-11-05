using BusinessLogic;
using Domain;
using Dtos;

namespace BuisnessLogic.Tests;

[TestClass]
public class MovieLogicTests
{
    private MovieLogic _movieLogic;

    [TestInitialize]
    public void Setup()
    {
        _movieLogic = new MovieLogic();
    }

    [TestMethod]
    public void AddMovie_ShouldAddMovieToList()
    {
        var movieDto = new MovieDto(new Movie
        {
            Title = "Inception",
            Director = new Director { Name = "Christopher Nolan" },
            Categories = new List<Category> { new Category { Name = "Sci-Fi" } }
        });

        _movieLogic.AddMovie(movieDto);

        var allMovies = _movieLogic.GetAllMovies();
        Assert.AreEqual(1, allMovies.Count);
        Assert.AreEqual("Inception", allMovies[0].Title);
        Assert.AreEqual("Christopher Nolan", allMovies[0].Director?.Name);
        Assert.AreEqual("Sci-Fi", allMovies[0].Categories[0].Name);
    }

    [TestMethod]
    public void GetAllMovies_ShouldReturnAllMovies()
    {
        var movie1 = new MovieDto(new Movie
        {
            Title = "Inception",
            Director = new Director { Name = "Christopher Nolan" },
            Categories = new List<Category> { new Category { Name = "Sci-Fi" } }
        });
        var movie2 = new MovieDto(new Movie
        {
            Title = "The Matrix",
            Director = new Director { Name = "Wachowski Sisters" },
            Categories = new List<Category> { new Category { Name = "Action" } }
        });

        _movieLogic.AddMovie(movie1);
        _movieLogic.AddMovie(movie2);

        var allMovies = _movieLogic.GetAllMovies();

        Assert.AreEqual(2, allMovies.Count);
        Assert.IsTrue(allMovies.Any(m => m.Title == "Inception"));
        Assert.IsTrue(allMovies.Any(m => m.Title == "The Matrix"));
    }

    [TestMethod]
    public void GetMovieByTitle_ShouldReturnCorrectMovie()
    {
        var movieDto = new MovieDto(new Movie
        {
            Title = "Interstellar",
            Director = new Director { Name = "Christopher Nolan" },
            Categories = new List<Category> { new Category { Name = "Sci-Fi" } }
        });
        _movieLogic.AddMovie(movieDto);

        var retrievedMovie = typeof(MovieLogic)
            .GetMethod("GetMovieByTitle",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
            ?.Invoke(_movieLogic, new object[] { "Interstellar" }) as Movie;

        Assert.IsNotNull(retrievedMovie);
        Assert.AreEqual("Interstellar", retrievedMovie?.Title);
        Assert.AreEqual("Christopher Nolan", retrievedMovie?.Director?.Name);
    }
}