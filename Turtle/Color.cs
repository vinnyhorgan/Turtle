namespace Turtle
{
    public struct Color
    {
        public byte R;
        public byte G;
        public byte B;
        public byte A;

        internal Raylib_cs.Color ToRayColor()
        {
            return new Raylib_cs.Color(R, G, B, A);
        }

        public Color(byte r, byte g, byte b, byte a = 255)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}