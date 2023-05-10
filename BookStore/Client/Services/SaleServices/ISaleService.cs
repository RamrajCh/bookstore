namespace BookStore.Client.Services.SaleServices
{
    public interface ISaleService
    {
        List<Sale> Sales { get; set; }
        Task GetSales();
        Task CreateSale(Sale sale);
        Task UpdateSale(Sale sale, int id);
        Task DeleteSale(int id);
    }
}
