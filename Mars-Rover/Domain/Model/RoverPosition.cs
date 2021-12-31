using Mars_Rover.Enums;
using System.Linq;
using System;

namespace Mars_Rover.Domain.Model
{
    public class RoverPosition
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Direction Direction { get; private set; }

        public RoverPosition(string position)
        {
            var p = position.Trim().Split(' ');

            if (p.Count() != 3)
                throw new Exception("Starting position 3 value can be entered or enter with spaces");

            if (!int.TryParse(p[0], out int x))
                throw new Exception("First Character int value can be entered...");

            if (!int.TryParse(p[1], out int y))
                throw new Exception("Second Character int value can be entered...");

            if (!Enum.IsDefined(typeof(Direction), p[2].ToUpper()))
                throw new Exception("Third Character enter correctly...");

            this.X = x;
            this.Y = y;
            this.Direction = (Direction)Enum.Parse(typeof(Direction), p[2].ToUpper());
        }
    }
}
