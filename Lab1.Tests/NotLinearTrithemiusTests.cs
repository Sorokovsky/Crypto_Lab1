using Lab1.Crypto;
using Lab1.Utils;

namespace Lab1.Tests;

[TestClass]
public class NotLinearTrithemiusTests
{
    [TestMethod]
    public void ShouldBeCorrectEncryptEn()
    {
        var key = new List<int>([3, 5, 7]);
        var source = "Hello";
        var expected = "Xzlqy";
        var encryptor = new NotLinearTrithemiusEncryptor(Alphabets.En);
        var result = encryptor.Encrypt(source, key);
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void ShouldBeCorrectDecryptEn()
    {
        var key = new List<int>([3, 5, 7]);
        var source = "Xzlqy";
        var expected = "Hello";
        var encryptor = new NotLinearTrithemiusEncryptor(Alphabets.En);
        var result = encryptor.Decrypt(source, key);
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void ShouldBeCorrectEncryptUkr()
    {
        var key = new List<int>([3, 5, 7]);
        var source = "Привіт";
        var expected = "Вжгакь";
        var encryptor = new NotLinearTrithemiusEncryptor(Alphabets.Ukr);
        var result = encryptor.Encrypt(source, key);
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void ShouldBeCorrectDecryptUkr()
    {
        var key = new List<int>([3, 5, 7]);
        var source = "Вжгакь";
        var expected = "Привіт";
        var encryptor = new NotLinearTrithemiusEncryptor(Alphabets.Ukr);
        var result = encryptor.Decrypt(source, key);
        Assert.AreEqual(expected, result);
    }
}