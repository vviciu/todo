using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Model.Data
{
    public class TodoContext : DbContext //RH: Myślę, że dobrze by było mieć to w oddzielnym projekcie, podobnie logikę z kontrolerów przeniósłbym do jakichś serwisów, ale to przy okazji wykorzystywania bilbioteki MediatR
    {
        public TodoContext (DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<Todo.Model.Models.Task> Task { get; set; }
    }
}
