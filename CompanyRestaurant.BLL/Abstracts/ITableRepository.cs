﻿using CompanyRestaurant.Entities.Entities;

namespace CompanyRestaurant.BLL.Abstracts
{
    public interface ITableRepository : IRepository<Table>
    {
        Task OpenTable(int tableId);
        Task CloseTable(int tableId);
        Task<IEnumerable<TableReportViewModel>> GetTableUsageReport(DateTime startDate, DateTime endDate);
    }

}
