namespace BookStore.Client.Services.CustomerServices
{
	public interface ICustomerService
	{
		List<Customer> Customers { get; set; }
		Task GetCustomers();
		Task CreateCustomer(Customer customer);
		Task UpdateCustomer(Customer customer, int id);
		Task DeleteCustomer(int id);
	}
}
