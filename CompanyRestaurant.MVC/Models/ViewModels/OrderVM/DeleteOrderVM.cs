﻿using CompanyRestaurant.Entities.Enums;

namespace CompanyRestaurant.MVC.Models.ViewModels.OrderVM
{
    public class DeleteOrderVM
    {
        public DeleteOrderVM()
        {
            Status=DataStatus.Deleted;
        }
        public int Id { get; set; }
        public string OrderName { get; set; }
        public decimal Price { get; set; }
        public PaymentType PaymentType { get; set; }
        public DataStatus Status { get; set; }
        public bool IsActive { get; set; }
        public int TableId { get; set; }
        public int EmployeeId { get; set; }
        public int AccountingId { get; set; }
    }
}
