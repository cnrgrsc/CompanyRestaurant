using CompanyRestaurant.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRestaurant.Entities.Entities
{
    public class RecipeMaterial:BaseEntity
    {
        public int RecipeID { get; set; }
        public int MaterialID { get; set; }

        //Relation properties
        public virtual Recipe Recipe { get; set; }
        public virtual Material Material { get; set; }

        public decimal Quantity { get; set; }
    }
}
