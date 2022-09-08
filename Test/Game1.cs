using Turtle;

namespace Test
{
    public class Game1 : Game
    {
        protected override Config Conf()
        {
            Config conf = new();

            conf.title = "Turtle Test";
            conf.resizable = true;

            return conf;
        }

        protected override void Draw()
        {
            Graphics.Print("Hello Turtle!", 10, 10);
        }
    }
}