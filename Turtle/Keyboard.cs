using Raylib_cs;

namespace Turtle
{
    public static class Keyboard
    {
        private static bool _keyRepeat = false;

        /// <summary>
        /// Gets whether key repeat is enabled.
        /// </summary>
        public static bool HasKeyRepeat()
        {
            return _keyRepeat;
        }

        /// <summary>
        /// Checks whether a certain key is down.
        /// </summary>
        public static bool IsDown(KeyConstant key)
        {
            return Raylib.IsKeyDown((KeyboardKey)key);
        }

        /// <summary>
        /// Checks whether a certain key is down.
        /// </summary>
        public static bool IsDown(params KeyConstant[] keys)
        {
            bool anyDown = false;

            foreach (KeyConstant key in keys)
            {
                if (IsDown(key))
                {
                    anyDown = true;
                }
            }

            return anyDown;
        }

        /// <summary>
        /// Enables or disables key repeat for Turtle.KeyPressed.
        /// </summary>
        public static void SetKeyRepeat(bool keyRepeat)
        {
            _keyRepeat = keyRepeat;
        }
    }
}