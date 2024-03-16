﻿using CompanyRestaurant.BLL.Abstracts;
using CompanyRestaurant.BLL.Concretes;
using CompanyRestaurant.DAL.Context;
using CompanyRestaurant.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRestaurant.BLL.Services
{
    public class EmployeeRepository:BaseRepository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(CompanyRestaurantContext context):base(context)
        {
            
        }

        public Task<IEnumerable<Employee>> GetAllEmployeePerformances()
        {
            throw new NotImplementedException();
        }
    }
}
