using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Turtle
{
    public class Game
    {
        private static bool _error = false;
        private static string _errorMessage = "";
        private static bool _copied = false;
        private static string _version = "1.0";
        private static float _timer = 0.0f;
        private static List<float> _deltas = new();

        internal static void SetError(string message)
        {
            _error = true;
            _errorMessage = message;
        }

        internal static string GetVersion()
        {
            return _version;
        }

        public virtual Config Conf()
        {
            return new Config();
        }

        public virtual void Load()
        {

        }

        public virtual void Update(float dt)
        {

        }

        public virtual void Draw()
        {

        }

        public virtual void KeyPressed(KeyConstant key)
        {

        }

        public virtual void KeyReleased(KeyConstant key)
        {

        }

        public virtual void MousePressed(MouseConstant button)
        {

        }

        public virtual void MouseReleased(MouseConstant button)
        {

        }

        public virtual void WheelMoved(float scroll)
        {

        }

        public virtual void FileDropped(string[] files)
        {

        }

        public virtual void Resize(int width, int height)
        {

        }

        public void Run()
        {
            Config conf = Conf();

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
                    SetError("Icon does not exist.");
                }
            }

            if (conf.resizable)
            {
                Raylib.SetWindowMinSize(conf.minwidth, conf.minheight);
            }

            if (conf.vsync)
            {
                Raylib.SetTargetFPS(Raylib.GetMonitorRefreshRate(conf.display));
            }

            if (conf.fullscreen)
            {
                Raylib.SetWindowMonitor(conf.display);
            }

            if (conf.x is not null && conf.y is not null)
            {
                Raylib.SetWindowPosition((int)conf.x, (int)conf.y);
            }

            if (conf.version != _version)
            {
                SetError("The project uses a different version of Turtle.");
            }

            Graphics.Init();

            Load();

            while (!Raylib.WindowShouldClose())
            {
                if (!_error)
                {
                    foreach (int key in Enum.GetValues(typeof(KeyConstant)))
                    {
                        if (Raylib.IsKeyPressed((KeyboardKey)key))
                        {
                            KeyPressed((KeyConstant)key);
                        }
                        else if (Raylib.IsKeyReleased((KeyboardKey)key))
                        {
                            KeyReleased((KeyConstant)key);
                        }
                    }

                    foreach (int button in Enum.GetValues(typeof(MouseConstant)))
                    {
                        if (Raylib.IsMouseButtonPressed((MouseButton)button))
                        {
                            MousePressed((MouseConstant)button);
                        }
                        else if (Raylib.IsMouseButtonReleased((MouseButton)button))
                        {
                            MouseReleased((MouseConstant)button);
                        }
                    }

                    if (Raylib.GetMouseWheelMove() != 0)
                    {
                        WheelMoved(Raylib.GetMouseWheelMove());
                    }

                    if (Raylib.IsFileDropped())
                    {
                        FileDropped(Raylib.GetDroppedFiles());
                        Raylib.ClearDroppedFiles();
                    }

                    if (Raylib.IsWindowResized())
                    {
                        Resize(Raylib.GetScreenWidth(), Raylib.GetScreenHeight());
                    }

                    float dt = Raylib.GetFrameTime();

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

                    Raylib.ClearBackground(new Color(0, 0, 0).GetRayColor());

                    Draw();

                    Raylib.EndDrawing();
                }
                else
                {
                    if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
                    {
                        _copied = true;
                    }

                    Raylib.BeginDrawing();

                    Raylib.ClearBackground(new Color(89, 157, 220).GetRayColor());

                    Graphics.Print("Error", 100, 100);
                    Graphics.Print(_errorMessage, 100, 150);

                    if (!_copied)
                    {
                        Graphics.Print("Click to copy this error", 100, 200);
                    }
                    else
                    {
                        Graphics.Print("Copied!", 100, 200);
                    }

                    Raylib.EndDrawing();
                }
            }

            Raylib.CloseWindow();
        }
    }
}