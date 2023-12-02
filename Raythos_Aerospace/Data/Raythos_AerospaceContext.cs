using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Raythos_Aerospace.Models;

namespace Raythos_Aerospace.Data
{
    public class Raythos_AerospaceContext : DbContext
    {
        public Raythos_AerospaceContext (DbContextOptions<Raythos_AerospaceContext> options)
            : base(options)
        {
        }

        public DbSet<Raythos_Aerospace.Models.Model> Model { get; set; } = default!;

        public DbSet<Raythos_Aerospace.Models.Aircraft>? Aircraft { get; set; }

        //public DbSet<Raythos_Aerospace.Models.Orders>? Orders { get; set; }
        public DbSet<Orders> Orders { get; set; }

        public DbSet<Raythos_Aerospace.Models.Users>? Users { get; set; }

        public DbSet<Raythos_Aerospace.Models.Brand>? Brand { get; set; }

        public DbSet<Raythos_Aerospace.Models.Manufacturing>? Manufacturing { get; set; }


    }
}
