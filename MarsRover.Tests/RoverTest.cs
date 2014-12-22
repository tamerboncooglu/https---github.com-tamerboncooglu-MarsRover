using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Tests
{
    [TestClass]
    public class RoverTest
    {
        private Grid _grid;

        [TestInitialize]
        public void Init()
        {
            _grid = new Grid
                {
                    PointX = 5,
                    PointY = 5
                };
        }

        [TestMethod]
        public void RoverCreatedAndFace2North()
        {
            var rover = new Rover();
            Assert.AreEqual(rover.GetCamFace(), "N");
        }

        [TestMethod]
        public void RoverDegree90Test()
        {
            var rover = new Rover();
            rover.TurnLeft();

            Assert.AreEqual(rover.Degree, 270);
        }

        [TestMethod]
        public void RoverDegree180Test()
        {
            var rover = new Rover();
            rover.TurnLeft();
            rover.TurnLeft();

            Assert.AreEqual(rover.Degree, 180);
        }

        [TestMethod]
        public void RoverDegree270Test()
        {
            var rover = new Rover();
            rover.TurnLeft();
            rover.TurnLeft();
            rover.TurnLeft();

            Assert.AreEqual(rover.Degree, 90);
        }

        [TestMethod]
        public void RoverDegree360Test()
        {
            var rover = new Rover();
            rover.TurnLeft();
            rover.TurnLeft();
            rover.TurnLeft();
            rover.TurnLeft();

            Assert.AreEqual(rover.Degree, 0);
        }

        [TestMethod]
        public void RoverDegreeComplexTest()
        {
            var rover = new Rover();
            rover.TurnLeft();
            rover.TurnLeft();
            rover.TurnLeft();
            rover.TurnRight();

            Assert.AreEqual(rover.Degree, 180);
        }

        [TestMethod]
        public void RoverFaceWestTest()
        {
            var rover = new Rover();
            rover.TurnLeft();
            Assert.AreEqual(rover.GetCamFace(), "W");
        }

        [TestMethod]
        public void RoverFaceSouthTest()
        {
            var rover = new Rover();
            rover.TurnLeft();
            rover.TurnLeft();
            Assert.AreEqual(rover.GetCamFace(), "S");
        }

        [TestMethod]
        public void RoverMoveOneStepTest()
        {
            var rover = new Rover { Grid = _grid };
            rover.Move();
            Assert.AreEqual(rover.PositionY, 1);
            Assert.AreEqual(rover.PositionX, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(RoverNavigationException), Messages.NavigationErrorMessage)]
        public void RoverMoveEastExceptionTest()
        {
            var rover = new Rover { Grid = _grid };
            rover.TurnLeft();
            rover.Move();
        }

        [TestMethod]
        [ExpectedException(typeof(RoverNavigationException), Messages.NavigationErrorMessage)]
        public void RoverMoveSouthExceptionTest()
        {
            var rover = new Rover { Grid = _grid };
            rover.TurnLeft();
            rover.TurnLeft();
            rover.Move();
            rover.Move();
        }

        [TestMethod]
        public void RoverMoveOneStepTurnRightTest()
        {
            var rover = new Rover { Grid = _grid };
            rover.TurnRight();
            rover.Move();
            Assert.AreEqual(rover.PositionY, 0);
            Assert.AreEqual(rover.PositionX, 1);
        }

        [TestMethod]
        public void RoverMoveComplexTestRover1()
        {
            var rover = new Rover
            {
                Grid = _grid,
                PositionX = 1,
                PositionY = 2
            };

            rover.SetStartDirection("N");
            rover.TurnLeft();
            rover.Move();
            rover.TurnLeft();
            rover.Move();
            rover.TurnLeft();
            rover.Move();
            rover.TurnLeft();
            rover.Move();
            rover.Move();

            Assert.AreEqual(rover.PositionX, 1);
            Assert.AreEqual(rover.PositionY, 3);
            Assert.AreEqual(rover.GetCamFace(), "N");
        }

        [TestMethod]
        public void RoverMoveComplexTestRover2()
        {
            var rover = new Rover
            {
                Grid = _grid,
                PositionX = 3,
                PositionY = 3
            };

            rover.SetStartDirection("E");
            rover.Move();
            rover.Move();
            rover.TurnRight();
            rover.Move();
            rover.Move();
            rover.TurnRight();
            rover.Move();
            rover.TurnRight();
            rover.TurnRight();
            rover.Move();

            Assert.AreEqual(rover.PositionX, 5);
            Assert.AreEqual(rover.PositionY, 1);
            Assert.AreEqual(rover.GetCamFace(), "E");
        }
    }
}
