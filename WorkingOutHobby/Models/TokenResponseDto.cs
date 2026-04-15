namespace WorkingOutHobby.Models;

public class TokenResponseDto
{
    public required string Jwt { get; set; }
    public required string RefreshToken { get; set; }
}
