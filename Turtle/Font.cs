using Raylib_cs;

namespace Turtle
{
    public class Font
    {
        private Raylib_cs.Font _rayFont;

        internal Font(Raylib_cs.Font rayFont)
        {
            _rayFont = rayFont;
        }

        internal Raylib_cs.Font GetRayFont()
        {
            return _rayFont;
        }

        /// <summary>
        /// Unloads the font.
        /// </summary>
        public void Release()
        {
            Raylib.UnloadFont(_rayFont);

            Graphics.GetLoadedFonts().Remove(this);
        }
    }
}