namespace Turtle
{
    /// <summary>
    /// Configuration settings.
    /// </summary>
    public class Config
    {
        /// <summary>
        /// The Turtle version this game was made for.
        /// </summary>
        public Version version = new Version(0, 1, 2, "LÖVEly Turtles");

        /// <summary>
        /// The window title.
        /// </summary>
        public string title = "Untitled";

        /// <summary>
        /// Filepath to an image to use as the window's icon.
        /// </summary>
        public string? icon = null;

        /// <summary>
        /// The window width.
        /// </summary>
        public int width = 800;

        /// <summary>
        /// The window height.
        /// </summary>
        public int height = 600;

        /// <summary>
        /// Remove all border visuals from the window.
        /// </summary>
        public bool borderless = false;

        /// <summary>
        /// Let the window be user-resizable.
        /// </summary>
        public bool resizable = false;

        /// <summary>
        /// Minimum window width if the window is resizable.
        /// </summary>
        public int minwidth = 1;

        /// <summary>
        /// Minimum window height if the window is resizable.
        /// </summary>
        public int minheight = 1;

        /// <summary>
        /// Enable fullscreen.
        /// </summary>
        public bool fullscreen = false;

        /// <summary>
        /// Vertical sync mode.
        /// </summary>
        public bool vsync = true;

        /// <summary>
        /// Enable multi-sampled antialiasing.
        /// </summary>
        public bool msaa = false;

        /// <summary>
        /// Index of the monitor to show the window in if fullscreen.
        /// </summary>
        public int display = 0;

        /// <summary>
        /// The x-coordinate of the window's position.
        /// </summary>
        public int? x = null;

        /// <summary>
        /// The y-coordinate of the window's position.
        /// </summary>
        public int? y = null;
    }
}