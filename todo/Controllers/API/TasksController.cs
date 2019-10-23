using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Model.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace todo.Controllers.API
{
    [Route("api/[controller]")]
    public class TasksController : Controller //RH: Przy podziale kontrolerów na API/MVC lepszy byłby namespace i Folder np. todo.Controllers.API
    {
        private readonly TodoContext _context;

        public TasksController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Todo.Model.Models.Task> Get() //RH: Nazwa Task koliduje z Task z .NETa
        {
            return _context.Task.AsNoTracking().ToList(); //RH: Brakuje AsNoTracking()
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Todo.Model.Models.Task Get(int id)
        {
            var task = _context.Task.AsNoTracking().FirstOrDefault(m => m.Id == id);
            return task;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Todo.Model.Models.Task task)
        {
            _context.Task.Add(task);
            _context.SaveChanges(); //RH: To jest nigdzie nie awaitowany Async, w razie problemów nie złapiesz wyjątków w żaden sposób
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Todo.Model.Models.Task task)
        {
            var taskToUpdate = _context.Task.FirstOrDefault(x => x.Id == id);
            if (taskToUpdate != null)
            {
                taskToUpdate.Name = task.Name;
                taskToUpdate.Description = task.Description;
                taskToUpdate.DeadlineDate = task.DeadlineDate;
                _context.SaveChanges(); //RH: jw.
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var task = _context.Task.Find(id);
            _context.Task.Remove(task);
            _context.SaveChanges(); //RH: jw.
        }
    }
}
