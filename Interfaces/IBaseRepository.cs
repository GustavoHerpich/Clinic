namespace Clinic.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> FindAllAsync();
    }
}
