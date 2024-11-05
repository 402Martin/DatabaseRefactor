using Domain;

namespace DataAccess.Repositories;

public class MovieRepository
{
    private SqlContext _context;

    public MovieRepository(SqlContext context)
    {
        this._context = context;
    }

    public Movie Add(Movie movie)
    {
        var movieToReturn = _context.Add(movie);
        _context.SaveChanges();
        return movieToReturn.Entity;
    }

    public List<Movie> getAll()
    {
        return _context.Movies.ToList();
    }
}