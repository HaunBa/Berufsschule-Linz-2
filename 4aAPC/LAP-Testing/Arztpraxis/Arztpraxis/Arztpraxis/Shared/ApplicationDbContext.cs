using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arztpraxis.Shared
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Patienten { get; set; }
        public DbSet<Termin> Termine { get; set; }
        public DbSet<Diagnose> Diagnosen { get; set; }
    }
}
