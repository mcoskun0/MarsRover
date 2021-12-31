using Mars_Rover.Infrastructure;
using Mars_Rover.Domain.Model;
using Mars_Rover.Enums;
using System;

namespace Mars_Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Plateau surface size :");
            PlateauSurface _plateauSurface = new PlateauSurface(Console.ReadLine());

            while (true)
            {
                Console.Write("\nPosition\t:");
                RoverPosition _roverPosition = new RoverPosition(Console.ReadLine());

                Console.Write("Command\t\t:");
                var roverCommandInput = Console.ReadLine().ToUpper();

                Rover _rover = new Rover(_plateauSurface.surfaceSize, _roverPosition.X, _roverPosition.Y, _roverPosition.Direction);
                foreach (var order in roverCommandInput)
                {
                    var movement = Enum.Parse<Movement>(order.ToString());
                    _rover.Move(movement);
                }
                Console.Write("Result \t\t:*"+ _rover.ToString() + "*");

                Console.WriteLine("\n\nDo you want to add another rover ? (Y/N)");
                var addRoverInput = Console.ReadLine();

                if (!addRoverInput.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                    break;

            }

        }


    }
}
