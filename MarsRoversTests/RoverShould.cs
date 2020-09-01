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

            var plateau = new Plateau
            {
                XPlateau = 5,
                YPlateau = 5
            };

            var heading = "N";

            var rover = new Rover(startingPosition, heading);

            //Act
            rover.SetPlateau(plateau).Move(spinCommand);

            //Assert
            Assert.AreEqual(0, rover.CurrentPosition.RoverXPosition);
            Assert.AreEqual(0, rover.CurrentPosition.RoverYPosition);

            Assert.AreEqual(expectedHeading, rover.Heading);
        }

    //    [Test]
    //    public void SpinLeft_RoverShouldSpinLeft_ReturnsHeading()
    //    {
    //        //Arrange
    //        var startingPosition = new Position(0 ,0);

    //        Rover rover = new Rover(startingPosition).SetPlateau(plateau).Move("1 2 N");
            
    //        //Act
    //        rover.Move("L");

    //        //Assert
    //        Assert.AreEqual("1 2 W", rover.CurrentPosition);
    //    }

    //    [Test]
    //    public void SpinRight_RoverShouldSpinRight_ReturnsHeading()
    //    {
    //        //Arrange
    //        Rover rover = new Rover("1 2 N");
    //        //Act
    //        rover.SpinRight();
    //        //Assert
    //        Assert.AreEqual("E", rover.Heading);
    //    }

    //    [Test]
    //    [TestCase ("1 2 N", "LMLMLMLMM", "1 3 N")]
    //    [TestCase ("3 3 E","MMRMMRMRRM", "5 1 E")]
    //    public void Move(string roverStartPosition, string roverCommand, string expectedRoverEndPosition)
    //    {
    //        string x = "hello world";
    //        var z = x.Length(x);

    //        //Arrange
    //        Rover rover = new Rover(roverStartPosition);
    //        //Act
    //        rover.Move(roverCommand);
    //        //Assert
    //        Assert.AreEqual(expectedRoverEndPosition, rover.x + " " + rover.y + " " + rover.Heading);
    //    }


    //    public void Test1()
    //    {
    //        var landscape = new LandScape("5 5");
    //        var rover = new Rover(landscape);
    //        rover.SetPosition("1 2 N");
    //        rover.Move("");

    //        Assert.AreEqual("", rover.CurrentPosition);


    //        rover.Set("5 5 \n 1 2 N \ ");


    //    }
    //}

    //public class LandScape
    //{
    //    private int x;
    //    private int y;

    //    private List<int, int> UnAccessibleGridPositions = new   

    //    public LandScape("x y")
    //    {
        
    //    }
    }
}