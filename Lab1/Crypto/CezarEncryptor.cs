namespace Lab1.Crypto;

public class CezarEncryptor : IEncryptor
{
    public string Alphabet { get; set; }

    public CezarEncryptor(string alphabet)
    {
        Alphabet = alphabet;
    }

    public string Encrypt(string input, int key)
    { 
        throw new NotImplementedException();
    }
}