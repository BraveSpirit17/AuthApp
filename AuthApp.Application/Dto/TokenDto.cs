namespace AuthApp.Application.Dto;

public class TokenDto
{
    public string AccessToken { get; protected set; }

    public bool Success { get; protected set; }

    public string Message { get; protected set; }

    public TokenDto(string accessToken, bool success, string message)
    {
        Success = success;
        AccessToken = accessToken;
        Message = message;
    }
}