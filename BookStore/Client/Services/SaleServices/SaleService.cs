using System.Net.Http.Json;

namespace BookStore.Client.Services.SaleServices
{
    public class SaleService : ISaleService
    {
        private readonly HttpClient _http;

        public List<Sale> Sales { get; set; } = new List<Sale>();

        public SaleService(HttpClient http)
        {
            _http = http;
        }

        public async Task CreateSale(Sale sale)
        {
            await _http.PostAsJsonAsync("api/sales", sale);
        }

        public async Task DeleteSale(int id)
        {
            await _http.DeleteAsync($"api/sales/{id}");
        }

        public async Task GetSales()
        {
            var result = await _http.GetFromJsonAsync<List<Sale>>("api/sales");
            if (result != null)
                Sales = result;
        }

        public async Task UpdateSale(Sale sale, int id)
        {
            await _http.PutAsJsonAsync($"api/sales/{id}", sale);
        }

        public async Task<List<SalesItem>> GetSalesDetails(int id)
        {
            var result = await _http.GetFromJsonAsync<List<SalesItem>>($"api/sales/detail/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Sale Not Found!!");
        }
    }
}
