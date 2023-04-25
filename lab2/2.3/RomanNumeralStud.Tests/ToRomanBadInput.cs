using Roman.Numerals;

namespace RomanNumeralStud.Tests;

[TestClass]
public class ToRomanBadInput
{
    [TestMethod]
    [DataRow(0)]
    [DataRow(-1)]
    [ExpectedException(typeof(System.ArgumentOutOfRangeException))]
    public void ReturnArgumentOutOfRange(int input)
    {
        new RomanNumeral(input).ToString();
    }

    [TestMethod]
    public void TestForBadInputString()
    {
        Assert.IsNull(RomanNumeral.ParseRoman("TvåTusen"));
    }
    
}