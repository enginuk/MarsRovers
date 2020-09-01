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

            // ToDo: Return Output string
            return string.Empty;
        }


        // Validate

        private bool Validate(string nasaCommand)
        {
            int numLines = nasaCommand.Split('\n').Length;

            if (numLines % 2 == 1)
            {
                _numberOfRovers = (numLines - 1) / 2;
                return true;
            }

            return false;
        }

        // Parse

        public void ParseNasaCommand(string nasaCommand)
        {
            var lines = File.ReadAllLines(nasaCommand);
            int counter = 0;

            foreach (var line in lines)
            {
                if (counter == 0)
                {
                    Int32.TryParse(line.Split(" ")[0], out xplateau);
                    Int32.TryParse(line.Split(" ")[1], out yplateau);
                    counter++;
                }

                var roverPosAndCommand = new RoverPosAndCommand();

                if (counter % 2 == 1)
                {
                    Int32.TryParse(line.Split(" ")[0], out roverXPosition);
                    roverPosAndCommand.X = roverXPosition;
                    Int32.TryParse(line.Split(" ")[1], out roverYPosition);
                    roverPosAndCommand.Y = roverYPosition;
                    var heading = line.Split(" ")[2];
                    counter++;
                    var position = new Position(roverXPosition, roverYPosition);


                    roversOnMars.Add(item: new Rover(position, heading));
                }

                if (counter % 2 == 0)
                {
                    roverPosAndCommand.NasaCommand = line;
                    roverCommand.Add(line);
                    counter++;

                }
            }
        }

        // Initiliaze LAndscape

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

