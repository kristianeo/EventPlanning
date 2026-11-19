using EventPlanning.Dtos;
using EventPlanning.Models;

namespace EventPlanning.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(int id);
    Task<UserDto> CreateAsync(CreateUserDto dto);
    Task<DeleteResult> DeleteAsync(int id);
}