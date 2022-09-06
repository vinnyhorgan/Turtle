using Raylib_cs;

namespace Turtle
{
    /// <summary>
    /// Defines the shape of characters that can be drawn onto the screen.
    /// </summary>
    public class Font
    {
        private Raylib_cs.Font _rayFont;
        private FilterMode _filter = FilterMode.Linear;

        internal Font(Raylib_cs.Font rayFont)
        {
            _rayFont = rayFont;
        }

        internal Raylib_cs.Font GetRayFont()
        {
            return _rayFont;
        }

        // Functions

        /// <summary>
        /// Gets the filter mode for a font.
        /// </summary>
        /// <returns>Filter mode used when scaling the font.</returns>
        public FilterMode GetFilter()
        {
            return _filter;
        }

        /// <summary>
        /// Gets the height of the Font in pixels.
        /// </summary>
        /// <returns>The height of the Font in pixels.</returns>
        public int GetHeight()
        {
            return _rayFont.baseSize;
        }

        /// <summary>
        /// Determines the width of the given text.
        /// </summary>
        /// <param name="text">A string.</param>
        /// <returns>The width of the text.</returns>
        public float GetWidth(string text)
        {
            return Raylib.MeasureTextEx(_rayFont, text, _rayFont.baseSize, 0).X;
        }

        /// <summary>
        /// Sets the filter mode for a font.
        /// </summary>
        /// <param name="mode">How to scale a font.</param>
        public void SetFilter(FilterMode mode)
        {
            switch (mode)
            {
                case FilterMode.Linear:
                    Raylib.SetTextureFilter(_rayFont.texture, TextureFilter.TEXTURE_FILTER_BILINEAR);
                    break;
                case FilterMode.Nearest:
                    Raylib.SetTextureFilter(_rayFont.texture, TextureFilter.TEXTURE_FILTER_POINT);
                    break;
            }

            _filter = mode;
        }

        /// <summary>
        /// Immediately destroys the object's reference.
        /// </summary>
        public void Release()
        {
            Raylib.UnloadFont(_rayFont);

            Graphics.GetLoadedFonts().Remove(this);
        }
    }
}