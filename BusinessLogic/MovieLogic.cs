using Domain;
using Dtos;

namespace BusinessLogic;

using System.Collections.Generic;
using System.Linq;
using DataAcess.repositories;

public class MovieLogic
{
    private MovieRepository _movies;

    public MovieLogic(MovieRepository movies)
    {
        _movies =  movies;
    }

    public void AddMovie(MovieDto movieDto)
    {
        var movie = movieDto.ToEntity();
        _movies.Add(movie);
    }

    public List<MovieDto> GetAllMovies()
    {
        return _movies.GetAll().Select((x)=> new MovieDto(x)).ToList();
    }

    private Movie? GetMovieByTitle(string title)
    {
        return _movies.getByTitle(title);
    }

}