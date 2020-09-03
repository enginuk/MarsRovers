using MarsRovers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MarsRoversTests
{
    public class RoverShould
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        [TestCase("L", "W" )]
        [TestCase("R", "E")]
        public void Rover_ShouldBeAbleTo_Spin_WithoutMove(string spinCommand, string expectedHeading)
        {
            //Arrange
            var startingPosition = new Position(0, 0);
            var heading = "N";
            var rover = new Rover(startingPosition, heading);

            var plateau = new Plateau
            {
                XPlateau = 5,
                YPlateau = 5
            };

            //Act
            rover.SetPlateau(plateau).Move(spinCommand);

            //Assert
            Assert.AreEqual(0, rover.CurrentPosition.RoverXPosition);
            Assert.AreEqual(0, rover.CurrentPosition.RoverYPosition);

            Assert.AreEqual(expectedHeading, rover.Heading);
        }

        [Test]
        [TestCase(1,2,"N", "LMLMLMLMM", "1 3 N")]
        [TestCase(3, 3, "E", "MMRMMRMRRM", "5 1 E")]
        public void SingleRover_ShouldBeAbleTo_SpinAndMove(int startPosX, int startPosY, string heading, string moveCommand, string expectedOutput)
        {
            //Arrange
            var startingPosition = new Position(startPosX,startPosY);
            var rover = new Rover(startingPosition, heading);

            List<Position> positions = new List<Position>();
            {
                positions.Add(new Position(5, 5));
            }

            var plateau = new Plateau
            {
                XPlateau = 5,
                YPlateau = 5,
                NonAccesiblePositions = positions
            };

            //Act
            rover.SetPlateau(plateau).Move(moveCommand);
            
            //Assert
            Assert.AreEqual(expectedOutput, rover.CurrentPosition.RoverXPosition + " " +
                                            rover.CurrentPosition.RoverYPosition + " " +
                                            rover.Heading);
        }

        [Test]
        [TestCase(1, 2, "N", "LMLMLMLMM", "1 2 N")]
        public void Rover_ShouldNotMoveIfOutsidePlateau(int startPosX, int startPosY, string heading, string moveCommand, string expectedOutput)
        {
            //Arrange
            var startingPosition = new Position(startPosX, startPosY);
            var rover = new Rover(startingPosition, heading);

            List<Position> positions = new List<Position>();
            {
                positions.Add(new Position(5, 5));
            }

            var plateau = new Plateau
            {
                XPlateau = 2,
                YPlateau = 2,
                NonAccesiblePositions = positions
            };

            //Act
            rover.SetPlateau(plateau).Move(moveCommand);

            //Assert
            Assert.AreEqual(expectedOutput, rover.CurrentPosition.RoverXPosition + " " +
                                            rover.CurrentPosition.RoverYPosition + " " +
                                            rover.Heading);
        }

        [Test]
        [TestCase(1, 2, "N", "LMLMLMLMM", "1 2 N")]
        public void Rover_ShouldNotMoveIfItCollidesWithAnotherRover(int startPosX, int startPosY, string heading, string moveCommand, string expectedOutput)
        {
            //Arrange
            var startingPosition = new Position(startPosX, startPosY);
            var rover = new Rover(startingPosition, heading);
            var input = "5 5\n1 2 N\nLMLMLMLMM\n1 2 N\nMMRMMRMRRM";
            var roverManager = new RoversManager();

            //Act

            roverManager.Execute(input);

            //Assert
            Assert.AreEqual(expectedOutput, rover.CurrentPosition.RoverXPosition + " " +
                                            rover.CurrentPosition.RoverYPosition + " " +
                                            rover.Heading);
        }
    }
}