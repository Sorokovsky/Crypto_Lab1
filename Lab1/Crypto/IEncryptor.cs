namespace Lab1.Crypto;

public interface IEncryptor
{
    public string Alphabet { get; set; }
    
    public string Encrypt(string input, int key);
}