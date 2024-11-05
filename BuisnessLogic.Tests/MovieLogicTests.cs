using BusinessLogic;
using DataAccess;
using DataAccess.Repositories;
using Domain;
using Dtos;

namespace BuisnessLogic.Tests;

[TestClass]
public class MovieLogicTests
{
    private MovieLogic _movieLogic;
    private MovieDto _movieDto;
    private MovieRepository _repository;
    private SqlContext _context;
    private readonly InMemoryContext _contextFactory = new InMemoryContext();    


    [TestInitialize]
    public void Setup()
    {
        _context = _contextFactory.CreateDbContext();
        _repository = new MovieRepository(_context);

        _movieLogic = new MovieLogic(_repository);
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
        
        Assert.AreEqual(1, _context.Movies.Count());
        Assert.AreEqual(_movieDto.Title, _context.Movies.ToList()[0].Title);
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

        _context.Add(_movieDto.ToEntity());
        _context.Add(secondMovie);
        _context.SaveChanges();

        var allMovies = _movieLogic.GetAllMovies();

        Assert.AreEqual(2, allMovies.Count);
        Assert.IsTrue(allMovies.Any(m => m.Title == _movieDto.Title));
        Assert.IsTrue(allMovies.Any(m => m.Title == secondMovie.Title));
    }

}