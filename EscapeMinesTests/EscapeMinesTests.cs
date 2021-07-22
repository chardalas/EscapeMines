using BoardGameChardalasEmmanouil;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace EscapeMinesTests
{
    [TestClass]
    public class EscapeMinesTests
    {
        [TestMethod]
        public void TestSetupTiles()
        {
            // Arrange

            // Act
            // Assert
        }

        [TestMethod]
        public void TestPlay()
        {
            // Arrange
            IBoardGame em = new EscapeMines();

            List<string> settings = new List<string> { "3 3", "2,1 0,2 ", "1 2", "0 0 N", "RMM", "LLMLMM", "LLMM M", "M", "L", "R" };
            List<Turtle> turtles = new List<Turtle>
            {
                new Turtle{ Coordinates= new Coordinates{ x = 0, y = 2  }, Orientation = 'E'},
                new Turtle{ Coordinates= new Coordinates{ x = 1, y = 2  }, Orientation = 'E'},
                new Turtle{ Coordinates= new Coordinates{ x = 3, y = 0  }, Orientation = 'S'},
                new Turtle{ Coordinates= new Coordinates{ x = -1, y = 0  }, Orientation = 'N'},
                new Turtle{ Coordinates= new Coordinates{ x = 0, y = 0  }, Orientation = 'W'},
                new Turtle{ Coordinates= new Coordinates{ x = 0, y = 0  }, Orientation = 'E'}
            };
            int index = 0;
            // Act
            em.SetupBoard(settings);

            // Assert
            foreach (var moves in settings.Skip(4).Take(settings.Count))
            {
                em.Play(moves);
                Assert.AreEqual(turtles[index].Coordinates.x, em.Pawns[0].Coordinates.x);
                Assert.AreEqual(turtles[index].Coordinates.y, em.Pawns[0].Coordinates.y);
                Assert.AreEqual(turtles[index++].Orientation, em.Pawns[0].Orientation);
                em.ResetPawn();
            }
        }
    }
}
