using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers
{
    public class Plateau
    {
        public int XPlateau { get; set; }
        public int YPlateau { get; set; }

        public IEnumerable<Position> NonAccesiblePositions { get; set; }
    }
}
