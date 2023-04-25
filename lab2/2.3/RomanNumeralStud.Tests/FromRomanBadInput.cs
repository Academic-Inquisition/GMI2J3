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
    [DataRow("IIMXCC")]
    [DataRow("VX")]
    [DataRow("DCM")]
    [DataRow("CMM")]
    [DataRow("LM")]
    [DataRow("LD")]
    [DataRow("LC")]
    public void test_malformed_antecedent(string value)
    {
        // Assign
        var result = RomanNumeral.ParseRoman(value);
        // Assert
        Assert.IsNull(result, $"Expected null got {result}");
    }



    [TestMethod]
    [DataRow("CMCM")]
    [DataRow("CDCD")]
    [DataRow("XCXC")]
    [DataRow("XLXL")]
    [DataRow("IXIX")]
    [DataRow("IVIV")]
    public void test_repeated_pairs(string value)
    {
        // Assign
        var result = RomanNumeral.ParseRoman(value);
        // Assert
        Assert.IsNull(result, $"Expected null got {result}");
    }

    [TestMethod]
    [DataRow("VVVVVXIIVIIXVIXVXIVIXVIXVIX")]
    public void test_too_many_repeated_numerals(string value)
    {
        // Assign
        var result = RomanNumeral.ParseRoman(value);
        // Assert
        Assert.IsNull(result, $"Expected null got {result}");
    }

    [TestMethod]
    [DataRow(1, "i")]
    [DataRow(5, "v")]
    [DataRow(10, "x")]
    [DataRow(50, "l")]
    [DataRow(100, "c")]
    [DataRow(500, "d")]
    [DataRow(1000, "m")]
    public void test_lower_case(int expected, string input)
    {
        Assert.AreEqual(expected, RomanNumeral.ParseRoman(input).Number, $"Expected {expected} got null");
    }

    [TestMethod]
    public void testABC()
    {
        int i = 2;
        Assert.IsTrue(i == (1 + new RomanNumeral(1)));
    }

}