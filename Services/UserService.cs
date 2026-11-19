using EventPlanning.Dtos;
using EventPlanning.Interfaces;
using EventPlanning.Models;
using EventPlanning.UserTest;

namespace EventPlanning.Services;

public class UserService(
    IUserRepository repository, 
    ILogger<UserService> logger,
    ICurrentUser currentUser) : IUserService
{
    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        var users = await repository.GetAllAsync();
        return users.Select(e => e.ToDto()).ToList();
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        User? user = await repository.GetByIdAsync(id);

        if (user != null)
        {
            return user.ToDto();
        }
        
        logger.LogWarning("User {UserId} not found, returning empty result",
            id);
        return null;
    }

    public async Task<UserDto> CreateAsync(CreateUserDto dto)
    {
        logger.LogInformation("Creating user with email {Email}",
            dto.Email);
        
        CreateUser createUser = new CreateUser
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email
        };

        User user = await repository.CreateAsync(createUser);

        return user.ToDto();
    }

    public async Task<DeleteResult> DeleteAsync(int userId)
    {
        var user = await repository.GetByIdAsync(userId);
        if (user is null)
            return DeleteResult.NotFound;

        if (user.Id != currentUser.UserId)
        {
            logger.LogWarning("User {UserId} tried to delete user {TargetUserId}",
                currentUser.UserId, userId);
            return DeleteResult.Forbidden;
        }

        await repository.DeleteAsync(userId);
        return DeleteResult.Deleted;
    }
}