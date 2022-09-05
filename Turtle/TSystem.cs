using Raylib_cs;

using System;
using System.Text;

namespace Turtle
{
    /// <summary>
    /// Provides access to information about the user's system.
    /// </summary>
    public static class TSystem
    {
        /// <summary>
        /// Gets text from the clipboard.
        /// </summary>
        /// <returns>The text currently held in the system's clipboard.</returns>
        public static string GetClipboardText()
        {
            return Raylib.GetClipboardText_();
        }

        /// <summary>
        /// Gets the current operating system.
        /// </summary>
        /// <returns>The current operating system.</returns>
        public static OS GetOS()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Unix:
                    return OS.Linux
                case PlatformID.MacOSX:
                    return OS.Macos;
                case PlatformID.Win32NT:
                    return OS.Windows;
                default:
                    return OS.Other;
            }
        }

        /// <summary>
        /// Gets the amount of logical processors in the system.
        /// </summary>
        /// <returns>Amount of logical processors.</returns>
        public static int GetProcessorCount()
        {
            return Environment.ProcessorCount;
        }

        /// <summary>
        /// Opens a URL with the user's web or file browser.
        /// </summary>
        /// <param name="url">The URL to open. Must be formatted as a proper URL.</param>
        public static void OpenURL(string url)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(url);

            unsafe
            {
                fixed (byte* p = bytes)
                {
                    sbyte* sp = (sbyte*)p;

                    Raylib.OpenURL(sp);
                }
            }
        }

        /// <summary>
        /// Puts text in the clipboard.
        /// </summary>
        /// <param name="text">The new text to hold in the system's clipboard.</param>
        public static void SetClipboardText(string text)
        {
            Raylib.SetClipboardText(text);
        }
    }
}