using CSO_LF089.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSO_LF089.Data
{
    public class CsoDbContext : IdentityDbContext
    {
        public CsoDbContext(DbContextOptions<CsoDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:taskorganizer.database.windows.net;Initial Catalog=TaskOrganizerDb;Persist Security Info=False;User ID=LF089;Password=Berco089;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public DbSet<CourseOrganizer> CursesOrganizer { get; set; }
        public DbSet<Book> books { get; set; }
    }
}
