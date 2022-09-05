using Raylib_cs;

namespace Turtle
{
    public class Image
    {
        private Texture2D _rayImage;

        internal Image(Texture2D rayImage)
        {
            _rayImage = rayImage;
        }

        internal Texture2D GetRayImage()
        {
            return _rayImage;
        }

        public void Release()
        {

        }
    }
}