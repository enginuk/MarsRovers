using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

namespace MarsRovers
{
    public class RoversManager
    {
        private List<Rover> roversOnMars = new List<Rover>();
        private List<string> roverCommand = new List<string>();

        private int xplateau;
        private int yplateau;

        private int roverXPosition;
        private int roverYPosition;

        public string Execute(string input)
        {
            var isNasaCommandLengthValid = Validate(input);
            var totalRovers = 0;
            if (!isNasaCommandLengthValid)
            {
                return ("Please enter correct number of lines");
            }

            ParseNasaCommand(input);

            for (var x = 0; x < roversOnMars.Count; x++)
            {
                var otherRovers = roversOnMars.Except(new List<Rover> {roversOnMars[x]});

                var inaccessiblePositions = otherRovers.Select(r => r.CurrentPosition);
                
                var plateau = InitialisePlateau(inaccessiblePositions);

                roversOnMars[x].SetPlateau(plateau).Move(roverCommand[x]);
            }

            List<string> roversSucessfulMove = new List<string>();

            foreach (var rover in roversOnMars)
            {
                if (rover.HasMovedSuccessfully)
                {
                    roversSucessfulMove.Add (rover.CurrentPosition.RoverXPosition +" "
                                                                                  +rover.CurrentPosition.RoverYPosition +" "
                                                                                  + rover.Heading);
                    roversSucessfulMove.Add("\n");
                    totalRovers++;
                    if (totalRovers == roversOnMars.Count)
                        return string.Join("", roversSucessfulMove);
                }
                else
                {
                    return ("Collision or out of Plateau detected. Vehicle unable to move.");
                }
            }

            return string.Empty;
        }


        // Validate

        private bool Validate(string nasaCommand)
        {
            int numLines = nasaCommand.Split('\n').Length;

            if (numLines % 2 == 1)
            {
                return true;
            }

            return false;
        }

        // Parse

        public void ParseNasaCommand(string nasaCommand)
        {
            var lines = nasaCommand.Split(new[] {'\n'});
            int counter = 0;

            foreach (var line in lines)
            {
                bool restartLoopFlag = false;
                if (counter == 0)
                {
                    Int32.TryParse(line.Split(" ")[0], out xplateau);
                    Int32.TryParse(line.Split(" ")[1], out yplateau);
                    counter++;
                    restartLoopFlag = true;
                }

                var roverPosAndCommand = new RoverPosAndCommand();

                if (counter % 2 == 1 && restartLoopFlag == false)
                {
                    Int32.TryParse(line.Split(" ")[0], out roverXPosition);
                    roverPosAndCommand.X = roverXPosition;
                    Int32.TryParse(line.Split(" ")[1], out roverYPosition);
                    roverPosAndCommand.Y = roverYPosition;
                    var heading = line.Split(" ")[2];
                    var position = new Position(roverXPosition, roverYPosition);

                    roversOnMars.Add(item: new Rover(position, heading));
                    counter++;
                    restartLoopFlag = true;
                }

                if (counter % 2 == 0 && restartLoopFlag == false)
                {
                    roverPosAndCommand.NasaCommand = line;
                    roverCommand.Add(line);
                    counter++;
                    restartLoopFlag = true;
                }


            }
        }

        // Initiliaze Landscape

        public Plateau InitialisePlateau(IEnumerable<Position> positions)
        {
            return new Plateau
            {
                XPlateau = xplateau,
                YPlateau = yplateau,
                NonAccesiblePositions = positions
            };
        }
    }
}

