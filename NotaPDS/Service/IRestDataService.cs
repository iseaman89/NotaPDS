namespace NotaPDS.Service
{
	public interface IRestDataService<T>
	{
		Task<List<T>> GetAllItemsAsync();
        Task AddItemAsync(T item);
		Task UpdateItemAsync(T item);
		Task DeleteItemAsync(int id);
	}
}