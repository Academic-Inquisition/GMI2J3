using Roman.Numerals;

namespace RomanNumeralStud.Tests;

[TestClass]
public class TestKnownValues
{
    [TestMethod]
    public void test_to_known_values()
    {
        // Assert
        foreach (var known in RomanKnown.values)
        {
            RomanNumeral roman = new RomanNumeral(known.Key);
            string result = roman.ToString();
            Assert.AreEqual(known.Value, result);
        }
    }


    [TestMethod]
    public void test_from_known_values()
    {
        foreach (var known in RomanKnown.FromRomanTable)
        {
            int result = RomanNumeral.ParseRoman(known.Key);
            Assert.AreEqual(known.Value, result);
        }
    }
}