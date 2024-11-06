using Domain;
using Dtos;

namespace BusinessLogic;

using System.Collections.Generic;
using System.Linq;

public class MovieLogic
{
    private List<Movie> _movies;

    public MovieLogic(List<Movie> movies)
    {
        _movies = movies;
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


}