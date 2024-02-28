using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SuperheroesApp.Models;

namespace SuperheroesApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //represents ou database inside of c#
        public DbSet<Superhero> Superheroes { get; set; } //collection of superhero instances

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
