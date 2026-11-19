using EventPlanning.Models;

namespace EventPlanning.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task <User> CreateAsync(CreateUser createUser);
    Task<bool> DeleteAsync(int id);
}