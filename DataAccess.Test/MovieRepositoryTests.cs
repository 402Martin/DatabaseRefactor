using DataAccess.Repositories;
using Domain;

namespace DataAccess.Test;

[TestClass]
public class MovieRepositoryTests
{
    private MovieRepository _repository;
    private SqlContext _context;
    private readonly InMemoryContext _contextFactory = new InMemoryContext();    
    
    [TestInitialize]
    public void Setup()
    {
        _context = _contextFactory.CreateDbContext();
        _repository = new MovieRepository(_context);
    }

    [TestMethod]
    public void SuccessfullyAdd_Test()
    {
        var movie = new Movie
        {
            Id = 1,
            Title = "The Matrix",
            Director = new Director { Name = "Wachowski Sisters" },
            Categories = new List<Category> { new Category { Name = "Action" } }
        };

        var movieInDb = _repository.Add(movie);
        Assert.AreEqual(movie.Title, movieInDb.Title);

    }

    [TestMethod]
    public void GetAllSuccesfully()
    {
        var movie = new Movie
        {
            Id = 1,
            Title = "The Matrix",
            Director = new Director { Name = "Wachowski Sisters" },
            Categories = new List<Category> { new Category { Name = "Action" } }
        };
        _context.Add(movie);

        var movies = _repository.getAll();
        Assert.AreEqual(movie.Title, movies[0].Title);
        
        
    }
}