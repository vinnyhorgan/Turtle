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
        private static Color _currentBackgroundColor = new Color(0, 0, 0);

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

        public static void Arc(DrawMode mode, int x, int y, float radius, float startAngle, float endAngle, int segments = 10)
        {
            switch (mode)
            {
                case DrawMode.Fill:
                    Raylib.DrawCircleSector(new Vector2(x, y), radius, startAngle, endAngle, segments, _currentColor.ToRayColor());
                    break;
                case DrawMode.Line:
                    Raylib.DrawCircleSectorLines(new Vector2(x, y), radius, startAngle, endAngle, segments, _currentColor.ToRayColor());
                    break;
            }
        }

        public static void Circle(DrawMode mode, int x, int y, float radius)
        {
            switch (mode)
            {
                case DrawMode.Fill:
                    Raylib.DrawCircle(x, y, radius, _currentColor.ToRayColor());
                    break;
                case DrawMode.Line:
                    Raylib.DrawCircleLines(x, y, radius, _currentColor.ToRayColor());
                    break;
            }
        }

        public static void Clear()
        {
            Raylib.ClearBackground(_currentBackgroundColor.ToRayColor());
        }

        public static void Clear(byte r, byte g, byte b, byte a)
        {
            Raylib.ClearBackground(new Color(r, g, b, a).ToRayColor());
        }

        public static void Clear(Color color)
        {
            Raylib.ClearBackground(color.ToRayColor());
        }

        public static void Ellipse(DrawMode mode, int x, int y, float radiusX, float radiusY)
        {
            switch (mode)
            {
                case DrawMode.Fill:
                    Raylib.DrawEllipse(x, y, radiusX, radiusY, _currentColor.ToRayColor());
                    break;
                case DrawMode.Line:
                    Raylib.DrawEllipseLines(x, y, radiusX, radiusY, _currentColor.ToRayColor());
                    break;
            }
        }

        public static void Line(params Vector2[] points)
        {
            Vector2 tempPoint = points[0];

            for (int i = 1; i < points.Length; i++)
            {
                Raylib.DrawLineV(tempPoint, points[i], _currentColor.ToRayColor());
                tempPoint = points[i];
            }
        }

        public static void Points(params Vector2[] points)
        {
            foreach (Vector2 point in points)
            {
                Raylib.DrawPixelV(point, _currentColor.ToRayColor());
            }
        }

        /// <summary>
        /// Draws text on screen.
        /// </summary>
        public static void Print(string text, int x, int y, float rotation = 0.0f, Vector2 offset = new Vector2())
        {
            Raylib.DrawTextPro(_currentFont.GetRayFont(), text, new Vector2(x, y), offset, rotation, _currentFont.GetRayFont().baseSize, 0.0f, _currentColor.ToRayColor());
        }

        /// <summary>
        /// Draws text on screen.
        /// </summary>
        public static void Print(string text, Vector2 position, float rotation = 0.0f, Vector2 offset = new Vector2())
        {
            if (_currentFont is not null)
            {
                Raylib.DrawTextPro(_currentFont.GetRayFont(), text, position, offset, rotation, _currentFont.GetRayFont().baseSize, 0.0f, _currentColor.ToRayColor());
            }
        }
    }
}