namespace TvMaze.Application.Infrastructure.Persistence.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using TvMaze.Application.Domain.Todos;

    /// <summary>
    /// Defines the <see cref="TodoItemConfiguration" />.
    /// </summary>
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        /// <summary>
        /// The Configure.
        /// </summary>
        /// <param name="builder">The builder<see cref="EntityTypeBuilder{TodoItem}"/>.</param>
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}