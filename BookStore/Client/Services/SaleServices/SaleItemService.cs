using BookStore.Shared;
using System.Net.Http.Json;

namespace BookStore.Client.Services.SaleServices
{
	public class SaleItemService : ISalesItemService
	{
		private readonly HttpClient _http;

		public List<SalesItem> SalesItems { get; set; } = new List<SalesItem>();

        public SaleItemService(HttpClient http)
        {
			_http = http;
		}

        public async Task CreateSaleItem(SalesItem salesItem)
		{
			await _http.PostAsJsonAsync("api/salesitems", salesItem);
		}

		public async Task DeleteSaleItem(int id)
		{
			await _http.DeleteAsync($"api/salesitems/{id}");
		}

		public async Task GetSalesItems()
		{
			var result = await _http.GetFromJsonAsync<List<SalesItem>>("api/salesitems");
			if (result != null) SalesItems = result;
		}

		public async Task UpdateSaleItem(SalesItem salesItem, int id)
		{
			await _http.PutAsJsonAsync($"api/salesitems/{id}", salesItem);
		}
	}
}
