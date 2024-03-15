﻿using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Models.ViewModels.MaterialVM
{
    public class DeleteMaterialVM
    {
        public DeleteMaterialVM()
        {
            Status=DataStatus.Deleted;
        }
        public int Id { get; set; }
        public string MaterialName { get; set; }
        public decimal Price { get; set; }
        public short UnitInStock { get; set; }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
        public int SupplierId { get; set; }



    }
}
