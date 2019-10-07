using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace todo.Models
{
    public class todoContext : DbContext //RH: Myślę, że dobrze by było mieć to w oddzielnym projekcie, podobnie logikę z kontrolerów przeniósłbym do jakichś serwisów, ale to przy okazji wykorzystywania bilbioteki MediatR
    {
        public todoContext (DbContextOptions<todoContext> options)
            : base(options)
        {
        }

        public DbSet<todo.Models.Task> Task { get; set; }
    }
}
