using Lab1.Crypto;
using Lab1.Utils;

namespace Lab1.Tests;

[TestClass]
public class MottoTrithemiusTests
{
    [TestMethod]
    public void ShouldBeCorrectEncryptEn()
    {
        var source = "Sorokovsky";
        var key = "Andrey";
        var expected = "Sbufomvfnp";
        var encryptor = new MottorTrithemiusEncryptor(Alphabets.En);
        var result = encryptor.Encrypt(source, key);
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void ShouldBeCorrectDecryptEn()
    {
        var source = "Sbufomvfnp";
        var key = "Andrey";
        var expected = "Sorokovsky";
        var encryptor = new MottorTrithemiusEncryptor(Alphabets.En);
        var result = encryptor.Decrypt(source, key);
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void ShouldBeCorrectEncryptUkr()
    {
        var source = "Сороковський";
        var key = "Андрій";
        var expected = "Свхдхювдвбсц";
        var encryptor = new MottorTrithemiusEncryptor(Alphabets.Ukr);
        var result = encryptor.Encrypt(source, key);
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void ShouldBeCorrectDecryptUkr()
    {
        var source = "Свхдхювдвбсц";
        var key = "Андрій";
        var expected = "Сороковський";
        var encryptor = new MottorTrithemiusEncryptor(Alphabets.Ukr);
        var result = encryptor.Decrypt(source, key);
        Assert.AreEqual(expected, result);
    }
}