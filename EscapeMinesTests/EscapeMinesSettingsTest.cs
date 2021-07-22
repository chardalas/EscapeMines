using BoardGameChardalasEmmanouil;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EscapeMinesTests
{
    [TestClass]
    public class EscapeMinesSettingsTest
    {
        public List<string> Settings { get; set; }

        public EscapeMinesSettingsTest()
        {
            Settings = new List<string>();
        }

        [TestMethod]
        public void TestValidateWithEmptyList()
        {
            // Arrange
            EscapeMinesSettingsLoader ems = new EscapeMinesSettingsLoader();

            // Act
            //var valid = ems.Validate(Settings);

            // Assert
            //Assert.IsTrue(valid);
        }

        [TestMethod]
        public void TestNonZeroMatrix()
        {
            // Arrange
            EscapeMinesSettingsLoader ems = new EscapeMinesSettingsLoader();

            //Settings.Add()

            // Act
            //var valid = ems.Validate(Settings);

            // Assert
            //Assert.IsTrue(valid);
        }


    }
}
