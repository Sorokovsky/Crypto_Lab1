using Lab1.Crypto;
using Lab1.Utils;

namespace Lab1.Tests;

[TestClass]
public class CesarTests
{
    [TestMethod]
    public void ShouldBeCorrectEn()
    {
        var source = "test";
        var expected = "whvw";
        var key = 3;
        IEncryptor encryptor = new CezarEncryptor(Alphabets.En);
        var output = encryptor.Encrypt(source, key);
        Assert.AreEqual(expected, output);
    }

    [TestMethod]
    public void ShouldBeExceptionKeyMostBig()
    {
        var source = "test";
        var key = Alphabets.En.Length + 1;
        IEncryptor encryptor = new CezarEncryptor(Alphabets.En);
        Assert.ThrowsException<ArgumentException>(() => encryptor.Encrypt(source, key));
    }

    [TestMethod] 
    public void ShouldBeExceptionKeyMostSmall()
    {
        var source = "test";
        var key = 0;
        IEncryptor encryptor = new CezarEncryptor(Alphabets.En);
        Assert.ThrowsException<ArgumentException>(() => encryptor.Encrypt(source, key));
    }
    
    [TestMethod] 
    public void ShouldBeExceptionIncorrectType()
    {
        var source = "test";
        var key = "tests";
        IEncryptor encryptor = new CezarEncryptor(Alphabets.En);
        Assert.ThrowsException<ArgumentException>(() => encryptor.Encrypt(source, key));
    }
}