using Roman.Numerals;

namespace RomanNumeralStud.Tests;

[TestClass]
public class RoundTripCheck
{

    [TestMethod]
    public void test_roundtrip()
    {
        // Arrange
        int i = 5;
        string expected = "V";

        // Act
        string actual = new RomanNumeral(i);
        int result = RomanNumeral.ParseRoman(actual);

        // Assert
        Assert.AreEqual(expected, actual);
        Assert.AreEqual(i, result);

    }

}