using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAcess.repositories;

public class MovieRepository
{
    private readonly SqlContext _context;

    public MovieRepository(SqlContext context)
    {
        _context = context;
    }

    public Movie Add(Movie movie)
    {
        var movieDb =_context.Add(movie);
        _context.SaveChanges();
        return movieDb.Entity;
    }
    public List<Movie> GetAll()
    {
        return _context.Movies.ToList();
    }
    public Movie? getByTitle(string title)
    {
        return _context.Movies.FirstOrDefault(m => m.Title == title);
    }
}