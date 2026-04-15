using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WorkingOutHobby.Models;

namespace WorkingOutHobby.Services;

public class AuthService(WorkoutDbContext context, IConfiguration configuration) : IAuthService
{
    public async Task<User?> RegisterAsync(UserDto request)
    {
        if (await context.Users.AnyAsync(u => u.Username == request.Username))
        {
            return null;
        }

        var user = new User();

        var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);

        user.Username = request.Username;
        user.PasswordHash = hashedPassword;

        context.Users.Add(user);
        await context.SaveChangesAsync();

        return user;
    }
}
