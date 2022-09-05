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

            conf.icon = "assets/demo.png";
            conf.width = 1280;
            conf.height = 720;
            conf.resizable = true;
            conf.vsync = false;

            return conf;
        }

        public override void Load(string[] args)
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
            Graphics.Print(Game.GetVersion().ToString(), 10, 400);

            Graphics.Arc(DrawMode.Line, 200, 200, 50, -135, 135, 100);

            Graphics.Line(new Vector2(10, 10), new Vector2(400, 69), new Vector2(500, 400), new Vector2(100, 44));
        }

        public override void FileDropped(string[] files)
        {
            Console.WriteLine("FILE");

            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
        }

        public override void DirectoryDropped(string[] directories)
        {
            Console.WriteLine("DIRECTORY");

            foreach (string dir in directories)
            {
                Console.WriteLine(dir);
            }
        }
    }
}