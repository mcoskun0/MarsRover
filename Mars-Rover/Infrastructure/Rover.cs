using Mars_Rover.Domain.Model;
using Mars_Rover.Enums;
using System;

namespace Mars_Rover.Infrastructure
{
    public class Rover : IVehicle
    {
        public int X { get; private set; }

        public int Y { get; private set; }

        public Direction Direction { get; private set; }

        public SurfaceSize Size { get; private set; }

        public Rover(SurfaceSize size, int x = 0, int y = 0, Direction direction = Direction.N)
        {
            Size = size;
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }

        public void Move(Movement movement)
        {
            switch (movement)
            {
                case Movement.L:
                    TurnLeft();
                    break;
                case Movement.R:
                    TurnRight();
                    break;
                case Movement.M:
                    MoveForward();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(movement), movement, null);
            }

            if (X < 0 || X > Size.Width || Y < 0 || Y > Size.Height)
                throw new Exception($"(0 , 0) veya ({Size.Width} , {Size.Height}) olamaz, max point kontrol edin...");
        }

        public override string ToString()
        {
            return $"{X} {Y} {Direction:G}";
        }

        #region Private

        private void MoveForward()
        {
            switch (Direction)
            {
                case Direction.N:
                    Y += 1;
                    break;
                case Direction.E:
                    X += 1;
                    break;
                case Direction.S:
                    Y -= 1;
                    break;
                case Direction.W:
                    X -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.W;
                    break;

                case Direction.W:
                    Direction = Direction.S;
                    break;

                case Direction.S:
                    Direction = Direction.E;
                    break;

                case Direction.E:
                    Direction = Direction.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TurnRight()
        {
            switch (Direction)
            {
                case Direction.N:
                    Direction = Direction.E;
                    break;

                case Direction.E:
                    Direction = Direction.S;
                    break;

                case Direction.S:
                    Direction = Direction.W;
                    break;

                case Direction.W:
                    Direction = Direction.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        #endregion

    }
}
