using System;
using System.Collections.Generic;

namespace Kanban.Model.Entities
{
    public partial class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? OwnerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string TaskStatuts { get; set; }
        public int? Priority { get; set; }
        public int? Completion { get; set; }
        public int? AssignedEmployeeId { get; set; }
        public double? IndexTask { get; set; }
        public int ListId { get; set; }

        public Employee AssignedEmployee { get; set; }
        public TaskList List { get; set; }
        public Employee Owner { get; set; }
    }
}
