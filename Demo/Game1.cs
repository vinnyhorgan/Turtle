using Turtle;

namespace Demo
{
    class Game1 : Game
    {
        private World _world = Physics.NewWorld(0, 10);

        protected override Config Conf()
        {
            Config conf = new();

            conf.icon = "assets/icon.png";
            conf.vsync = false;

            return conf;
        }

        protected override void Load(string[] args)
        {
            Collider ground = _world.NewRectangleCollider(50, 550, 700, 20);
            ground.SetType(BodyType.Static);

            Collider ground1 = _world.NewRectangleCollider(50, 50, 20, 500);
            ground1.SetType(BodyType.Static);

            Collider ground2 = _world.NewRectangleCollider(730, 50, 20, 500);
            ground2.SetType(BodyType.Static);
        }

        protected override void Update(float dt)
        {
            _world.Update(dt);

            if (Mouse.IsDown(MouseConstant.Left))
            {
                _world.NewRectangleCollider(Mouse.GetX(), Mouse.GetY(), 20, 20);
            }
        }

        protected override void Draw()
        {
            Graphics.Print("FPS: " + Timer.GetFPS(), 10, 10);
            Graphics.Print("Body Count: " + _world.GetBodyCount(), 10, 50);

            _world.Draw();
        }

        protected override void MousePressed(int x, int y, MouseConstant button)
        {

        }
    }
}