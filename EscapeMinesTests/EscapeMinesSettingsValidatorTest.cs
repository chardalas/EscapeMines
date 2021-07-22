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
        public void TestBoardSizeValidation()
        {
            // Arrange
            string[] invalidSettings = new string[] { "", " ", "0", "0 ", "0 0", "00", "0.0", ",0", "0,", "01 0", "0 01", "01 01" };

            foreach (var item in invalidSettings)
            {
                // Act
                var result = Validator.ValidateBoardSize(item);

                // Assert
                Assert.IsTrue(result);
            }

            string[] validSettings = new string[] { "1 1", "11 1", "1 11", "10 10", "10 1", "1 10", "101 1", "1 101", "1 2111 3 4" };

            foreach (var item in validSettings)
            {
                var result = Validator.ValidateBoardSize(item);

                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void TestMinesValidation()
        {
            // Arrange
            string[] invalidSettings = new string[] { "", " ", "0", "0 ", "0 0", "0.0", ",0", "0," };

            foreach (var item in invalidSettings)
            {
                // Act
                var result = Validator.ValidateMines(item);

                // Assert
                Assert.IsTrue(result);
            }

            string[] validSettings = new string[] { "0,0", "01,01", "01,1", "1,01", "101,110", "1,1 2,1 and 3,1" };

            foreach (var item in validSettings)
            {
                var result = Validator.ValidateMines(item);

                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void TestExitPointValidation()
        {
            // Arrange
            string[] invalidSettings = new string[] { "", " ", "0", "0 ", " 0", "0.0", ",0", "0," };

            foreach (var item in invalidSettings)
            {
                // Act
                var result = Validator.ValidateExitPoint(item);

                // Assert
                Assert.IsTrue(result);
            }

            string[] validSettings = new string[] { "0 0", "01 01", "01 1", "1 01", "101 110", "1 1 2 1 3 1" };

            foreach (var item in validSettings)
            {
                var result = Validator.ValidateExitPoint(item);

                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void TestStartingPointValidation()
        {
            // Arrange            
            string[] invalidSettings = new string[] { "", " ", "0", "0 ", " 0", "0.0", ",0", "0,", "0 0", "00", "0 0 D", "00N", "00 N", "0 0N" };

            foreach (var item in invalidSettings)
            {
                // Act
                var result = Validator.ValidateStartingPoint(item);

                // Assert
                Assert.IsTrue(result);
            }

            string[] validSettings = new string[] { "0 0 S", "0 0 E", "0 0 S", "0 0 NNNN", "101 200 N", "001 002 NEE" };

            foreach (var item in validSettings)
            {
                var result = Validator.ValidateStartingPoint(item);

                Assert.IsFalse(result);
            }
        }

        [TestMethod]
        public void TestMovesSetsValidation()
        {
            // Arrange            
            List<string> actual = new List<string> { "123LRMML##LL", "M1L_M#mR]M{M'M,R 0 M", "LMLMRMM" };
            List<string> expected = new List<string> { "LRMMLLL", "MLMRMMMRM", "LMLMRMM" };

            // Act
            var result = Validator.ValidateMovesSets(actual);

            // Assert
            Assert.IsFalse(result);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.AreEqual(expected[i], Validator.SanitizedSettings[i]);
            }
        }
    }
}
