using CompanyRestaurant.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRestaurant.Entities.Entities
{
    public class Customer:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public int? CurrentAccountId { get; set; }
        public virtual Current CurrentAccount { get; set; }

        //Relation properties
        public virtual List<Rezervation> Rezervations { get; set; }
    }
}
