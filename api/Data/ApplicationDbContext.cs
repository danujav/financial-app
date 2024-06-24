using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions options)
    : base(options)
    {

    }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Comment> Comments { get; set; }
}
