using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppAdminPageCultuurplein1DB.Data.WebAppAdminPageCultuurplein1;

namespace WebAppAdminPageCultuurplein1.Data
{
    // Wordt gebruikt bij de context van de database.
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
            public DbSet<Shows> Saveimg
            {
                get; set;
            }
        }
}