namespace BookStore.Client.Services.SaleServices
{
	public interface ISalesItemService
	{
		List<SalesItem> SalesItems { get; set; }
		Task GetSalesItems();
		Task CreateSaleItem(SalesItem salesItem);
		Task UpdateSaleItem(SalesItem salesItem, int id);
		Task DeleteSaleItem(int id);
		Task<Sale> CreateSalesItems(int customerId, List<SalesItem> salesItems);
	}
}
