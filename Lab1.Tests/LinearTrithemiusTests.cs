using Lab1.Crypto;
using Lab1.Utils;

namespace Lab1.Tests;

[TestClass]
public class LinearTrithemiusTests
{
    [TestMethod]
    public void ShouldBeCorrectEncryptEn()
    {
        var key = new List<int>([3, 5]);
        var source = "Hello";
        var expected = "Mmwzf";
        var encryptor = new LinearTrithemiusEncryptor(Alphabets.En);
        var result = encryptor.Encrypt(source, key);
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void ShouldBeCorrectDecryptEn()
    {
        var key = new List<int>([3, 5]);
        var source = "Mmwzf";
        var expected = "Hello";
        var encryptor = new LinearTrithemiusEncryptor(Alphabets.En);
        var result = encryptor.Decrypt(source, key);
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void ShouldBeCorrectEncryptUkr()
    {
        var key = new List<int>([3, 5]);
        var source = "Привіт";
        var expected = "Фшсмшз";
        var encryptor = new LinearTrithemiusEncryptor(Alphabets.Ukr);
        var result = encryptor.Encrypt(source, key);
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void ShouldBeCorrectDecryptUkr()
    {
        var key = new List<int>([3, 5]);
        var source = "Фшсмшз";
        var expected = "Привіт";
        var encryptor = new LinearTrithemiusEncryptor(Alphabets.Ukr);
        var result = encryptor.Decrypt(source, key);
        Assert.AreEqual(expected, result);
    }
}