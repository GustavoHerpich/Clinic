namespace Clinic.Interfaces.Business
{
    public interface IBaseBusiness<T> where T : class
    {
        Task<List<T>> FindAllAsync();
        Task<T> CreateAsync(T employee);
        Task<T> UpdateAsync(T employee);
        Task DeleteAsync(int id);
        Task<T> FindById(int id);
    }
}
