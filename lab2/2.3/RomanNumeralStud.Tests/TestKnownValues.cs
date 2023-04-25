using Roman.Numerals;

namespace RomanNumeralStud.Tests;

[TestClass]
public class TestKnownValues
{
    [TestMethod]
    [DataRow("I", 1)]
    [DataRow("V", 5)]
    [DataRow("X", 10)]
    [DataRow("MCMX", 1910)]
    [DataRow("MMXXIII", 2023)]
    public void test_to_known_values(string numeral, int expected)
    {
        Assert.AreEqual(expected, RomanNumeral.ParseRoman(numeral).Number);
    }


    [TestMethod]
    [DataRow(5, "V")]
    [DataRow(10, "X")]
    [DataRow(1910, "MCMX")]
    public void test_from_known_values(int number, string expected)
    {
        Assert.AreEqual(expected, new RomanNumeral(number).ToString());
    }
}