using Kanban.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Model.Models
{
    public class TaskListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TaskModel> Tasks { get; set; }
    }

    public class TaskModel
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

        public EmployeeModel AssignedEmployee { get; set; }
        public EmployeeModel Owner { get; set; }
    }

    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
