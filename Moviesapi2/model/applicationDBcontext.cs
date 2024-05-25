using Microsoft.EntityFrameworkCore;

namespace Moviesapi2.model
{
    public class applicationDBcontext:DbContext
    {
        public applicationDBcontext(DbContextOptions<applicationDBcontext> options):base(options)
        {
        }
        public DbSet<gener> gener { get; set; }    
        public DbSet<movie> movies { get; set; }
    }
}
