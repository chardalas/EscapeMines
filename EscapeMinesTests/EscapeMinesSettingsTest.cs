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
        public void ValidateWithEmptyList()
        {
            // Arrange
            EscapeMinesSettings ems = new EscapeMinesSettings();

            // Act
            var valid = ems.Validate(Settings);

            // Assert
            Assert.AreEqual(valid, true);
        }
    }
}
