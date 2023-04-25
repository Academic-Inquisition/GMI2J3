using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Roman.Numerals;
using System;

namespace RomanNumeralStud.Tests
{
    [TestClass]
    public class RomanOperatorTests
    {
        [TestMethod]
        [TestCategory("PlusOperator")]
        [DataRow(2, 1)]
        [DataRow(4, 2)]
        [DataRow(6, 3)]
        [DataRow(8, 4)]
        [DataRow(10, 5)]
        public void AdditionTestIntStringOperator(int expected, int value)
        {
            // Arrange
            RomanNumeral roman = new RomanNumeral(value);
            RomanNumeral result1 = value + roman;
            RomanNumeral result2 = roman + value;

            // Assert
            Assert.AreEqual(expected, result1.Number);
            Assert.AreEqual(expected, result2.Number);
        }

        [TestMethod]
        [TestCategory("PlusOperator")]
        [DataRow(2, "I")]
        [DataRow(4, "II")]
        [DataRow(6, "III")]
        [DataRow(8, "IV")]
        [DataRow(10, "V")]
        public void AdditionTestStringRomanOperator(int expected, string romanValue)
        {
            // Arrange
            RomanNumeral roman = RomanNumeral.ParseRoman(romanValue);
            RomanNumeral result1 = roman + romanValue;
            RomanNumeral result2 = romanValue + roman;

            // Assert
            Assert.AreEqual(expected, result1.Number);
            Assert.AreEqual(expected, result2.Number);
        }

        [TestMethod]
        [TestCategory("PlusOperator")]
        [DataRow(2, "I", "I")]
        [DataRow(4, "II", "II")]
        [DataRow(6, "III", "III")]
        [DataRow(8, "IV", "IV")]
        [DataRow(10, "V", "V")]
        public void AdditionTestRomanRomanOperator(int expected, string roman1, string roman2)
        {
            // Arrange
            RomanNumeral parsed1 = RomanNumeral.ParseRoman(roman1);
            RomanNumeral parsed2 = RomanNumeral.ParseRoman(roman2);
            RomanNumeral result1 = parsed1 + parsed2;
            RomanNumeral result2 = parsed2 + parsed1;

            // Assert
            Assert.AreEqual(expected, result1.Number);
            Assert.AreEqual(expected, result2.Number);
        }

        [TestMethod]
        [TestCategory("MinusOperator")]
        [DataRow(2, 3, 1)]
        [DataRow(4, 6, 2)]
        [DataRow(6, 9, 3)]
        [DataRow(8, 12, 4)]
        [DataRow(10, 15, 5)]
        public void SubtractionTestIntStringOperator(int expected, int value, int romanValue)
        {
            // Arrange
            RomanNumeral roman1 = new RomanNumeral(value);
            RomanNumeral roman2 = new RomanNumeral(romanValue);
            RomanNumeral result1 = roman1 - romanValue;
            RomanNumeral result2 = value - roman2;

            // Assert
            Assert.AreEqual(expected, result1.Number);
            Assert.AreEqual(expected, result2.Number);
        }

        [TestMethod]
        [TestCategory("MinusOperator")]
        [DataRow(2, "III", "I")]
        [DataRow(4, "VI", "II")]
        [DataRow(6, "IX", "III")]
        [DataRow(8, "XII", "IV")]
        [DataRow(10, "XV", "V")]
        public void SubtractionTestStringRomanOperator(int expected, string value, string romanValue)
        {
            // Arrange
            RomanNumeral roman1 = RomanNumeral.ParseRoman(value);
            RomanNumeral roman2 = RomanNumeral.ParseRoman(romanValue);
            RomanNumeral result1 = roman1 - romanValue;
            RomanNumeral result2 = value - roman2;

            // Assert
            Assert.AreEqual(expected, result1.Number);
            Assert.AreEqual(expected, result2.Number);
        }

        [TestMethod]
        [TestCategory("MinusOperator")]
        [DataRow(2, "III", "I")]
        [DataRow(4, "VI", "II")]
        [DataRow(6, "IX", "III")]
        [DataRow(8, "XII", "IV")]
        [DataRow(10, "XV", "V")]
        public void SubtractionTestRomanRomanOperator(int expected, string roman1, string roman2)
        {
            // Arrange
            RomanNumeral parsed1 = RomanNumeral.ParseRoman(roman1);
            RomanNumeral parsed2 = RomanNumeral.ParseRoman(roman2);
            RomanNumeral result = parsed1 - parsed2;

            // Assert
            Assert.AreEqual(expected, result.Number);
        }

        [TestMethod]
        [TestCategory("MinusOperator")]
        public void SubstractionTestZeroOrNegative()
        {
            // Arrange
            RomanNumeral r1 = new RomanNumeral(1);
            RomanNumeral r2 = new RomanNumeral(2);

            // Assert
            try
            {
                RomanNumeral test = r1 - r1;
                Assert.IsTrue(false);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.IsTrue(true);
            }

            try
            {
                RomanNumeral test = r1 - r2;
                Assert.IsTrue(false);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod]
        [TestCategory("TypeOperator")]
        [DataRow(2, "II")]
        [DataRow(4, "IV")]
        [DataRow(6, "VI")]
        [DataRow(8, "VIII")]
        [DataRow(10, "X")]
        public void IntegerTestTypeOperator(int expected, string input)
        {
            // Arrange
            RomanNumeral parsed = RomanNumeral.ParseRoman(input);

            // Assert
            Assert.AreEqual(expected, (int)parsed);
        }

        [TestMethod]
        [TestCategory("TypeOperator")]
        [DataRow("II", 2)]
        [DataRow("IV", 4)]
        [DataRow("VI", 6)]
        [DataRow("VIII", 8)]
        [DataRow("X", 10)]
        public void StringTestTypeOperator(string expected, int input)
        {
            // Arrange
            RomanNumeral parsed = new RomanNumeral(input);

            // Assert
            Assert.AreEqual(expected, (string)parsed);
        }

        [TestMethod]
        [TestCategory("TypeOperator")]
        [DataRow(2)]
        [DataRow(4)]
        [DataRow(6)]
        [DataRow(8)]
        [DataRow(10)]
        public void RomanNumeralTestTypeOperator(int input)
        {
            Assert.IsInstanceOfType(((RomanNumeral)input), typeof(RomanNumeral));
            Assert.AreEqual(((RomanNumeral)input).Number, input);
        }
    }
}