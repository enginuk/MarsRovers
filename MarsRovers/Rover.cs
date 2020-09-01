using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarsRovers
{
    public class Rover
    {
        private Plateau _plateau;

        public Rover(Position position, string heading)
        {
            CurrentPosition = position;
            Heading = heading;
        }

        public Position CurrentPosition { get; set; } 

        public Rover SetPlateau(Plateau plateau)
        {
            _plateau = plateau;
            
            return this;
        }

        public string Heading { get; set; }

        private void SpinLeft()
        {
            switch (Heading)
            {
                case "N":
                    Heading = "W";
                    break;
                case "E":
                    Heading = "N";
                    break;
                case "S":
                    Heading = "E";
                    break;
                case "W":
                    Heading = "S";
                    break;
                default:
                    break;
            }
        }

        private void SpinRight()
        {
            switch (Heading)
            {
                case "N":
                    Heading = "E";
                    break;
                case "E":
                    Heading = "S";
                    break;
                case "S":
                    Heading = "W";
                    break;
                case "W":
                    Heading = "N";
                    break;
                default:
                    break;
            }
        }

        public void Move(string roverCommand)
        {
            if (_plateau == null)
            {
                throw new Exception("Plateau must be defined");
            }

            char[] command = roverCommand.ToCharArray();

            for (int i = 0; i < command.Length; i++)
            {
                switch (command[i])
                {
                    case 'L':
                        SpinLeft();
                        break;
                    case 'R':
                        SpinRight();
                        break;
                    case 'M':
                        var projectedX = CurrentPosition.RoverXPosition;
                        var projectedY = CurrentPosition.RoverYPosition;
                        
                        if (Heading == "N") 
                            projectedY += 1;

                        if (Heading == "E")
                            projectedX += 1;

                        if (Heading == "S")
                            projectedY -= 1;

                        if (Heading == "W")
                            projectedX -= 1;

                        var projectedPosition = new Position(projectedX, projectedY);

                        if (ValidateProjectedPosition(projectedPosition))
                            CurrentPosition = projectedPosition;

                        break;
                    default:
                        break;
                }
            }
        }

        private bool ValidateProjectedPosition(Position projectedPosition)
        {
            return true;
        }
    }
}
