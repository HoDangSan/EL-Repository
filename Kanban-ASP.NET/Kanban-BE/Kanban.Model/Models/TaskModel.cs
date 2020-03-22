using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Model.Models
{
    public class TaskModelToCreate
    {
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
    }
}
