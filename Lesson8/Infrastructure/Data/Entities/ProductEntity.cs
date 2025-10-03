using Lesson8.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson8.Infrastructure.Data.Entities
{
    [Table("Products")]
    public class ProductEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Name")]
        public string Name { get; set; }

        [Required]
        [Column("Price")]
        public int Price { get; set; }

        [ForeignKey("CategoryEntity")]
        [Column("Category_id")]
        public int CategoryId { get; set; }

        [Required]
        [Column("Image")]
        public string Image { get; set; }

        public virtual CategoryEntity CategoryEntity { get; set; }
    }
}
