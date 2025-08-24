using Lesson8.Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.Infrastructure.Data.Entities
{
    public class CategoryEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("Name")]
        public string Name { get; set; }
                
        public virtual ICollection<ProductEntity> ProductsEntity { get; set; }
    }
}
