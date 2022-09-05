using Raylib_cs;

namespace Turtle
{
    public class Canvas
    {
        private RenderTexture2D _rayCanvas;

        internal Canvas(RenderTexture2D rayCanvas)
        {
            _rayCanvas = rayCanvas;
        }

        internal RenderTexture2D GetRayCanvas()
        {
            return _rayCanvas;
        }
    }
}