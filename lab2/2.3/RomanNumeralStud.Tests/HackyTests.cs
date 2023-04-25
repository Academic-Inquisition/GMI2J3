using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roman.Numerals;
using System;
using System.Reflection;

namespace RomanNumeralStud.Tests
{
    [TestClass]
    public class HackyTests
    {
        [TestMethod]
        public void TestFor0ValueParsing()
        {
            // Arrange
            RomanNumeral roman = new RomanNumeral(1);

            // Act
            FieldInfo info = typeof(RomanNumeral).GetField("_number", BindingFlags.Instance | BindingFlags.NonPublic);
            info.SetValue(roman, 0);

            // Arrange
            Assert.AreEqual(RomanNumeral.NULLA, roman.ToRoman(RomanNumeralNotation.Additive));

        }
    }
}