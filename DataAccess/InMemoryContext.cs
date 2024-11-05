using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class InMemoryContext
{
    public SqlContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();
        optionsBuilder.UseInMemoryDatabase("TestDB");
        return new SqlContext(optionsBuilder.Options);
    }
    
}