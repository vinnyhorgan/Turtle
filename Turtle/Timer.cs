using Raylib_cs;
using System.Threading;

namespace Turtle
{
    public static class Timer
    {
        private static float _averageDelta = 0.0f;

        internal static void SetAverageDelta(float averageDelta)
        {
            _averageDelta = averageDelta;
        }

        /// <summary>
        /// Returns the average delta time (seconds per frame) over the last second.
        /// </summary>
        public static float GetAverageDelta()
        {
            return _averageDelta;
        }

        /// <summary>
        /// Returns the time between the last two frames.
        /// </summary>
        public static float GetDelta()
        {
            return Raylib.GetFrameTime();
        }

        /// <summary>
        /// Returns the current number of frames per second.
        /// </summary>
        public static int GetFPS()
        {
            return Raylib.GetFPS();
        }

        /// <summary>
        /// Returns the value of a precise timer with an unspecified starting time.
        /// </summary>
        public static double GetTime()
        {
            return Raylib.GetTime();
        }

        /// <summary>
        /// Pauses the current thread for the specified amount of time.
        /// </summary>
        public static void Sleep(float seconds)
        {
            Thread.Sleep((int)(seconds * 1000));
        }

        /// <summary>
        /// Measures the time between two frames.
        /// </summary>
        public static float Step()
        {
            float step = 0.0f;

            float fps = GetFPS();

            if (fps != 0)
            {
                step = 1 / fps;
            }

            return step;
        }
    }
}