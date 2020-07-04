using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public class Product
    {
        [Required(ErrorMessage = "Need Id")]
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public int ProducerId { get; set; }
        [Range(0, 90000000000, ErrorMessage = "Eror cost")]
        public decimal Cost { get; set; }
        [Range(0, 90000000000, ErrorMessage = "Eror count")]
        public int Count { get; set; }

        public virtual Category Category { get; set; }
        public virtual Producer Producer { get; set; }
    }
}
