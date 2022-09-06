using Turtle;

namespace Demo
{
    class Game1 : Game
    {
        protected override Config Conf()
        {
            Config conf = new();

            conf.icon = "assets/demo.png";

            return conf;
        }

        protected override void Load(string[] args)
        {

        }

        protected override void Update(float dt)
        {
            Physics.Update(dt);
        }

        protected override void Draw()
        {
            Physics.Draw();
        }

        protected override void MousePressed(int x, int y, MouseConstant button)
        {
            Physics.CreateBall();
        }
    }
}