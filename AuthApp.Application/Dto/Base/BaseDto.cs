namespace AuthApp.Application.Dto.Base;

public class BaseDto
{
    public bool Success { get; protected set; }

    public string Message { get; protected set; }

    public BaseDto(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}