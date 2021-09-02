using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entro.Models;
using Microsoft.EntityFrameworkCore;

namespace Entro.Data
{
    public class EntroContext : DbContext
    {
        public EntroContext (DbContextOptions<EntroContext> options)
            : base(options)
        {
        }

        public DbSet<Concepts> Concepts { get; set; }

        public DbSet<Tickets> Tickets { get; set; }

        public DbSet<Query> Query { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}
