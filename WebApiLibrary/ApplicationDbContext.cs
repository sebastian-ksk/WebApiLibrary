using Microsoft.EntityFrameworkCore;
using WebApiLibrary.Entities;

namespace WebApiLibrary
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Autor> Autors { get; set; }
    }
}
