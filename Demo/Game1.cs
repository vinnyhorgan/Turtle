using Turtle;

namespace Demo
{
    class Game1 : Game
    {
        protected override Config Conf()
        {
            Config conf = new();

            conf.icon = "assets/icon.png";

            return conf;
        }

        protected override void Load(string[] args)
        {
            Physics.Init();
        }

        protected override void Update(float dt)
        {
            Physics.Update(dt);

            if (Mouse.IsDown(MouseConstant.Left))
            {
                Physics.CreateBall();
            }
        }

        protected override void Draw()
        {
            Graphics.Print("BODIES: " + Physics.Draw(), 10, 50);

            Graphics.Print("FPS: " + Timer.GetFPS(), 10, 10);
        }

        protected override void MousePressed(int x, int y, MouseConstant button)
        {
            Physics.CreateBall();
        }
    }
}