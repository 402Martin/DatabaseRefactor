using Domain;

namespace Dtos;

public class DirectorDto
{
    public string Name { get; set; } = string.Empty;
    public DirectorDto(){}
    public DirectorDto(Director director)
    {
        Name = director.Name;
    }

    public Director ToEntity()
    {
        var director = new Director()
        {
            Name = Name
        };
        return director;
    }
}