using Turtle;
using System;
using System.Numerics;

namespace Demo
{
    class Game1 : Game
    {
        public override Config Conf()
        {
            Config conf = new();

            conf.version = "1.0";
            conf.icon = "assets/demo.png";
            conf.width = 1280;
            conf.height = 720;
            conf.resizable = true;
            conf.vsync = false;

            return conf;
        }

        public override void Load()
        {

        }

        public override void Update(float dt)
        {
            if (Keyboard.IsDown(KeyConstant.A))
                Console.WriteLine("Hellooo");
        }

        public override void Draw()
        {
            Graphics.Print("AVERAGE DELTA: " + Timer.GetAverageDelta(), 100, 50);
            Graphics.Print("DELTA: " + Timer.GetDelta(), 10, 100);
            Graphics.Print("FPS: " + Timer.GetFPS(), 10, 150);
            Graphics.Print("TIME: " + Timer.GetTime(), 10, 200);
            Graphics.Print("STEP: " + Timer.Step(), 10, 250);

            Graphics.Arc(DrawMode.Line, 200, 200, 50, -135, 135, 100);

            Graphics.Line(new Vector2(10, 10), new Vector2(400, 69), new Vector2(500, 400), new Vector2(100, 44));
        }

        public override void Resize(int width, int height)
        {
            Console.WriteLine(width + "   " + height);
        }

        public override void FileDropped(string[] files)
        {
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }

        public override void KeyPressed(KeyConstant key)
        {
            Console.WriteLine(key);

            if (key == KeyConstant.Space)
            {
                Keyboard.SetKeyRepeat(!Keyboard.HasKeyRepeat());
            }
        }

        public override void KeyReleased(KeyConstant key)
        {
            Console.WriteLine(key);
        }

        public override void MousePressed(MouseConstant button)
        {
            Console.WriteLine(button);
        }

        public override void MouseReleased(MouseConstant button)
        {
            Console.WriteLine(button);
        }

        public override void WheelMoved(float scroll)
        {
            Console.WriteLine("Wheel Moved");
        }

        public override void MouseMoved(int x, int y, int dx, int dy)
        {
            Console.WriteLine($"{x} {y} {dx} {dy}");
        }
    }
}