namespace BookStore.Client.Services.CustomerServices
{
	public interface ICustomerService
	{
		List<Customer> Customers { get; set; }
		Task GetCustomers();
		Task<Customer> GetASingleCustomer(int id);
		Task<Customer> CreateCustomer(Customer customer);
		Task UpdateCustomer(Customer customer, int id);
		Task DeleteCustomer(int id);
		Task<Customer> GetCustomerFromPhoneNumber(Customer customer);
	}
}
