namespace Turtle
{
    public class Color
    {
        private Raylib_cs.Color _rayColor;

        public Color(byte r, byte g, byte b, byte a = 255)
        {
            _rayColor.r = r;
            _rayColor.g = g;
            _rayColor.b = b;
            _rayColor.a = a;
        }

        internal Raylib_cs.Color GetRayColor()
        {
            return _rayColor;
        }
    }
}