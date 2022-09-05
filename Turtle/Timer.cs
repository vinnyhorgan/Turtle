using Raylib_cs;

using System.Threading;

namespace Turtle
{
    /// <summary>
    /// Provides high-resolution timing functionality.
    /// </summary>
    public static class Timer
    {
        private static float _averageDelta = 0.0f;

        internal static void SetAverageDelta(float averageDelta)
        {
            _averageDelta = averageDelta;
        }

        // Functions

        /// <summary>
        /// Returns the average delta time over the last second.
        /// </summary>
        /// <returns>The average delta time over the last second.</returns>
        public static float GetAverageDelta()
        {
            return _averageDelta;
        }

        /// <summary>
        /// Returns the time between the last two frames.
        /// </summary>
        /// <returns>The time passed (in seconds).</returns>
        public static float GetDelta()
        {
            return Raylib.GetFrameTime();
        }

        /// <summary>
        /// Returns the current frames per second.
        /// </summary>
        /// <returns>The current FPS.</returns>
        public static int GetFPS()
        {
            return Raylib.GetFPS();
        }

        /// <summary>
        /// Returns the value of a precise timer with an unspecified starting time.
        /// </summary>
        /// <returns>The time in seconds. Given as a decimal, accurate to the microsecond.</returns>
        public static double GetTime()
        {
            return Raylib.GetTime();
        }

        /// <summary>
        /// Pauses the current thread for the specified amount of time.
        /// </summary>
        /// <param name="seconds">Seconds to sleep for.</param>
        public static void Sleep(float seconds)
        {
            Thread.Sleep((int)(seconds * 1000));
        }
    }
}