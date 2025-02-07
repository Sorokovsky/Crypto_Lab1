namespace Lab1.Crypto;

public interface IEncryptor<TKey>
{
    public string Alphabet { get; init; }
    
    public string Encrypt(string input, TKey key);

    public string Decrypt(string input, TKey key);
}