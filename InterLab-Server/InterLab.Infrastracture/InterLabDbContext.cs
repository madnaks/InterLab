using InterLab.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace InterLab.Infrastracture
{
    public class InterLabDbContext : DbContext
    {
        public InterLabDbContext(DbContextOptions<InterLabDbContext> options) : base(options) { }

        public DbSet<BookMarkStock> BookMarkStocks { get; set; }
    }
}
