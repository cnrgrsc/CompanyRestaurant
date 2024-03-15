﻿using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Models.ViewModels.UnitStockVM
{
    public class DeleteUnitStockVM
    {
        public DeleteUnitStockVM()
        {
            Status=DataStatus.Deleted;
        }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
        public int Id { get; set; }
        public int Stock { get; set; }
        public int CriticalStock { get; set; }
        public int MinimumStockLevel { get; set; }
        public int MaterialID { get; set; }
    }
}
