using Domain;

namespace DataAccess.Tests;

[TestClass]
public class MovieRepositoryTests
{
    private SqlContext _context;
    private MovieRepository _repository;

    [TestInitialize]
    public void SetUp()
    {
       _context= InMemoryContext.CreateDbContext();
        _repository = new MovieRepository(_context);
    }
    
    [TestMethod]
    public void AddMovie_Successfully()
    {
        var movie =  new Movie(){
            Title = "The Matrix",
            Director = new Director { Name = "Wachowski Sisters" },
            Categories = new List<Category> { new Category { Name = "Action" } }
        };
        var movieInDb = _repository.Add(movie);

        Assert.AreEqual(movie.Title, movieInDb.Title);
    }
}