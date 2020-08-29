using MarsRovers;
using NUnit.Framework;

namespace MarsRoversTests
{
    public class RoverShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SpinLeft_RoverShouldSpinLeft_ReturnsHeading()
        {
            //Arrange
            Rover rover = new Rover("1 2 N");
            //Act
            rover.SpinLeft(rover);
            //Assert
            Assert.AreEqual("W", rover.heading);
        }

        [Test]
        public void SpinRight_RoverShouldSpinRight_ReturnsHeading()
        {
            //Arrange
            Rover rover = new Rover("1 2 N");
            //Act
            rover.SpinRight(rover);
            //Assert
            Assert.AreEqual("E", rover.heading);
        }

        [Test]
        [TestCase ("1 2 N", "LMLMLMLMM", "1 3 N")]
        [TestCase ("3 3 E","MMRMMRMRRM", "5 1 E")]
        public void Move(string roverStartPosition, string roverCommand, string expectedRoverEndPosition)
        {
            //Arrange
            Rover rover = new Rover(roverStartPosition);
            //Act
            rover.Move(rover,
                       roverCommand);
            //Assert
            Assert.AreEqual(expectedRoverEndPosition, rover.x + " " + rover.y + " " + rover.heading);
        }
    }
}