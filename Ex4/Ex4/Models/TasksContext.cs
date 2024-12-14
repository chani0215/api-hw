using Microsoft.EntityFrameworkCore;

namespace Ex4.Models;

public partial class TasksContext : DbContext
{
    public TasksContext()
    {
    }

    public TasksContext(DbContextOptions<TasksContext> options): base(options) { }
    public virtual DbSet<Users> Users { get; set; }
    public virtual DbSet<Tasks> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Users>(entity =>
        {
            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.UserName)
            .HasMaxLength(50)
            .IsUnicode(false);
        });

        modelBuilder.Entity<Tasks>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Tasks");
            entity.Property(e => e.Description)
            .HasMaxLength(250)
            .IsUnicode(false);
            entity.Property(e => e.Name)
            .HasMaxLength(50)
            .IsUnicode(false);
            entity.HasOne(d => d.Users).WithMany(p => p.Tasks)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_UserToAuthor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    private void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }
}
