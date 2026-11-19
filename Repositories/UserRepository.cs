using EventPlanning.Interfaces;
using EventPlanning.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlanning.Repositories;

public class UserRepository(EventDbContext database) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAllAsync() => 
        await database.Users
            .AsNoTracking()
            .ToListAsync();

    public async Task<User?> GetByIdAsync(int id) => 
        await database.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == id);

    public async Task<User> CreateAsync(CreateUser createUser)
    {
        User user = new User
        {
            FirstName = createUser.FirstName,
            LastName = createUser.LastName,
            Email = createUser.Email
        };

        database.Add(user);
        await database.SaveChangesAsync();

        return user;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await database.Users.FindAsync(id);
        
        if (user is null) return false;
        
        database.Users.Remove(user);
        await database.SaveChangesAsync();
        return true;
    }
}