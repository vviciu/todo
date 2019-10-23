using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Model.Data;

namespace todo.Helpers
{
    public static class Utils
    {
        public static bool TaskExists(int id, TodoContext _context) //RH: Raczej nie powinno to być w kontrolerze.
        {
            return _context.Task.Any(e => e.Id == id);
        }
    }
}
