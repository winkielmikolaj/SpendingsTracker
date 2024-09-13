using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace SpendingsTracker.Models
{
    public class SpendingsTrackedDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public SpendingsTrackedDbContext(DbContextOptions<SpendingsTrackedDbContext> options)
            : base(options)
        {
            
        }
    }
}
