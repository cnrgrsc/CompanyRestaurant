using CompanyRestaurant.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRestaurant.Entities.Interfaces
{
    public interface IEntity
    {
        public int ID { get; set; }

        //Create
        public DateTime? CreatedDate { get; set; }
        public string? CreatedComputerName { get; set; }
        public string? CreatedIpAddress { get; set; }

        //Update
        public DateTime? UpdatedDate { get; set; }
        public string? UpdatedComputerName { get; set; }
        public string? UpdatedIpAddress { get; set; }

        //Veri UI'dan silinecek ama veritabında kalıcak.
        public DataStatus? Status { get; set; }

        public bool IsActive { get; set; }
    }
}
