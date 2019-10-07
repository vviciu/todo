using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace todo.Controllers
{
    [Route("api/[controller]")]
    public class ApiTasksController : Controller //RH: Przy podziale kontrolerów na API/MVC lepszy byłby namespace i Folder np. todo.Controllers.API
    {
        private readonly Models.todoContext _context;

        public ApiTasksController(Models.todoContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Models.Task> Get() //RH: Nazwa Task koliduje z Task z .NETa
        {
            return _context.Task.ToList(); //RH: Brakuje AsNoTracking()
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Models.Task Get(int id)
        {
            var task = _context.Task.FirstOrDefault(m => m.Id == id);
            if (task == null)
            {
                return null; //RH: Jeśli jest nullem to i tak zwróci nulla
            }
            return task;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Models.Task task)
        {
            _context.Task.Add(task);
            _context.SaveChangesAsync(); //RH: To jest nigdzie nie awaitowany Async, w razie problemów nie złapiesz wyjątków w żaden sposób
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Models.Task task)
        {
            var taskToUpdate = _context.Task.FirstOrDefault(x => x.Id == id);
            if (taskToUpdate != null)
            {
                taskToUpdate.Name = task.Name;
                taskToUpdate.Description = task.Description;
                taskToUpdate.DeadlineDate = task.DeadlineDate;
                _context.SaveChangesAsync(); //RH: jw.
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var task = _context.Task.Find(id);
            _context.Task.Remove(task);
            _context.SaveChangesAsync(); //RH: jw.
        }
    }
}
