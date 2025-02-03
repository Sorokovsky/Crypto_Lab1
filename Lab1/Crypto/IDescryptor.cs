namespace Lab1.Crypto;

public interface IDescryptor
{
    public string Alphabet { get; set; }

    public string Decrypt(string text, int key);
}