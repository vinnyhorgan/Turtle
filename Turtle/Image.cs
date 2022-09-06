using Raylib_cs;

using System.Numerics;

namespace Turtle
{
    public class Image
    {
        private Texture2D _rayImage;
        private FilterMode _filter = FilterMode.Linear;

        internal Image(Texture2D rayImage)
        {
            _rayImage = rayImage;
        }

        internal Texture2D GetRayImage()
        {
            return _rayImage;
        }

        // Functions

        /// <summary>
        /// Gets the width and height of the Image.
        /// </summary>
        /// <returns>The dimensions of the Image</returns>
        public Vector2 GetDimensions()
        {
            return new Vector2(_rayImage.width, _rayImage.height);
        }

        /// <summary>
        /// Gets the filter mode of the Image.
        /// </summary>
        /// <returns>Filter mode to use when scaling the Image.</returns>
        public FilterMode GetFilter()
        {
            return _filter;
        }

        /// <summary>
        /// Gets the height of the Image.
        /// </summary>
        /// <returns>The height of the Image, in pixels.</returns>
        public int GetHeight()
        {
            return _rayImage.height;
        }

        /// <summary>
        /// Gets the number of mipmaps contained in the Image.
        /// </summary>
        /// <returns>The number of mipmaps in the Image.</returns>
        public int GetMipmapCount()
        {
            return _rayImage.mipmaps;
        }

        /// <summary>
        /// Gets the width of the Image.
        /// </summary>
        /// <returns>The width of the Image, in pixels.</returns>
        public int GetWidth()
        {
            return _rayImage.width;
        }

        /// <summary>
        /// Sets the filter mode of the Image.
        /// </summary>
        /// <param name="mode">Filter mode to use when scaling the Image.</param>
        public void SetFilter(FilterMode mode)
        {
            switch (mode)
            {
                case FilterMode.Linear:
                    Raylib.SetTextureFilter(_rayImage, TextureFilter.TEXTURE_FILTER_BILINEAR);
                    break;
                case FilterMode.Nearest:
                    Raylib.SetTextureFilter(_rayImage, TextureFilter.TEXTURE_FILTER_POINT);
                    break;
            }

            _filter = mode;
        }

        /// <summary>
        /// Immediately destroys the object's reference.
        /// </summary>
        public void Release()
        {
            Raylib.UnloadTexture(_rayImage);

            Graphics.GetLoadedImages().Remove(this);
        }
    }
}