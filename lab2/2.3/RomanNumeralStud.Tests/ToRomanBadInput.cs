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
    [DataRow("Fem")]
    [DataRow("Tio")]
    [DataRow("Femton")]
    [DataRow("Tjugo")]
    [DataRow("Tjugofem")]
    [DataRow("TvåTusen")]
    public void TestForBadInputString(string input)
    {
        Assert.IsNull(RomanNumeral.ParseRoman(input));
    }

    [TestMethod]
    public void TestForAdditiveToRoman()
    {
        // Arrange
        RomanNumeral roman = new RomanNumeral(1);
        string output1;
        string output2;

        // Act
        output1 = roman.ToRoman(RomanNumeralNotation.Additive);
        output2 = roman.ToRoman(RomanNumeralNotation.Subtractive);

        // Assert
        Assert.AreEqual(output1, output2);
    }

}