using Raylib_cs;

using System;
using System.Numerics;
using System.Collections.Generic;
using System.IO;

namespace Turtle
{
    /// <summary>
    /// Is responsible of drawing lines, shapes, text and Images onto the screen.
    /// </summary>
    public static class Graphics
    {
        private static Font _currentFont = new Font(Raylib.GetFontDefault());
        private static Color _currentColor = new Color(1, 1, 1);
        private static Color _currentBackgroundColor = new Color(0, 0, 0);
        private static Canvas? _currentCanvas = null;
        private static FilterMode _currentFilter = FilterMode.Linear;
        private static float _lineWidth = 1.0f;
        private static int _pointSize = 1;

        private static List<Font> _loadedFonts = new List<Font>();
        private static List<Image> _loadedImages = new List<Image>();

        internal static List<Font> GetLoadedFonts()
        {
            return _loadedFonts;
        }

        internal static List<Image> GetLoadedImages()
        {
            return _loadedImages;
        }

        // Functions

        /// <summary>
        /// Draws an arc.
        /// </summary>
        /// <param name="mode">How to draw the arc.</param>
        /// <param name="x">The position of the center along x-axis.</param>
        /// <param name="y">The position of the center along y-axis.</param>
        /// <param name="radius">Radius of the arc.</param>
        /// <param name="startAngle">The angle at which the arc begins.</param>
        /// <param name="endAngle">The angle at which the arc terminates.</param>
        /// <param name="segments">The number of segments used for drawing the arc.</param>
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

        /// <summary>
        /// Draws a circle.
        /// </summary>
        /// <param name="mode">How to draw the circle.</param>
        /// <param name="x">The position of the center along x-axis.</param>
        /// <param name="y">The position of the center along y-axis.</param>
        /// <param name="radius">The radius of the circle.</param>
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

        /// <summary>
        /// Clears the screen or active Canvas to the specified color.
        /// </summary>
        public static void Clear()
        {
            Raylib.ClearBackground(_currentBackgroundColor.ToRayColor());
        }

        /// <summary>
        /// Clears the screen or active Canvas to the specified color.
        /// </summary>
        public static void Clear(float r, float g, float b, float a = 1)
        {
            Raylib.ClearBackground(new Color(r, g, b, a).ToRayColor());
        }

        /// <summary>
        /// Clears the screen or active Canvas to the specified color.
        /// </summary>
        public static void Clear(Color color)
        {
            Raylib.ClearBackground(color.ToRayColor());
        }

        /// <summary>
        /// Draws objects on screen.
        /// </summary>
        /// <param name="image">A drawable Image.</param>
        /// <param name="x">The position to draw the object (x-axis).</param>
        /// <param name="y">The position to draw the object (y-axis).</param>
        /// <param name="rotation">Orientation (radians).</param>
        /// <param name="scale">Scale factor.</param>
        /// <param name="offset">Origin offset.</param>
        public static void Draw(Image image, int x, int y, float rotation = 0.0f, float scale = 1.0f, Vector2 offset = new Vector2())
        {
            Raylib.DrawTextureEx(
                image.GetRayImage(),
                new Vector2(x, y),
                rotation * (180 / System.MathF.PI),
                scale,
                _currentColor.ToRayColor()
            );
        }

        /// <summary>
        /// Draws portions of objects on screen.
        /// </summary>
        /// <param name="image">A drawable Image.</param>
        /// <param name="quad">Quad definining the portion of Image to draw.</param>
        /// <param name="x">The position to draw the object (x-axis).</param>
        /// <param name="y">The position to draw the object (y-axis).</param>
        /// <param name="rotation">Orientation (radians).</param>
        /// <param name="scale">Scale factor.</param>
        /// <param name="offset">Origin offset.</param>
        public static void Draw(Image image, Quad quad, int x, int y, float rotation = 0.0f, float scale = 1.0f, Vector2 offset = new Vector2())
        {
            Raylib.DrawTextureTiled(
                image.GetRayImage(),
                new Rectangle(x, y, image.GetRayImage().width, image.GetRayImage().width),
                quad.ToRayQuad(),
                offset,
                rotation * (180 / System.MathF.PI),
                scale,
                _currentColor.ToRayColor()
            );
        }

        /// <summary>
        /// Draws an ellipse.
        /// </summary>
        /// <param name="mode">How to draw the ellipse.</param>
        /// <param name="x">The position of the center along x-axis.</param>
        /// <param name="y">The position of the center along y-axis.</param>
        /// <param name="radiusX">The radius of the ellipse along the x-axis (half the ellipse's width).</param>
        /// <param name="radiusY">The radius of the ellipse along the y-axis (half the ellipse's height).</param>
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

        /// <summary>
        /// Draws lines between points.
        /// </summary>
        /// <param name="points">An array of point positions.</param>
        public static void Line(params Vector2[] points)
        {
            Vector2 tempPoint = points[0];

            for (int i = 1; i < points.Length; i++)
            {
                Raylib.DrawLineEx(tempPoint, points[i], _lineWidth, _currentColor.ToRayColor());
                tempPoint = points[i];
            }
        }

        /// <summary>
        /// Draws one or more points.
        /// </summary>
        /// <param name="points">An array of point positions.</param>
        public static void Points(params Vector2[] points)
        {
            foreach (Vector2 point in points)
            {
                Raylib.DrawRectangleV(point, new Vector2(_pointSize, _pointSize), _currentColor.ToRayColor());
            }
        }

        /// <summary>
        /// Draw a polygon.
        /// </summary>
        /// <param name="mode">How to draw the polygon.</param>
        /// <param name="x">The position of the center along x-axis.</param>
        /// <param name="y">The position of the center along y-axis.</param>
        /// <param name="sides">The number of sides the polygon has.</param>
        /// <param name="radius">The radius of the polygon.</param>
        /// <param name="rotation">Orientation (radians).</param>
        public static void Polygon(DrawMode mode, int x, int y, int sides, float radius, float rotation = 0.0f)
        {
            switch (mode)
            {
                case DrawMode.Fill:
                    Raylib.DrawPoly(new Vector2(x, y), sides, radius, rotation * (180 / System.MathF.PI), _currentColor.ToRayColor());
                    break;
                case DrawMode.Line:
                    Raylib.DrawPolyLinesEx(new Vector2(x, y), sides, radius, rotation * (180 / System.MathF.PI), _lineWidth, _currentColor.ToRayColor());
                    break;
            }
        }

        /// <summary>
        /// Draws text on screen.
        /// </summary>
        /// <param name="text">The text to draw.</param>
        /// <param name="x">The position to draw the object (x-axis).</param>
        /// <param name="y">The position to draw the object (y-axis).</param>
        /// <param name="rotation">Orientation (radians).</param>
        /// <param name="offset">Origin offset.</param>
        public static void Print(string text, int x = 0, int y = 0, float rotation = 0.0f, Vector2 offset = new Vector2())
        {
            Raylib.DrawTextPro(_currentFont.GetRayFont(), text, new Vector2(x, y), offset, rotation * (180 / System.MathF.PI), _currentFont.GetRayFont().baseSize, 0.0f, _currentColor.ToRayColor());
        }

        /// <summary>
        /// Draws text on screen.
        /// </summary>
        /// <param name="text">The text to draw.</param>
        /// <param name="position">The position to draw the object.</param>
        /// <param name="rotation">Orientation (radians).</param>
        /// <param name="offset">Origin offset.</param>
        public static void Print(string text, Vector2 position, float rotation = 0.0f, Vector2 offset = new Vector2())
        {
            if (_currentFont is not null)
            {
                Raylib.DrawTextPro(_currentFont.GetRayFont(), text, position, offset, rotation * (180 / System.MathF.PI), _currentFont.GetRayFont().baseSize, 0.0f, _currentColor.ToRayColor());
            }
        }

        /// <summary>
        /// Draws a rectangle.
        /// </summary>
        /// <param name="mode">How to draw the rectangle.</param>
        /// <param name="x">The position of top-left corner along the x-axis.</param>
        /// <param name="y">The position of top-left corner along the y-axis.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
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
        /// Creates a screenshot once the current frame is done.
        /// </summary>
        /// <param name="filename">The filename to save the screenshot to.</param>
        public static void CaptureScreenshot(string filename)
        {
            Raylib.TakeScreenshot(filename);
        }

        /// <summary>
        /// Creates a new Canvas.
        /// </summary>
        /// <returns>A new Canvas with dimensions equal to the window's size in pixels.</returns>
        public static Canvas NewCanvas()
        {
            return new Canvas(Raylib.LoadRenderTexture(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()));
        }

        /// <summary>
        /// Creates a new Canvas.
        /// </summary>
        /// <param name="width">The desired width of the Canvas.</param>
        /// <param name="height">The desired height of the Canvas.</param>
        /// <returns>A new Canvas with specified width and height.</returns>
        public static Canvas NewCanvas(int width, int height)
        {
            return new Canvas(Raylib.LoadRenderTexture(width, height));
        }

        /// <summary>
        /// Creates a new Font from a TrueType Font or BMFont file.
        /// </summary>
        /// <param name="filename">The filepath to the BMFont or TrueType font file.</param>
        /// <param name="size"></param>
        /// <returns>A Font object which can be used to draw text on screen.</returns>
        public static Font? NewFont(string filename, int size = 18)
        {
            if (File.Exists(filename))
            {
                Font newFont = new(Raylib.LoadFontEx(filename, size, Array.Empty<int>(), 0));
                newFont.SetFilter(_currentFilter);
                _loadedFonts.Add(newFont);

                return newFont;
            }
            else
            {
                Game.Error("Font file does not exist.");
                return null;
            }
        }

        /// <summary>
        /// Creates a new Image.
        /// </summary>
        /// <param name="filename">The filepath to the image file.</param>
        /// <returns>A new Image object which can be drawn on screen.</returns>
        public static Image? NewImage(string filename)
        {
            if (File.Exists(filename))
            {
                Image newImage = new(Raylib.LoadTexture(filename));
                newImage.SetFilter(_currentFilter);
                _loadedImages.Add(newImage);

                return newImage;
            }
            else
            {
                Game.Error("Image file does not exist.");
                return null;
            }
        }

        /// <summary>
        /// Creates a new ParticleSystem.
        /// </summary>
        /// <param name="image">The image to use.</param>
        /// <param name="buffer">The max number of particles at the same time.</param>
        /// <returns>A new ParticleSystem.</returns>
        public static ParticleSystem NewParticleSystem(Image image, int buffer = 1000)
        {
            return new ParticleSystem(image, buffer);
        }

        /// <summary>
        /// Creates a new Quad.
        /// </summary>
        /// <param name="x">The top-left position in the Texture along the x-axis.</param>
        /// <param name="y">The top-left position in the Texture along the y-axis.</param>
        /// <param name="width">The width of the Quad in the Texture.</param>
        /// <param name="height">The height of the Quad in the Texture.</param>
        /// <returns>The new Quad.</returns>
        public static Quad NewQuad(int x, int y, int width, int height)
        {
            return new Quad(x, y, width, height);
        }

        /// <summary>
        /// Creates and sets a new Font.
        /// </summary>
        /// <param name="filename">The path and name of the file with the font.</param>
        /// <param name="size">The size of the font.</param>
        /// <returns>The new font.</returns>
        public static Font? SetNewFont(string filename, int size = 18)
        {
            Font? newFont = NewFont(filename, size);
            SetFont(newFont);

            return newFont;
        }

        /// <summary>
        /// Gets the current background color.
        /// </summary>
        /// <returns>The current background color.</returns>
        public static Color GetBackgroundColor()
        {
            return _currentBackgroundColor;
        }

        /// <summary>
        /// Returns the current target Canvas.
        /// </summary>
        /// <returns>The Canvas set by setCanvas. Returns null if drawing to the real screen.</returns>
        public static Canvas? GetCanvas()
        {
            return _currentCanvas;
        }

        /// <summary>
        /// Gets the current color.
        /// </summary>
        /// <returns>The current color.</returns>
        public static Color GetColor()
        {
            return _currentColor;
        }

        /// <summary>
        /// Returns the default scaling filters used with Images, Canvases, and Fonts.
        /// </summary>
        /// <returns>Filter mode used when scaling.</returns>
        public static FilterMode GetDefaultFilter()
        {
            return _currentFilter;
        }

        /// <summary>
        /// Gets the current Font object.
        /// </summary>
        /// <returns>The current Font.</returns>
        public static Font GetFont()
        {
            return _currentFont;
        }

        /// <summary>
        /// Gets the current line width.
        /// </summary>
        /// <returns>The current line width.</returns>
        public static float GetLineWidth()
        {
            return _lineWidth;
        }

        /// <summary>
        /// Gets the point size.
        /// </summary>
        /// <returns>The current point size.</returns>
        public static int GetPointSize()
        {
            return _pointSize;
        }

        /// <summary>
        /// Gets whether the graphics module is able to be used.
        /// </summary>
        /// <returns>Whether the graphics module is active and able to be used.</returns>
        public static bool IsActive()
        {
            return Raylib.IsWindowReady();
        }

        /// <summary>
        /// Sets the background color.
        /// </summary>
        /// <param name="color">The Color object to set.</param>
        public static void SetBackgroundColor(Color color)
        {
            _currentBackgroundColor = color;
        }

        /// <summary>
        /// Sets the background color.
        /// </summary>
        /// <param name="r">The red component (0-1).</param>
        /// <param name="g">The green component (0-1).</param>
        /// <param name="b">The blue component (0-1).</param>
        /// <param name="a">The alpha component (0-1).</param>
        public static void SetBackgroundColor(float r, float g, float b, float a = 1)
        {
            _currentBackgroundColor = new Color(r, g, b, a);
        }

        /// <summary>
        /// Captures drawing operations to a Canvas.
        /// </summary>
        /// <param name="canvas">The new target.</param>
        public static void SetCanvas(Canvas canvas)
        {
            Raylib.BeginTextureMode(canvas.GetRayCanvas());
            _currentCanvas = canvas;
        }

        /// <summary>
        /// Resets the render target to the screen, i.e. re-enables drawing to the screen.
        /// </summary>
        public static void SetCanvas()
        {
            Raylib.EndTextureMode();
            _currentCanvas = null;
        }

        /// <summary>
        /// Sets the color used for drawing.
        /// </summary>
        /// <param name="color">The Color object to set.</param>
        public static void SetColor(Color color)
        {
            _currentColor = color;
        }

        /// <summary>
        /// Sets the color used for drawing.
        /// </summary>
        /// <param name="r">The amount of red.</param>
        /// <param name="g">The amount of green.</param>
        /// <param name="b">The amount of blue.</param>
        /// <param name="a">The amount of alpha.</param>
        public static void SetColor(float r, float g, float b, float a = 1)
        {
            _currentColor = new Color(r, g, b, a);
        }

        /// <summary>
        /// Sets the default scaling filters used with Images, Canvases, and Fonts.
        /// </summary>
        /// <param name="filter">Filter mode used when scaling.</param>
        public static void SetDefaultFilter(FilterMode filter)
        {
            _currentFilter = filter;
        }

        /// <summary>
        /// Set an already-loaded Font as the current font.
        /// </summary>
        /// <param name="font">The Font object to use.</param>
        public static void SetFont(Font? font)
        {
            if (font is not null)
            {
                _currentFont = font;
            }
        }

        /// <summary>
        /// Sets the line width.
        /// </summary>
        /// <param name="width">The width of the line.</param>
        public static void SetLineWidth(float width)
        {
            _lineWidth = width;
        }

        /// <summary>
        /// Sets the point size.
        /// </summary>
        /// <param name="size">The new point size.</param>
        public static void SetPointSize(int size)
        {
            _pointSize = size;
        }

        /// <summary>
        /// Gets the DPI scale factor of the window.
        /// </summary>
        /// <returns>The pixel scale factor associated with the window.</returns>
        public static Vector2 GetDPIScale()
        {
            return Raylib.GetWindowScaleDPI();
        }

        /// <summary>
        /// Gets the width and height of the window.
        /// </summary>
        /// <returns>The dimensions of the window.</returns>
        public static Vector2 GetDimensions()
        {
            return new Vector2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
        }

        /// <summary>
        /// Gets the height in pixels of the window.
        /// </summary>
        /// <returns>The height of the window.</returns>
        public static int GetHeight()
        {
            return Raylib.GetScreenHeight();
        }

        /// <summary>
        /// Gets the width in pixels of the window.
        /// </summary>
        /// <returns>The width of the window.</returns>
        public static int GetWidth()
        {
            return Raylib.GetScreenWidth();
        }
    }
}