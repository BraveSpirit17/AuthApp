using System.Security.Cryptography;
using AuthApp.Application.Interfaces;

namespace AuthApp.Application.Services;

public class PasswordHashingService : IPasswordHashingService
{
    // Значение, определяющее размер соли в байтах
    private const int SaltSize = 16;

    // Значение, определяющее размер производного ключа в байтах
    private const int KeySize = 32;

    // Значение, определяющее количество итераций алгоритма PBKDF2 для использования
    private const int Iterations = 10000;

    // Алгоритм хеширования, используемый для алгоритма PBKDF2
    private static readonly HashAlgorithmName HashAlgorithmName = HashAlgorithmName.SHA256;

    // Значение, используемое для разграничения значений соли и хеш-функции в сгенерированной хэш-строке
    private const char SaltDelimeter = ';';

    public string GetHash(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName, KeySize);
        
        return string.Join(SaltDelimeter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }

    public bool Validate(string passwordHash, string password)
    {
        var pwdElements = passwordHash.Split(SaltDelimeter);
        
        var salt = Convert.FromBase64String(pwdElements[0]);
        
        var hash = Convert.FromBase64String(pwdElements[1]);
        
        var hashInput = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName, KeySize);
        
        return CryptographicOperations.FixedTimeEquals(hash, hashInput);
    }
}