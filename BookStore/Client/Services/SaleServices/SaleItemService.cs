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
			var result = await _http.PostAsJsonAsync("api/salesitems", salesItem);
			if (!result.IsSuccessStatusCode)
			{
				throw new Exception("Error in creating sale item!");
			}
		}

		public async Task DeleteSaleItem(int id)
		{
			var result = await _http.DeleteAsync($"api/salesitems/{id}");
			if (!result.IsSuccessStatusCode)
			{
				throw new Exception("Error in deleting sale item!");
			}
		}

		public async Task GetSalesItems()
		{
			var result = await _http.GetFromJsonAsync<List<SalesItem>>("api/salesitems");
			if (result != null) SalesItems = result;
		}

		public async Task UpdateSaleItem(SalesItem salesItem, int id)
		{
			var result = await _http.PutAsJsonAsync($"api/salesitems/{id}", salesItem);
			if (!result.IsSuccessStatusCode)
			{
				throw new Exception("Error in updating sale item!");
			}
		}

        public async Task<Sale> CreateSalesItems(int customerId, List<SalesItem> salesItems)
        {
            // post to sales table (create new sale)
			var sale = new Sale() { 
				CustomerId = customerId,
				SaleDate = DateTime.Now,
			};
			var result = await _http.PostAsJsonAsync("api/sales", sale);
			if (result.IsSuccessStatusCode)
			{
				var response = await result.Content.ReadFromJsonAsync<Sale>();
				foreach (var saleItem in salesItems)
				{
					// post each sale item to SalesItem table
					saleItem.SaleId = response!.SaleId;
					await _http.PostAsJsonAsync("api/salesitems", saleItem);

					// update the quantity of book (stock)
					var book = await _http.GetFromJsonAsync<Book>($"api/books/{saleItem.BookId}");
					book!.Stock -= saleItem.Quantity;
					await _http.PutAsJsonAsync($"api/books/{book.BookId}", book);
				}
				return response!;
            }
			throw new Exception("Error in creating sale!!");
        }
    }
}
