using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = TaskManagement.Domain.Entities.Task;

namespace TaskManagement.Infrastructure.Persistence.Configurations
{
    internal class TaskTypeConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.Description)
                .HasMaxLength(500);

            builder.Property(t => t.Priority)
                .HasConversion<int>();

            builder.Property(t => t.Status)
                .HasConversion<int>();

            builder.Property(t => t.CreatedOn)
                .HasDefaultValueSql("NOW()");

            builder.Property(t => t.UpdatedOn)
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAddOrUpdate();

            builder.HasIndex(t => t.Status);
            builder.HasIndex(t => t.Priority);
            builder.HasIndex(t => t.DueDate);
        }
    }
}