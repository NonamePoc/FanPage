namespace FanPage.Application.GoogleAuth;

public class GoogleResponseDto
{
    public string? Id { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Token { get; set; }

    public string? Role { get; set; }

    public string WhoBan { get; set; }

    public string UserAvatar { get; set; }

    public DateTime LifeTimeToken { get; set; }
}
