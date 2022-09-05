using Raylib_cs;

using System.Numerics;

namespace Turtle
{
    /// <summary>
    /// Provides an interface for modifying and retrieving information about the program's window.
    /// </summary>
    public static class Window
    {
        private static bool _vsync = false;
        private static string _title = "";

        // Functions

        /// <summary>
        /// Gets the DPI scale factor associated with the window.
        /// </summary>
        /// <returns>The pixel scale factor associated with the window.</returns>
        public static Vector2 GetDpiScale()
        {
            return Raylib.GetWindowScaleDPI();
        }

        /// <summary>
        /// Gets the width and height of the desktop.
        /// </summary>
        /// <returns>The dimensions of the desktop.</returns>
        public static Vector2 GetDesktopDimensions()
        {
            return new Vector2(Raylib.GetMonitorWidth(Raylib.GetCurrentMonitor()), Raylib.GetMonitorHeight(Raylib.GetCurrentMonitor()));
        }

        /// <summary>
        /// Gets the number of connected monitors.
        /// </summary>
        /// <returns>The number of currently connected displays.</returns>
        public static int GetDisplayCount()
        {
            return Raylib.GetMonitorCount();
        }

        /// <summary>
        /// Gets the name of a display.
        /// </summary>
        /// <param name="index">The index of the display to get the name of.</param>
        /// <returns>The name of the specified display.</returns>
        public static string GetDisplayName(int index)
        {
            unsafe
            {
                return new string(Raylib.GetMonitorName(index));
            }
        }

        /// <summary>
        /// Gets whether the window is fullscreen.
        /// </summary>
        /// <returns>True if the window is fullscreen, false otherwise.</returns>
        public static bool GetFullscreen()
        {
            return Raylib.IsWindowFullscreen();
        }

        /// <summary>
        /// Gets the position of the window on the screen.
        /// </summary>
        /// <returns>The position of the window.</returns>
        public static Vector2 GetPosition()
        {
            return Raylib.GetWindowPosition();
        }

        /// <summary>
        /// Gets the window title.
        /// </summary>
        /// <returns>The current window title.</returns>
        public static string GetTitle()
        {
            return _title;
        }

        /// <summary>
        /// Gets current vsync value.
        /// </summary>
        /// <returns>Current vsync status.</returns>
        public static bool GetVSync()
        {
            return _vsync;
        }

        /// <summary>
        /// Checks if the game window has keyboard focus.
        /// </summary>
        /// <returns>True if the window has the focus or false if not.</returns>
        public static bool HasFocus()
        {
            return Raylib.IsWindowFocused();
        }

        /// <summary>
        /// Checks if the game window has mouse focus.
        /// </summary>
        /// <returns>True if the window has mouse focus or false if not.</returns>
        public static bool HasMouseFocus()
        {
            return Raylib.IsCursorOnScreen();
        }

        /// <summary>
        /// Gets whether the Window is currently maximized.
        /// </summary>
        /// <returns>True if the window is currently maximized in windowed mode, false otherwise.</returns>
        public static bool IsMaximized()
        {
            return Raylib.IsWindowMaximized();
        }

        /// <summary>
        /// Gets whether the Window is currently minimized.
        /// </summary>
        /// <returns>True if the window is currently minimized, false otherwise.</returns>
        public static bool IsMinimized()
        {
            return Raylib.IsWindowMinimized();
        }

        /// <summary>
        /// Checks if the window is open.
        /// </summary>
        /// <returns>True if the window is open, false otherwise.</returns>
        public static bool IsOpen()
        {
            return Raylib.IsWindowReady();
        }

        /// <summary>
        /// Checks if the game window is visible.
        /// </summary>
        /// <returns>True if the window is visible or false if not.</returns>
        public static bool IsVisible()
        {
            return !Raylib.IsWindowHidden();
        }

        /// <summary>
        /// Makes the window as large as possible.
        /// </summary>
        public static void Maximize()
        {
            Raylib.MaximizeWindow();
        }

        /// <summary>
        /// Minimizes the window to the system's task bar / dock.
        /// </summary>
        public static void Minimize()
        {
            Raylib.MinimizeWindow();
        }

        /// <summary>
        /// Enters or exits fullscreen.
        /// </summary>
        /// <param name="fullscreen">Whether to enter or exit fullscreen mode.</param>
        public static void SetFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                if (!Raylib.IsWindowFullscreen())
                {
                    Raylib.ToggleFullscreen();
                }
            }
            else
            {
                if (Raylib.IsWindowFullscreen())
                {
                    Raylib.ToggleFullscreen();
                }
            }
        }

        /// <summary>
        /// Sets the window icon.
        /// </summary>
        /// <param name="filename">The window icon image.</param>
        public static void SetIcon(string filename)
        {
            Raylib.SetWindowIcon(Raylib.LoadImage(filename));
        }

        /// <summary>
        /// Sets the display mode and properties of the window.
        /// </summary>
        /// <param name="width">Display width.</param>
        /// <param name="height">Display height.</param>
        public static void SetMode(int width, int height)
        {
            Raylib.SetWindowSize(width, height);
        }

        /// <summary>
        /// Sets the position of the window on the screen.
        /// </summary>
        /// <param name="x">The x-coordinate of the window's position.</param>
        /// <param name="y">The y-coordinate of the window's position.</param>
        public static void SetPosition(int x, int y)
        {
            Raylib.SetWindowPosition(x, y);
        }

        /// <summary>
        /// Sets the window title.
        /// </summary>
        /// <param name="title">The new window title.</param>
        public static void SetTitle(string title)
        {
            Raylib.SetWindowTitle(title);

            _title = title;
        }

        /// <summary>
        /// Sets vertical synchronization mode.
        /// </summary>
        /// <param name="vsync">Whether to use vsync or not.</param>
        public static void SetVSync(bool vsync)
        {
            if (vsync)
            {
                if (!_vsync)
                {
                    Raylib.SetTargetFPS(Raylib.GetMonitorRefreshRate(Raylib.GetCurrentMonitor()));
                    _vsync = true;
                }
            }
            else
            {
                if (_vsync)
                {
                    Raylib.SetTargetFPS(0);
                    _vsync = false;
                }
            }
        }
    }
}