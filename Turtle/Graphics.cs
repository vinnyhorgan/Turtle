using Raylib_cs;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.IO;

namespace Turtle
{
    /// <summary>
    /// Graphics module.
    /// </summary>
    public static class Graphics
    {
        private static Font _currentFont = new Font(Raylib.GetFontDefault());
        private static Color _currentColor = new Color(255, 255, 255);
        private static Color _currentBackgroundColor = new Color(0, 0, 0);
        private static Canvas? _currentCanvas = null;
        private static FilterMode _currentFilter = FilterMode.Linear;
        private static float _lineWidth = 1.0f;
        private static int _pointSize = 1;

        private static List<Font> _loadedFonts = new List<Font>();
        private static List<Image> _loadedImages = new List<Image>();

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

        public static void Clear(byte r, byte g, byte b, byte a = 255)
        {
            Raylib.ClearBackground(new Color(r, g, b, a).ToRayColor());
        }

        public static void Clear(Color color)
        {
            Raylib.ClearBackground(color.ToRayColor());
        }

        public static void Draw(Image image, int x, int y, float rotation = 0.0f, float scale = 1.0f, Vector2 offset = new Vector2())
        {
            Raylib.DrawTextureTiled(
                image.GetRayImage(),
                new Rectangle(x, y, image.GetRayImage().width, image.GetRayImage().width),
                new Rectangle(x, y, image.GetRayImage().width, image.GetRayImage().width),
                offset,
                rotation,
                scale,
                _currentColor.ToRayColor()
            );
        }

        public static void Draw(Image image, Quad quad, int x, int y, float rotation = 0.0f, float scale = 1.0f, Vector2 offset = new Vector2())
        {
            Raylib.DrawTextureTiled(
                image.GetRayImage(),
                new Rectangle(x, y, image.GetRayImage().width, image.GetRayImage().width),
                quad.ToRayQuad(),
                offset,
                rotation,
                scale,
                _currentColor.ToRayColor()
            );
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
                Raylib.DrawLineEx(tempPoint, points[i], _lineWidth, _currentColor.ToRayColor());
                tempPoint = points[i];
            }
        }

        public static void Points(params Vector2[] points)
        {
            foreach (Vector2 point in points)
            {
                Raylib.DrawRectangleV(point, new Vector2(_pointSize, _pointSize), _currentColor.ToRayColor());
            }
        }

        public static void Polygon(DrawMode mode, int x, int y, int sides, float radius, float rotation = 0.0f)
        {
            switch (mode)
            {
                case DrawMode.Fill:
                    Raylib.DrawPoly(new Vector2(x, y), sides, radius, rotation, _currentColor.ToRayColor());
                    break;
                case DrawMode.Line:
                    Raylib.DrawPolyLinesEx(new Vector2(x, y), sides, radius, rotation, _lineWidth, _currentColor.ToRayColor());
                    break;
            }
        }

        public static void Rectangle(DrawMode mode, int x, int y, int width, int height)
        {
            switch (mode)
            {
                case DrawMode.Fill:
                    Raylib.DrawRectangle(x, y, width, height, _currentColor.ToRayColor());
                    break;
                case DrawMode.Line:
                    Raylib.DrawRectangleLinesEx(new Rectangle(x, y, width, height), _lineWidth, _currentColor.ToRayColor());
                    break;
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

        public static void CaptureScreenshot(string filename)
        {
            Raylib.TakeScreenshot(filename);
        }

        public static Canvas NewCanvas()
        {
            return new Canvas(Raylib.LoadRenderTexture(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()));
        }

        public static Canvas NewCanvas(int width, int height)
        {
            return new Canvas(Raylib.LoadRenderTexture(width, height));
        }

        public static Font NewFont(string filename, int size = 18)
        {
            return new Font(Raylib.LoadFontEx(filename, size, Array.Empty<int>(), 0));
        }

        public static Image NewImage(string filename)
        {
            return new Image(Raylib.LoadTexture(filename));
        }

        public static ParticleSystem NewParticleSystem(Image image, int buffer = 1000)
        {
            return new ParticleSystem(image, buffer);
        }

        public static Quad NewQuad(int x, int y, int width, int height)
        {
            return new Quad(x, y, width, height);
        }

        public static Font SetNewFont(string filename, int size = 18)
        {
            Font newFont = NewFont(filename);
            SetFont(newFont);

            return newFont;
        }

        public static Color GetBackgroundColor()
        {
            return _currentBackgroundColor;
        }

        public static Canvas? GetCanvas()
        {
            return _currentCanvas;
        }

        public static Color GetColor()
        {
            return _currentColor;
        }

        public static FilterMode GetDefaultFilter()
        {
            return _currentFilter;
        }

        public static Font GetFont()
        {
            return _currentFont;
        }

        public static float GetLineWidth()
        {
            return _lineWidth;
        }

        public static int GetPointSize()
        {
            return _pointSize;
        }

        public static bool IsActive()
        {
            return Raylib.IsWindowReady();
        }

        public static void SetBackgroundColor(Color color)
        {
            _currentBackgroundColor = color;
        }

        public static void SetBackgroundColor(byte r, byte g, byte b, byte a = 255)
        {
            _currentBackgroundColor = new Color(r, g, b, a);
        }

        public static void SetCanvas(Canvas canvas)
        {
            Raylib.BeginTextureMode(canvas.GetRayCanvas());
            _currentCanvas = canvas;
        }

        public static void SetCanvas()
        {
            Raylib.EndTextureMode();
            _currentCanvas = null;
        }

        public static void SetColor(Color color)
        {
            _currentColor = color;
        }

        public static void SetColor(byte r, byte g, byte b, byte a = 255)
        {
            _currentColor = new Color(r, g, b, a);
        }

        public static void SetDefaultFilter(FilterMode filter)
        {
            _currentFilter = filter;
        }

        public static void SetFont(Font font)
        {
            _currentFont = font;
        }

        public static void SetLineWidth(float width)
        {
            _lineWidth = width;
        }

        public static void SetPointSize(int size)
        {
            _pointSize = size;
        }

        public static Vector2 GetDPIScale()
        {
            return Raylib.GetWindowScaleDPI();
        }

        public static Vector2 GetDimensions()
        {
            return new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
        }

        public static int GetWidth()
        {
            return Raylib.GetScreenWidth();
        }

        public static int GetHeight()
        {
            return Raylib.GetScreenHeight();
        }
    }
}