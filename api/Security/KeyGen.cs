using System.Security.Cryptography;

public class KeyGen
{
    public static string GenerateApiKey(int length)
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            var bytes = new byte[length / 2];
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}