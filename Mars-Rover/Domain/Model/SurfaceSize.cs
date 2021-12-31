namespace Mars_Rover.Domain.Model
{
    public class SurfaceSize
    {
        public int Width { get; }
        public int Height { get; }

        public SurfaceSize(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
