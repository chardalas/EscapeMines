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
            EscapeMinesSettings ems = new EscapeMinesSettings();

            // Act
            var valid = ems.Validate(Settings);

            // Assert
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void TestNonZeroMatrix()
        {
            // Arrange
            EscapeMinesSettings ems = new EscapeMinesSettings();

            //Settings.Add()

            // Act
            var valid = ems.Validate(Settings);

            // Assert
            Assert.IsTrue(valid);
        }


    }
}
