using Domain;

namespace Dtos;

public class CategoryDto
{
    public string Name { get; set; } = String.Empty;

    public CategoryDto(Category cat)
    {
        Name = cat.Name;
    }
    
    public Category ToEntity()
    {
        var category = new Category()
        {
            Name = Name
        };
        return category;
    }
}