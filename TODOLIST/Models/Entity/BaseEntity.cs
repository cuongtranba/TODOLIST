using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TODOLIST.Models.Entity
{
    public abstract class BaseEntity<V>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public V Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}