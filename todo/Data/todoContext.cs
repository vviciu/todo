using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace todo.Models
{
    public class todoContext : DbContext
    {
        public todoContext (DbContextOptions<todoContext> options)
            : base(options)
        {
        }

        public DbSet<todo.Models.Task> Task { get; set; }
    }
}
