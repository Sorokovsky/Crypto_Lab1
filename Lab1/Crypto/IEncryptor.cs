namespace Lab1.Crypto;

public interface IEncryptor
{
    public string Alphabet { get; init; }
    
    public string Encrypt(string input, int key);
}