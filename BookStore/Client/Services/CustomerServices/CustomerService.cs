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

        public async Task<Customer> CreateCustomer(Customer customer)
		{
			var result = await _http.PostAsJsonAsync("api/customers", customer);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadFromJsonAsync<Customer>();
                return response!;
            }
			throw new Exception("Error in creating customer!");
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

        public async Task<Customer> GetCustomerFromPhoneNumber(Customer customer)
        {
			var result = await _http.PostAsJsonAsync("api/customers/pno", customer);
			if (result.IsSuccessStatusCode)
			{
				var response = await result.Content.ReadFromJsonAsync<Customer>();
                return response!;
            }
			return customer;
        }

        public async Task<Customer> GetASingleCustomer(int id)
        {
            var result = await _http.GetFromJsonAsync<Customer>($"api/customers/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Hero not found!!");

        }
    }
}
