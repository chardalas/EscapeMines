using BoardGameChardalasEmmanouil;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace EscapeMinesTests
{
    [TestClass]
    public class TurtleTests
    {
        [TestMethod]
        public void TestMove()
        {
            IPawn turtle = new Turtle();

            List<char> orientations = new List<char> { 'N', 'S', 'E', 'W' };

            List<Coordinates> coordinates = new List<Coordinates>
            {
                new Coordinates{ x = 0, y = 2  },
                new Coordinates{ x = 2, y = 2  },
                new Coordinates{ x = 1, y = 3  },
                new Coordinates{ x = 1, y = 1  }
            };

            List<Turtle> turtles = new List<Turtle>
            {
                new Turtle{ Coordinates= new Coordinates{ x = 1, y = 2  }, Orientation = 'N'},
                new Turtle{ Coordinates= new Coordinates{ x = 1, y = 2  }, Orientation = 'S'},
                new Turtle{ Coordinates= new Coordinates{ x = 1, y = 2  }, Orientation = 'E'},
                new Turtle{ Coordinates= new Coordinates{ x = 1, y = 2  }, Orientation = 'W'},
            };



            for (int i = 0; i < orientations.Count; i++)
            {
                // Act
                turtles[i].Move();

                // Assert
                Assert.AreEqual(orientations[i], turtles[i].Orientation);
                Assert.AreEqual(coordinates[i].x, turtles[i].Coordinates.x);
                Assert.AreEqual(coordinates[i].y, turtles[i].Coordinates.y);
            }
        }

        [TestMethod]
        public void TestRotate()
        {
            IPawn turtle = new Turtle();

            List<char> directions = new List<char> { 'R', 'L', 'L', 'L' };
            List<char> northOrientations = new List<char> { 'E', 'N', 'W', 'S' };
            List<char> southOrientations = new List<char> { 'W', 'S', 'E', 'N' };
            List<char> eastOrientations = new List<char> { 'S', 'E', 'N', 'W' };
            List<char> westOrientations = new List<char> { 'N', 'W', 'S', 'E' };
            List<char> fakeOrientations = new List<char> { 'B', 'S', ' ', '0' };

            List<Turtle> turtles = new List<Turtle>
            {
                new Turtle{ Coordinates= new Coordinates{ x = 1, y = 2  }, Orientation = 'N'},
                new Turtle{ Coordinates= new Coordinates{ x = 1, y = 2  }, Orientation = 'S'},
                new Turtle{ Coordinates= new Coordinates{ x = 1, y = 2  }, Orientation = 'E'},
                new Turtle{ Coordinates= new Coordinates{ x = 1, y = 2  }, Orientation = 'W'},
            };

            for (int i = 0; i < directions.Count; i++)
            {
                // Act
                turtles[0].Rotate(directions[i]);
                turtles[1].Rotate(directions[i]);
                turtles[2].Rotate(directions[i]);
                turtles[3].Rotate(directions[i]);

                // Assert
                Assert.AreEqual(northOrientations[i], turtles[0].Orientation);
                Assert.AreEqual(southOrientations[i], turtles[1].Orientation);
                Assert.AreEqual(eastOrientations[i], turtles[2].Orientation);
                Assert.AreEqual(westOrientations[i], turtles[3].Orientation);
                Assert.AreNotEqual(fakeOrientations[i], turtles[0].Orientation);
            }

        }
    }
}
