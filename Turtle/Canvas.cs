using Raylib_cs;

using System.Numerics;

namespace Turtle
{
    public class Canvas
    {
        private RenderTexture2D _rayCanvas;
        private FilterMode _filter = FilterMode.Linear;

        internal Canvas(RenderTexture2D rayCanvas)
        {
            _rayCanvas = rayCanvas;
        }

        internal RenderTexture2D GetRayCanvas()
        {
            return _rayCanvas;
        }

        // Functions

        /// <summary>
        /// Gets the width and height of the Canvas.
        /// </summary>
        /// <returns>The dimensions of the Canvas</returns>
        public Vector2 GetDimensions()
        {
            return new Vector2(_rayCanvas.texture.width, _rayCanvas.texture.height);
        }

        /// <summary>
        /// Gets the filter mode of the Canvas.
        /// </summary>
        /// <returns>Filter mode to use when scaling the Canvas.</returns>
        public FilterMode GetFilter()
        {
            return _filter;
        }

        /// <summary>
        /// Gets the height of the Canvas.
        /// </summary>
        /// <returns>The height of the Canvas, in pixels.</returns>
        public int GetHeight()
        {
            return _rayCanvas.texture.height;
        }

        /// <summary>
        /// Gets the number of mipmaps contained in the Canvas.
        /// </summary>
        /// <returns>The number of mipmaps in the Canvas.</returns>
        public int GetMipmapCount()
        {
            return _rayCanvas.texture.mipmaps;
        }

        /// <summary>
        /// Gets the width of the Canvas.
        /// </summary>
        /// <returns>The width of the Canvas, in pixels.</returns>
        public int GetWidth()
        {
            return _rayCanvas.texture.width;
        }

        /// <summary>
        /// Sets the filter mode of the Canvas.
        /// </summary>
        /// <param name="mode">Filter mode to use when scaling the Canvas.</param>
        public void SetFilter(FilterMode mode)
        {
            switch (mode)
            {
                case FilterMode.Linear:
                    Raylib.SetTextureFilter(_rayCanvas.texture, TextureFilter.TEXTURE_FILTER_BILINEAR);
                    break;
                case FilterMode.Nearest:
                    Raylib.SetTextureFilter(_rayCanvas.texture, TextureFilter.TEXTURE_FILTER_POINT);
                    break;
            }

            _filter = mode;
        }
    }
}