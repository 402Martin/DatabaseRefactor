using Domain;

namespace DataAccess;

public class MovieRepository
{
    private SqlContext _context;

    public MovieRepository(SqlContext context)
    {
        _context = context;
    }
    public Movie Add(Movie movie)
    {
        var movieEntity = _context.Add(movie);
        _context.SaveChanges();
        return movieEntity.Entity;
    }
    
    public List<Movie> GetAllMovies() {
        return _context.Movies.ToList();
    }
}