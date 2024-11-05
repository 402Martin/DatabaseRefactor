using DataAccess.Repositories;
using Domain;
using Dtos;

namespace BusinessLogic;

using System.Collections.Generic;
using System.Linq;

public class MovieLogic
{
    private MovieRepository _movies;
    public MovieLogic(MovieRepository repository)
    {
        _movies = repository;
    }

    public void AddMovie(MovieDto movieDto)
    {
        var movie = movieDto.ToEntity();
        _movies.Add(movie);
    }

    public List<MovieDto> GetAllMovies()
    {
        return _movies.getAll().Select(x=> new MovieDto(x)).ToList();
    }
    
}