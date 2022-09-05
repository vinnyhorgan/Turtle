using Raylib_cs;
using System.Numerics;

namespace Turtle
{
    public static class Mouse
    {
        private static CursorType _cursor = CursorType.Default;
        private static bool _isGrabbed = false;

        public static CursorType GetCursor()
        {
            return _cursor;
        }

        public static Vector2 GetPosition()
        {
            return Raylib.GetMousePosition();
        }

        public static int GetX()
        {
            return Raylib.GetMouseX();
        }

        public static int GetY()
        {
            return Raylib.GetMouseY();
        }

        public static bool IsDown(MouseConstant button)
        {
            return Raylib.IsMouseButtonDown((MouseButton)button);
        }

        public static bool IsGrabbed()
        {
            return _isGrabbed;
        }

        public static bool IsVisible()
        {
            return !Raylib.IsCursorHidden();
        }

        public static void SetCursor()
        {
            _cursor = CursorType.Default;
        }

        public static void SetCursor(CursorType type)
        {
            Raylib.SetMouseCursor((MouseCursor)type);
            _cursor = type;
        }

        public static void SetGrabbed(bool grabbed)
        {
            if (grabbed)
            {
                Raylib.DisableCursor();
                _isGrabbed = true;
            }
            else
            {
                Raylib.EnableCursor();
                _isGrabbed = false;
            }
        }

        public static void SetPosition(int x, int y)
        {
            Raylib.SetMousePosition(x, y);
        }

        public static void SetPosition(Vector2 position)
        {
            Raylib.SetMousePosition((int)position.X, (int)position.Y);
        }

        public static void SetVisible(bool visible)
        {
            if (visible)
            {
                Raylib.ShowCursor();
            }
            else
            {
                Raylib.HideCursor();
            }
        }

        public static void SetX(int x)
        {
            Raylib.SetMousePosition(x, (int)GetPosition().Y);
        }

        public static void SetY(int y)
        {
            Raylib.SetMousePosition((int)GetPosition().X, y);
        }
    }
}