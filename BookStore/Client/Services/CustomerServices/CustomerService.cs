using System.Net.Http.Json;

namespace BookStore.Client.Services.CustomerServices
{
	public class CustomerService : ICustomerService
	{
		private readonly HttpClient _http;

		public List<Customer> Customers { get; set; } = new List<Customer>();

        public CustomerService(HttpClient http)
        {
			_http = http;
		}

        public async Task CreateCustomer(Customer customer)
		{
			await _http.PostAsJsonAsync("api/customers", customer);
		}

		public async Task DeleteCustomer(int id)
		{
			await _http.DeleteAsync($"api/customers/{id}");
		}

		public async Task GetCustomers()
		{
			var result = await _http.GetFromJsonAsync<List<Customer>>("api/customers");
			if (result != null)
				Customers = result;
		}

		public async Task UpdateCustomer(Customer customer, int id)
		{
			await _http.PutAsJsonAsync($"api/customers/{id}", customer);
		}
	}
}
