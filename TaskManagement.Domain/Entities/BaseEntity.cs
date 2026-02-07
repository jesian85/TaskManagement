using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Domain.Entities
{
    public abstract class BaseEntity { }

    public abstract class BaseEntity<TKey> : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; } = default!;

        public override bool Equals(object? obj) => obj is BaseEntity<TKey> entity && EqualityComparer<TKey>.Default.Equals(Id, entity.Id);

        public override int GetHashCode() => HashCode.Combine(Id, GetType().Name);
    }
}