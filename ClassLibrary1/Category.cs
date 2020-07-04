using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public class Category
    {
        [Required(ErrorMessage = "Need Id")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
