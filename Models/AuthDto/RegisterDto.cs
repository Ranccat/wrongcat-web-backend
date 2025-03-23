namespace Wrongcat.Api.Model.AuthDto;

public class RegisterDto(string email, string password, string nickname)
{
    public string Email { get; set; } = email;
    public string Password { get; set; } = password;
    public string Nickname { get; set; } = nickname;
}
