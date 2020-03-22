using System;
using System.Collections.Generic;

namespace Kanban.Model.Entities
{
    public partial class TaskList
    {
        public TaskList()
        {
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Task> Task { get; set; }
    }
}
