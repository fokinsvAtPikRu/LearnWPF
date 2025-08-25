using Lesson8.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson8.Infrastructure.Data.Entities
{
    public class ProductEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Price { get; set; }

        [ForeignKey("Category")]
        [Column("Category_id")]
        public int CategoryId { get; set; }

        [Required]
        public string Image { get; set; }

        public virtual CategoryEntity CategoryEntity { get; set; }
    }
}
