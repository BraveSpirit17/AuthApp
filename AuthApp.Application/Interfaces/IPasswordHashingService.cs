namespace AuthApp.Application.Interfaces;

public interface IPasswordHashingService
{
    string GetHash(string password);

    bool Validate(string passwordHash, string password);
}