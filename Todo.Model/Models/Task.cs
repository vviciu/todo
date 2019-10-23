using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Todo.Model.Models
{
    public class Task : ITask
    //RH: TO widziałbym razem z kontekstem w oddzielnym projekcie i opatrzone jakimś interfejsem.
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }
        public string Description { get; set; }
    }
}
