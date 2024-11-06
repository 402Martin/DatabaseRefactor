﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class SqlContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Category> Categories { get; set; }

    public SqlContext(DbContextOptions<SqlContext> options) : base(options)
    {
        if (!Database.IsInMemory())
        {
            Database.Migrate();
        }
    }
}