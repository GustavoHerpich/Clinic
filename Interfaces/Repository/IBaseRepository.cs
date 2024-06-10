namespace Clinic.Interfaces.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> FindAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<T> FindById(int id);
    }
}
