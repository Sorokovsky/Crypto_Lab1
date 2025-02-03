namespace Lab1.Crypto;

public interface IEncryptor
{
    public string Alphabet { get; init; }
    
    public string Encrypt(string input, object key);

    public string Decrypt(string input, object key);
}