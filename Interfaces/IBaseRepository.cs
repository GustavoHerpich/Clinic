﻿namespace Clinic.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> FindAllAsync();
        Task<T> CreateAsync(T employee);
        Task<T> UpdateAsync(T employee);
        Task DeleteAsync(int id);
    }
}
