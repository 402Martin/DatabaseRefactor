using Domain;
using Dtos;

namespace BusinessLogic;

using System.Collections.Generic;
using System.Linq;

public class MovieLogic
{
    private List<Movie> _movies;

    public MovieLogic()
    {
        _movies = new List<Movie>();
    }

    public void AddMovie(MovieDto movieDto)
    {
        var movie = movieDto.ToEntity();
        _movies.Add(movie);
    }

    public List<MovieDto> GetAllMovies()
    {
        return _movies.Select(movie=> new MovieDto(movie)).ToList();
    }

    private Movie? GetMovieByTitle(string title)
    {
        return _movies.FirstOrDefault(m => m.Title == title);
    }

}