using Microsoft.EntityFrameworkCore;

namespace DataAcess;

public class InMemoryContext
{
    public SqlContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();
        optionsBuilder.UseInMemoryDatabase("TestDB");
        return new SqlContext(optionsBuilder.Options);
    }
    
}