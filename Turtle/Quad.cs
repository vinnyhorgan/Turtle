namespace Turtle
{
    public struct Quad
    {
        public int X;
        public int Y;
        public int Width;
        public int Height;

        internal Raylib_cs.Rectangle ToRayQuad()
        {
            return new Raylib_cs.Rectangle(X, Y, Width, Height);
        }

        public Quad(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
    }
}