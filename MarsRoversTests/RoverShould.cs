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
        public void Move()
        {
            //Arrange
            Rover rover = new Rover("1 2 N");
            //Act
            rover.Move(rover,
                       "LMLMLMLMM");
            //Assert
            Assert.AreEqual("1 3 N", rover.x + " " + rover.y + " " + rover.heading);
        }
    }
}