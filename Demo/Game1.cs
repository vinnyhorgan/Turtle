using Turtle;
using System;

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

        }

        public override void Draw()
        {
            Graphics.Print("AVERAGE DELTA: " + Timer.GetAverageDelta(), 100, 50);
            Graphics.Print("DELTA: " + Timer.GetDelta(), 10, 100);
            Graphics.Print("FPS: " + Timer.GetFPS(), 10, 150);
            Graphics.Print("TIME: " + Timer.GetTime(), 10, 200);
            Graphics.Print("STEP: " + Timer.Step(), 10, 250);
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
                Timer.Sleep(1);
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
    }
}