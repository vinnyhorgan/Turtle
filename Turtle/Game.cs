using Raylib_cs;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Turtle
{
    /// <summary>
    /// The entry point of the game. It runs the main loop and provides many useful callbacks.
    /// </summary>
    public class Game
    {
        private static Version _version = new Version(0, 1, 0, "Evil Turtle");

        private static bool _error = false;
        private static string _errorMessage = "";
        private static bool _copied = false;

        private bool _exit = false;
        private bool _exitRequested = false;

        private bool _focus = false;
        private bool _mouseFocus = false;
        private bool _visible = false;
        private Vector2 _mousePosition = Mouse.GetPosition();

        private float _timer = 0.0f;
        private List<float> _deltas = new();

        // Functions

        /// <summary>
        /// Gets the current running version of Turtle.
        /// </summary>
        /// <returns>The version struct.</returns>
        public static Version GetVersion()
        {
            return _version;
        }

        /// <summary>
        /// Exits the program with an error that gets displayed by the ErrorHandler callback.
        /// </summary>
        /// <param name="message">The error message.</param>
        public static void Error(string message)
        {
            _error = true;
            _errorMessage = message;
            Console.WriteLine($"Error: {_errorMessage}");
        }

        // General

        /// <summary>
        /// Callback function used to overwrite the default configuration settings.
        /// </summary>
        /// <returns>Configuration settings.</returns>
        public virtual Config Conf()
        {
            return new Config();
        }

        /// <summary>
        /// Callback function used to draw on the screen every frame.
        /// </summary>
        public virtual void Draw()
        {

        }

        /// <summary>
        /// The error handler, used to display error messages.
        /// </summary>
        /// <param name="message">The error message.</param>
        public virtual void ErrorHandler(string message)
        {
            if (Keyboard.IsDown(KeyConstant.LeftControl) && Keyboard.IsDown(KeyConstant.C))
            {
                _copied = true;
            }
            else if (Mouse.IsDown(MouseConstant.Left))
            {
                _copied = true;
            }

            Graphics.Clear(89, 157, 220);

            Graphics.Print("Error", 100, 100);
            Graphics.Print(_errorMessage, 100, 150);

            if (!_copied)
            {
                Graphics.Print("Press Ctrl+C or tap to copy this error", 100, 200);
            }
            else
            {
                Graphics.Print("Copied to clipboard!", 100, 200);
            }
        }

        /// <summary>
        /// This function is called exactly once at the beginning of the game.
        /// </summary>
        /// <param name="args">Command-line arguments given to the game.</param>
        public virtual void Load(string[] args)
        {

        }

        /// <summary>
        /// Callback function triggered when the game is closed.
        /// </summary>
        /// <returns>Abort quitting. If true, do not close the game.</returns>
        public virtual bool Quit()
        {
            return false;
        }

        /// <summary>
        /// Callback function used to update the state of the game every frame.
        /// </summary>
        /// <param name="dt">Time since the last update in seconds.</param>
        public virtual void Update(float dt)
        {

        }

        // Window

        /// <summary>
        /// Callback function triggered when one or more directories are dragged and dropped onto the window.
        /// </summary>
        /// <param name="path">A list of the dropped directories paths.</param>
        public virtual void DirectoryDropped(string[] directories)
        {

        }

        /// <summary>
        /// Callback function triggered when one or more files are dragged and dropped onto the window.
        /// </summary>
        /// <param name="files">A list of the dropped files paths.</param>
        public virtual void FileDropped(string[] files)
        {

        }

        /// <summary>
        /// Callback function triggered when window receives or loses focus.
        /// </summary>
        /// <param name="focus">True if the window gains focus, false if it loses focus.</param>
        public virtual void Focus(bool focus)
        {

        }

        /// <summary>
        /// Callback function triggered when window receives or loses mouse focus.
        /// </summary>
        /// <param name="focus">Whether the window has mouse focus or not.</param>
        public virtual void MouseFocus(bool focus)
        {

        }

        /// <summary>
        /// Called when the window is resized.
        /// </summary>
        /// <param name="width">The new width.</param>
        /// <param name="height">The new height.</param>
        public virtual void Resize(int width, int height)
        {

        }

        /// <summary>
        /// Callback function triggered when window is shown or hidden.
        /// </summary>
        /// <param name="visible">True if the window is visible, false if it isn't.</param>
        public virtual void Visible(bool visible)
        {

        }

        // Keyboard

        /// <summary>
        /// Callback function triggered when a key is pressed.
        /// </summary>
        /// <param name="key">Character of the pressed key.</param>
        /// <param name="isRepeat">Whether this keypress event is a repeat.</param>
        public virtual void KeyPressed(KeyConstant key, bool isRepeat)
        {

        }

        /// <summary>
        /// Callback function triggered when a keyboard key is released.
        /// </summary>
        /// <param name="key">Character of the released key.</param>
        public virtual void KeyReleased(KeyConstant key)
        {

        }

        // Mouse

        /// <summary>
        /// Callback function triggered when the mouse is moved.
        /// </summary>
        /// <param name="x">The mouse position on the x-axis.</param>
        /// <param name="y">The mouse position on the y-axis.</param>
        /// <param name="dx">The amount moved along the x-axis since the last time love.mousemoved was called.</param>
        /// <param name="dy">The amount moved along the y-axis since the last time love.mousemoved was called.</param>
        public virtual void MouseMoved(int x, int y, int dx, int dy)
        {

        }

        /// <summary>
        /// Callback function triggered when a mouse button is pressed.
        /// </summary>
        /// <param name="x">Mouse x position, in pixels.</param>
        /// <param name="y">Mouse y position, in pixels.</param>
        /// <param name="button">The button that was pressed.</param>
        public virtual void MousePressed(int x, int y, MouseConstant button)
        {

        }

        /// <summary>
        /// Callback function triggered when a mouse button is released.
        /// </summary>
        /// <param name="x">Mouse x position, in pixels.</param>
        /// <param name="y">Mouse y position, in pixels.</param>
        /// <param name="button">The button that was released.</param>
        public virtual void MouseReleased(int x, int y, MouseConstant button)
        {

        }

        /// <summary>
        /// Callback function triggered when the mouse wheel is moved.
        /// </summary>
        /// <param name="y">Amount of vertical mouse wheel movement.</param>
        public virtual void WheelMoved(float y)
        {

        }

        // Main loop

        /// <summary>
        /// The main function, containing the main loop.
        /// </summary>
        /// <param name="args">Command-line arguments given to the game.</param>
        public void Run(string[] args)
        {
            Config conf = Conf();

            if (conf.version.ToString() != _version.ToString())
            {
                Error("The project uses a different version of Turtle.");
            }

            if (conf.borderless)
            {
                Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_UNDECORATED);
            }

            if (conf.resizable)
            {
                Raylib.SetConfigFlags(ConfigFlags.FLAG_WINDOW_RESIZABLE);
            }

            if (conf.fullscreen)
            {
                Raylib.SetConfigFlags(ConfigFlags.FLAG_FULLSCREEN_MODE);
            }

            if (conf.msaa)
            {
                Raylib.SetConfigFlags(ConfigFlags.FLAG_MSAA_4X_HINT);
            }

            Raylib.SetTraceLogLevel(TraceLogLevel.LOG_NONE);

            Raylib.InitWindow(conf.width, conf.height, conf.title);

            Raylib.SetExitKey(KeyboardKey.KEY_NULL);

            if (conf.icon is not null)
            {
                if (File.Exists(conf.icon))
                {
                    Raylib_cs.Image newIcon = Raylib.LoadImage(conf.icon);
                    Raylib.SetWindowIcon(newIcon);
                }
                else
                {
                    Error("Icon does not exist.");
                }
            }

            if (conf.resizable)
            {
                Raylib.SetWindowMinSize(conf.minwidth, conf.minheight);
            }

            if (conf.vsync)
            {
                Raylib.SetTargetFPS(Raylib.GetMonitorRefreshRate(Raylib.GetCurrentMonitor()));
            }

            if (conf.fullscreen)
            {
                Raylib.SetWindowMonitor(conf.display);
            }

            if (conf.x is not null && conf.y is not null)
            {
                Raylib.SetWindowPosition((int)conf.x, (int)conf.y);
            }

            if (File.Exists("assets/Vera.ttf"))
            {
                Graphics.SetNewFont("assets/Vera.ttf");
            }
            else
            {
                Error("Unable to load default font.");
            }

            Load(args);

            while (!_exit)
            {
                if (!_error)
                {
                    if (Raylib.WindowShouldClose())
                    {
                        _exitRequested = true;
                    }

                    if (_exitRequested)
                    {
                        if (Quit())
                        {
                            _exitRequested = false;
                        }
                        else
                        {
                            _exit = true;
                        }
                    }

                    if (Raylib.IsFileDropped())
                    {
                        string[] paths = Raylib.GetDroppedFiles();

                        List<string> directories = new();
                        List<string> files = new();

                        foreach (string path in paths)
                        {
                            if (Directory.Exists(path))
                            {
                                directories.Add(path);
                            }
                            else if (File.Exists(path))
                            {
                                files.Add(path);
                            }
                        }

                        if (directories.Count > 0)
                        {
                            DirectoryDropped(directories.ToArray());
                        }

                        if (files.Count > 0)
                        {
                            FileDropped(files.ToArray());
                        }

                        Raylib.ClearDroppedFiles();
                    }

                    if (_focus != Raylib.IsWindowFocused())
                    {
                        _focus = Raylib.IsWindowFocused();
                        Focus(_focus);
                    }

                    if (_mouseFocus != Raylib.IsCursorOnScreen())
                    {
                        _mouseFocus = Raylib.IsCursorOnScreen();
                        MouseFocus(_mouseFocus);
                    }

                    if (Raylib.IsWindowResized())
                    {
                        Resize(Graphics.GetWidth(), Graphics.GetHeight());
                    }

                    if (_visible != !Raylib.IsWindowHidden())
                    {
                        _visible = !Raylib.IsWindowHidden();
                        Visible(_visible);
                    }

                    foreach (int key in Enum.GetValues(typeof(KeyConstant)))
                    {
                        if (Keyboard.HasKeyRepeat())
                        {
                            if (Keyboard.IsDown((KeyConstant)key))
                            {
                                KeyPressed((KeyConstant)key, true);
                            }
                        }
                        else
                        {
                            if (Raylib.IsKeyPressed((KeyboardKey)key))
                            {
                                KeyPressed((KeyConstant)key, false);
                            }
                            else if (Raylib.IsKeyReleased((KeyboardKey)key))
                            {
                                KeyReleased((KeyConstant)key);
                            }
                        }
                    }

                    if (Mouse.GetPosition() != _mousePosition)
                    {
                        Vector2 newPosition = Mouse.GetPosition();
                        MouseMoved((int)newPosition.X, (int)newPosition.Y, (int)newPosition.X - (int)_mousePosition.X, (int)newPosition.Y - (int)_mousePosition.Y);
                        _mousePosition = newPosition;
                    }

                    foreach (int button in Enum.GetValues(typeof(MouseConstant)))
                    {
                        if (Raylib.IsMouseButtonPressed((MouseButton)button))
                        {
                            MousePressed(Mouse.GetX(), Mouse.GetY(), (MouseConstant)button);
                        }
                        else if (Raylib.IsMouseButtonReleased((MouseButton)button))
                        {
                            MouseReleased(Mouse.GetX(), Mouse.GetY(), (MouseConstant)button);
                        }
                    }

                    if (Raylib.GetMouseWheelMove() != 0)
                    {
                        WheelMoved(Raylib.GetMouseWheelMove());
                    }

                    float dt = Timer.GetDelta();

                    _timer += dt;
                    _deltas.Add(dt);

                    if (_timer > 1)
                    {
                        Timer.SetAverageDelta(Queryable.Average(_deltas.AsQueryable()));
                        _timer = 0.0f;
                        _deltas.Clear();
                    }

                    Update(dt);

                    Raylib.BeginDrawing();

                    Graphics.Clear();

                    Draw();

                    Raylib.EndDrawing();
                }
                else
                {
                    Raylib.BeginDrawing();

                    Graphics.Clear();

                    ErrorHandler(_errorMessage);

                    Raylib.EndDrawing();
                }
            }

            Raylib.CloseWindow();
        }
    }
}