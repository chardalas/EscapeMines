using BoardGameChardalasEmmanouil;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EscapeMinesTests
{
    [TestClass]
    public class EscapeMinesSettingsValidatorTest
    {
        public List<string> Settings { get; set; }
        public EscapeMinesSettingsValidator Validator { get; set; }
        public EscapeMinesSettingsValidatorTest()
        {
            Settings = new List<string>();
            Validator = new EscapeMinesSettingsValidator();
        }

        [TestMethod]
        public void TestNonZeroMatrixValidation()
        {
            // Arrange
            string input = "0 0";

            // Act
            var serult = Validator.ValidateNonZeroMatrix(input);

            // Assert
            Assert.IsTrue(serult);
        }

        [TestMethod]
        public void TestBoardSizeValidation()
        {
            // Arrange
            string input = "4 0";

            // Act
            var serult = Validator.ValidateBoardSize(input);

            // Assert
            Assert.IsFalse(serult);
        }
        [TestMethod]
        public void ObfuscateBoardSize()
        {
            // Arrange
            string input = "@ ( 2 3";

            // Act
            var serult = Validator.ValidateBoardSize(input);

            // Assert
            Assert.IsTrue(serult);


            Assert.IsTrue(serult);
            Assert.IsTrue(serult);
            Assert.IsTrue(serult);
        }

        [TestMethod]
        public void TestMinesValidation()
        {
            // Arrange
            string input = "4,0";

            // Act
            var serult = Validator.ValidateMines(input);

            // Assert
            Assert.IsFalse(serult);
        }
    }
}
