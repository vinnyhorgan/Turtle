using Raylib_cs;

namespace Turtle
{
    public class Game
    {
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
                Image newIcon = Raylib.LoadImage(conf.icon);
                Raylib.SetWindowIcon(newIcon);
            }

            if (conf.resizable)
            {
                Raylib.SetWindowMinSize(conf.minwidth, conf.minheight);
            }

            if (conf.vsync)
            {
                Raylib.SetTargetFPS(Raylib.GetMonitorRefreshRate(conf.display));
            }

            Raylib.SetWindowMonitor(conf.display);

            if (conf.x is not null && conf.y is not null)
            {
                Raylib.SetWindowPosition((int)conf.x, (int)conf.y);
            }

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.BLACK);

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}