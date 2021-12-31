using System.Linq;
using System;

namespace Mars_Rover.Domain.Model
{
    public class PlateauSurface
    {
        public SurfaceSize surfaceSize { get; private set; }
        public string SizeInput { get; private set; }
        public PlateauSurface(string sizeInput)
        {
            var maxPoints = sizeInput.Trim().Split(' ').Select(s =>
            {
                int i;
                return int.TryParse(s, out i) ? i : (int?)null;
            }).ToList();

            if (maxPoints.Count() != 2)
                throw new Exception("Surface size 2 value can be entered or enter with spaces");

            if (maxPoints.Where(x => !x.HasValue).Count() > 0)
                throw new Exception("only int value enterable...");

            SizeInput = sizeInput;

            var splitCommand = sizeInput.Split(' ');
            surfaceSize = new SurfaceSize(int.Parse(splitCommand[0]), int.Parse(splitCommand[1]));
        }
    }
}
