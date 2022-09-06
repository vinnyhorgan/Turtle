using Raylib_cs;

using System.Numerics;

namespace Turtle
{
    public struct Color
    {
        public float R;
        public float G;
        public float B;
        public float A;

        internal Raylib_cs.Color ToRayColor()
        {
            return Raylib.ColorFromNormalized(new Vector4(R, G, B, A));
        }

        public Color(float r, float g, float b, float a = 1)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    }
}