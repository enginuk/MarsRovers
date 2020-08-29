using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers
{
    public class Rover
    {
        private int _x;
        public int x
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        private int _y;
        public int y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        public string heading { get; set; }

        private int xPosition;
        private int yPosition;

        public Rover(string roverPosition)
        {
            Int32.TryParse(roverPosition.Split(" ")[0], out xPosition);
            _x = xPosition;
            Int32.TryParse(roverPosition.Split(" ")[1], out yPosition);
            _y = yPosition;
            heading = roverPosition.Split(" ")[2];
        }

        public void SpinLeft(Rover rover)
        {
            switch (rover.heading)
            {
                case "N":
                    rover.heading = "W";
                    break;
                case "E":
                    rover.heading = "N";
                    break;
                case "S":
                    rover.heading = "E";
                    break;
                case "W":
                    rover.heading = "S";
                    break;
                default:
                    break;
            }
        }

        public void SpinRight(Rover rover)
        {
            switch (rover.heading)
            {
                case "N":
                    rover.heading = "E";
                    break;
                case "E":
                    rover.heading = "S";
                    break;
                case "S":
                    rover.heading = "W";
                    break;
                case "W":
                    rover.heading = "N";
                    break;
                default:
                    break;
            }
        }

        public void Move(Rover rover, string roverCommand)
        {
            char[] command = roverCommand.ToCharArray();

            for (int i = 0; i < command.Length; i++)
            {
                switch (command[i])
                {
                    case 'L':
                        rover.SpinLeft(rover);
                        break;
                    case 'R':
                        rover.SpinRight(rover);
                        break;
                    case 'M':
                        if (rover.heading == "N")
                            y += 1;
                        if (rover.heading == "E")
                            x += 1;
                        if (rover.heading == "S")
                            y -= 1;
                        if (rover.heading == "W")
                            x -= 1;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
