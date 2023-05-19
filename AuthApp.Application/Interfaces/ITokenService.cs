namespace AuthApp.Application.Interfaces;

public interface ITokenService
{
    string TokenGeneration(string userName);
}