using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketReservation.Models;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TicketReservation.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<Seat> Seat { get; set; }

        public DbSet<Journey> Journey { get; set; }

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<Journey> Journey { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<ApplicationUser>();

            builder.Entity<Journey>();

            builder.Entity<Seat>();

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            // email address doesn't need to be in unicode, check it spec
        }
    }
}
