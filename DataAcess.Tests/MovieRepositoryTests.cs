using DataAcess.repositories;
using Domain;

namespace DataAcess.Tests;

[TestClass]
public class MovieRepositoryTests
{
    private MovieRepository _repository;
    private SqlContext _context;
    private readonly InMemoryContext _contextFactory = new InMemoryContext();
    [TestInitialize]
    public void SetUp()
    {
        _context = _contextFactory.CreateDbContext();
        _repository = new MovieRepository(_context);
    }
    
    [TestCleanup]
    public void CleanUp()
    {
        _context.Database.EnsureDeleted();
    } 

    [TestMethod]
    public void CreateMovieSuccessfully()
    {
        var movie = new Movie
        {
            Id = 1, 
            Title = "Black Rain", 
        }; 
        
        _repository.Add(movie);
        var movieInDatabase = _context.Movies.First();
        Assert.AreEqual(movie, movieInDatabase);
    }
}