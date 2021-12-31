using Mars_Rover.Domain.Model;
using Mars_Rover.Enums;

namespace Mars_Rover.Infrastructure
{
    interface IVehicle
    {
        public int X { get; }

        public int Y { get; }

        public Direction Direction { get; }

        SurfaceSize Size { get; }

        void Move(Movement movement);
    }
}
