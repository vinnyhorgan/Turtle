using Raylib_cs;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.IO;

namespace Turtle
{
    public static class Graphics
    {
        private static Font _currentFont = new Font(Raylib.GetFontDefault());
        private static Color _currentColor = new Color(255, 255, 255);

        private static List<Font> _loadedFonts = new List<Font>();
        private static List<Image> _loadedImages = new List<Image>();

        internal static void Init()
        {
            string defaultFontPath = "assets/Vera.ttf";

            if (File.Exists(defaultFontPath))
            {
                Raylib_cs.Font veraFont = Raylib.LoadFontEx(defaultFontPath, 18, Array.Empty<int>(), 0);
                _currentFont = new Font(veraFont);
            }
            else
            {
                Game.SetError("Unable to load default font.");
            }
        }

        internal static void Close()
        {
            foreach (Font font in _loadedFonts)
            {
                Raylib.UnloadFont(font.GetRayFont());
            }

            foreach (Image image in _loadedImages)
            {
                Raylib.UnloadTexture(image.GetRayImage());
            }
        }

        internal static List<Font> GetLoadedFonts()
        {
            return _loadedFonts;
        }

        /// <summary>
        /// Draws text on screen.
        /// </summary>
        public static void Print(string text, int x, int y, float rotation = 0.0f, Vector2 offset = new Vector2())
        {
            Raylib.DrawTextPro(_currentFont.GetRayFont(), text, new Vector2(x, y), offset, rotation, _currentFont.GetRayFont().baseSize, 0.0f, _currentColor.GetRayColor());
        }

        /// <summary>
        /// Draws text on screen.
        /// </summary>
        public static void Print(string text, Vector2 position, float rotation = 0.0f, Vector2 offset = new Vector2())
        {
            if (_currentFont is not null)
            {
                Raylib.DrawTextPro(_currentFont.GetRayFont(), text, position, offset, rotation, _currentFont.GetRayFont().baseSize, 0.0f, _currentColor.GetRayColor());
            }
        }
    }
}