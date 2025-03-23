using System.ComponentModel.DataAnnotations;

namespace Wrongcat.Api.Model;

public class User
{
    public int Id { get; init; }
    [MaxLength(256)]
    public string Email { get; init; } = "";
    [MaxLength(512)]
    public string Password { get; set; } = "";
    [MaxLength(32)]
    public string Nickname { get; set; } = "";
    [MaxLength(512)]
    public string? ProfileImageUrl { get; set; }
    [MaxLength(512)]
    public string? Bio { get; set; }
    public DateTime LastLogin { get; set; }
    public DateTime CreateAt { get; set; }
}
