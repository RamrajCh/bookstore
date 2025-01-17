﻿namespace BookStore.Client.Services.SaleServices
{
    public interface ISaleService
    {
        List<Sale> Sales { get; set; }
        Task GetSales();
        Task<Sale> GetASale(int id);
        Task CreateSale(Sale sale);
        Task UpdateSale(Sale sale, int id);
        Task DeleteSale(int id);
        Task<List<SalesItem>> GetSalesDetails(int id);
    }
}
