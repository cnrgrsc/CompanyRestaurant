using CompanyRestaurant.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRestaurant.Entities.Entities
{
    public class Category:BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public string CategoryName { get; set; }
        public string? Description { get; set; }

        //Mapping
        public virtual List<Product> Products { get; set; }
    }
}
