using System;

namespace Todo.Model.Models
{
    public interface ITask
    {
        DateTime DeadlineDate { get; set; }
        string Description { get; set; }
        int Id { get; set; }
        string Name { get; set; }
    }
}