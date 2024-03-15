using CompanyRestaurant.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRestaurant.Entities.Entities
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }


        //Mapping
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int? RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; } // bir
        public virtual List<ProductOrder> ProductOrders { get; set; } //çok
    }
}