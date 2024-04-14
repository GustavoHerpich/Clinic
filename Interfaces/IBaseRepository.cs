namespace Clinic.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> FindAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
