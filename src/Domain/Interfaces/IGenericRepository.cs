namespace TaskManagementApplication.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> CreateAsync(T enitity);
        Task UpdateAsync(T enitity);
        Task DeleteAsync(int id);
    }
}
