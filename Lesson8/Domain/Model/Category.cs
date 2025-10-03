using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8.Domain.Model
{
    public class Category
    {      
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
