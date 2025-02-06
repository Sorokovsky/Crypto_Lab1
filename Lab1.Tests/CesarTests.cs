using Lab1.Crypto;
using Lab1.Utils;

namespace Lab1.Tests;

[TestClass]
public class CesarTests
{
    [TestMethod]
    public void ShouldBeCorrectEncryptEn()
    {
        var source = "test";
        var expected = "whvw";
        var key = 3;
        IEncryptor encryptor = new CezarEncryptor(Alphabets.En);
        var output = encryptor.Encrypt(source, key);
        Assert.AreEqual(expected, output);
    }
    
    [TestMethod]
    public void ShouldBeCorrectDecryptEn()
    {
        var source = "whvw";
        var expected = "test";
        var key = 3;
        IEncryptor encryptor = new CezarEncryptor(Alphabets.En);
        var output = encryptor.Decrypt(source, key);
        Assert.AreEqual(expected, output);
    }
    
    [TestMethod]
    public void ShouldBeCorrectEncryptUk()
    {
        var source = "Сороковський Андрій Іванович 2022";
        var expected = "Фсуснсдфанйм Гржукм Кдгрсдйь 2022";
        var key = 3;
        IEncryptor encryptor = new CezarEncryptor(Alphabets.Ukr);
        var output = encryptor.Encrypt(source, key);
        Assert.AreEqual(expected, output);
    }
    
    [TestMethod]
    public void ShouldBeCorrectDecryptUk()
    {
        var source = "Фсуснсдфанйм Гржукм Кдгрсдйь 2022";
        var expected = "Сороковський Андрій Іванович 2022";
        var key = 3;
        IEncryptor encryptor = new CezarEncryptor(Alphabets.Ukr);
        var output = encryptor.Decrypt(source, key);
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