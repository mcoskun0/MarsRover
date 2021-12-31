using Mars_Rover.Domain.Model;
using Mars_Rover.Enums;
using Mars_Rover.Infrastructure;
using System;
using Xunit;

namespace MarsRover.Test
{
    public class RoverTests
    {
        [Theory]
        [InlineData(new object[] { "5 5", "1 2 N", "LMLMLMLMM", "1 3 N"})] // Success
        [InlineData(new object[] { "5 5", "3 3 E", "MMRMMRMRRM", "5 1 E"})] // Success
        [InlineData(new object[] { "5 5", "3 3 E", "MMRMMRMRRM", "X X X" })] //Exception
        public void GeneratePlataue(string plateauSurfaceSize, string roverPosition, string roverCommand, string result)
        {
            PlateauSurface _plateauSurface = new PlateauSurface(plateauSurfaceSize);
            RoverPosition _roverPosition = new RoverPosition(roverPosition);

            Rover _rover = new Rover(_plateauSurface.surfaceSize, _roverPosition.X, _roverPosition.Y, _roverPosition.Direction);
            foreach (var order in roverCommand.ToUpper())
            {
                var movement = Enum.Parse<Movement>(order.ToString());
                _rover.Move(movement);
            }

            var rArray = result.Split(' ');

            Assert.NotNull(_rover);
            Assert.Equal(int.Parse(rArray[0]), _rover.X);
            Assert.Equal(int.Parse(rArray[1]), _rover.Y);
            Assert.Equal((Direction)Enum.Parse(typeof(Direction), rArray[2].ToUpper()), _rover.Direction);
        }

    }
}
