using Roman.Numerals;

namespace RomanNumeralStud.Tests;

[TestClass]
public class FromRomanBadInput
{

    [TestMethod]
    public void test_blank()
    {
        // Assign
        string test_case = string.Empty;
        // Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => RomanNumeral.ParseRoman(test_case));
    }

    [TestMethod]
    public void test_null()
    {
        // Assign
        string test_case = null;
        // Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => RomanNumeral.ParseRoman(test_case));
    }

    [TestMethod]
    [DataRow("VX")]
    [DataRow("IVX")]
    [DataRow("IIX")]
    [DataRow("VVX")]
    [DataRow("XXV")]
    public void test_malformed_antecedent(string value)
    {
        // Assign
        var result = RomanNumeral.ParseRoman(value);
        // Assert
        Assert.IsNull(result, $"Expected null got {result}");
    }



    [TestMethod]
    public void test_repeated_pairs()
    {

    }

    [TestMethod]
    [DataRow("IIX")]
    [DataRow("IIV")]
    [DataRow("XIVV")]
    [DataRow("ILL")]
    public void test_too_many_repeated_numerals(string value)
    {
        // Assign
        var result = RomanNumeral.ParseRoman(value);
        // Assert
        Assert.IsNull(result, $"Expected null got {result}");
    }

}