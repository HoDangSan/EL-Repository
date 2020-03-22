using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kanban.Model.Entities
{
    public partial class KanbanDbContext : DbContext
    {
        public KanbanDbContext()
        {
        }

        public KanbanDbContext(DbContextOptions<KanbanDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<TaskList> TaskList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SAN-HO-PC;Initial Catalog=kanbandb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TaskStatuts).HasMaxLength(50);

                entity.HasOne(d => d.AssignedEmployee)
                    .WithMany(p => p.TaskAssignedEmployee)
                    .HasForeignKey(d => d.AssignedEmployeeId)
                    .HasConstraintName("FK_Task_Employee");

                entity.HasOne(d => d.List)
                    .WithMany(p => p.Task)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Task_TaskList");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.TaskOwner)
                    .HasForeignKey(d => d.OwnerId)
                    .HasConstraintName("FK_Task_Owner");
            });

            modelBuilder.Entity<TaskList>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}
