using Microsoft.EntityFrameworkCore;
using Wrongcat.Api.Data;
using Wrongcat.Api.Model;
using Wrongcat.Api.Model.AuthDto;

namespace Wrongcat.Api.Services;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterDto registerDto);
}

public class AuthService(ApplicationDbContext db) : IAuthService
{
    public async Task<bool> RegisterAsync(RegisterDto registerDto)
    {
        var isEmailTaken = await db.Users.AnyAsync(u => u.Email == registerDto.Email);
        if (isEmailTaken)
        {
            return false;
        }
        
        var currentDateTime = DateTime.UtcNow;
        var user = new User
        {
            Email = registerDto.Email,
            Password = registerDto.Password,
            Nickname = registerDto.Nickname,
            ProfileImageUrl = null,
            Bio = null,
            LastLogin = currentDateTime,
            CreateAt = currentDateTime
        };
        
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        
        await db.Users.AddAsync(user);
        await db.SaveChangesAsync();

        return true;
    }
}
