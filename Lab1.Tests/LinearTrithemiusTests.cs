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
        var expected = "Hvxxj";
        var encryptor = new LinearTrithemiusEncryptor(Alphabets.En);
        var result = encryptor.Encrypt(source, key);
        Assert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void ShouldBeCorrectDecryptEn()
    {
        var key = new List<int>([3, 5]);
        var source = "Hvxxj";
        var expected = "Hello";
        var encryptor = new LinearTrithemiusEncryptor(Alphabets.En);
        var result = encryptor.Decrypt(source, key);
        Assert.AreEqual(expected, result);
    }
}