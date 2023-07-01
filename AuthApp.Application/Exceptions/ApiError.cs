namespace AuthApp.Application.Exceptions;

public class ApiError
{
#nullable disable
    /// <summary>
    /// Текст ответа
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Код состояния
    /// </summary>
    public int Code { get; set; }
}