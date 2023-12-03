using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raythos_Aerospace.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Raythos_Aerospace.Data
{
    public class Raythos_AerospaceContext : IdentityDbContext
    {
        public Raythos_AerospaceContext (DbContextOptions<Raythos_AerospaceContext> options)
            : base(options)
        {
        }

        public DbSet<Raythos_Aerospace.Models.UserRole> UserRole { get; set; } = default!;
    }
}
