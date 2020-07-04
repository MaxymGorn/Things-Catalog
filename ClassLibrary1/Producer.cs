using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public class Producer
    {
        [Required(ErrorMessage = "Need Id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual  List<Product> Products { get; set; }
    }
}
