using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using WebAppAdminPageCultuurplein1DB.Data.WebAppAdminPageCultuurplein1;

namespace WebAppAdminPageCultuurplein1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Shows> Saveimg { get; set; }

    }
}
