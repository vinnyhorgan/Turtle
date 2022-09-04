namespace Turtle
{
    public class Image
    {
        private Raylib_cs.Texture2D _rayImage;

        internal Image(Raylib_cs.Texture2D rayImage)
        {
            _rayImage = rayImage;
        }

        internal Raylib_cs.Texture2D GetRayImage()
        {
            return _rayImage;
        }

        public void Release()
        {

        }
    }
}