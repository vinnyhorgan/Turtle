using tainicom.Aether.Physics2D.Dynamics;
using tainicom.Aether.Physics2D.Common;

using System;
using System.Collections.Generic;

namespace Turtle
{
    public static class Physics
    {
        private static float PPM = 64.0f;

        private static World _world = new World(new Vector2(0, 10f));
        private static List<Body> _balls = new();
        private static Body _ground;
        private static Body _ground1;
        private static Body _ground2;

        public static void Init()
        {
            _ground = _world.CreateBody(new Vector2(100 / PPM, 500 / PPM));
            Fixture f = _ground.CreateRectangle(600 / PPM, 20 / PPM, 1.0f, new Vector2(300 / PPM, 10 / PPM));

            f.Restitution = 0.3f;
            f.Friction = 0.5f;

            _ground1 = _world.CreateBody(new Vector2(100 / PPM, 100 / PPM));
            Fixture f1 = _ground1.CreateRectangle(20 / PPM, 400 / PPM, 1.0f, new Vector2(10 / PPM, 200 / PPM));

            f1.Restitution = 0.3f;
            f1.Friction = 0.5f;

            _ground2 = _world.CreateBody(new Vector2(680 / PPM, 100 / PPM));
            Fixture f2 = _ground2.CreateRectangle(20 / PPM, 400 / PPM, 1.0f, new Vector2(10 / PPM, 200 / PPM));

            f2.Restitution = 0.3f;
            f2.Friction = 0.5f;
        }

        public static void CreateBall()
        {
            Body newBall = _world.CreateBody(new Vector2(Mouse.GetX() / PPM, Mouse.GetY() / PPM), 0, BodyType.Dynamic);
            Fixture f = newBall.CreateCircle(5 / PPM, 1.0f);
            f.Restitution = 0.3f;
            f.Friction = 0.5f;

            _balls.Add(newBall);
        }

        public static void Update(float dt)
        {
            if (_world is not null)
            {
                _world.Step(dt);
            }
        }

        public static int Draw()
        {
            foreach (Body ball in _balls)
            {
                Graphics.Circle(DrawMode.Line, (int)(ball.Position.X * PPM), (int)(ball.Position.Y * PPM), 5);
            }

            Graphics.Rectangle(DrawMode.Line, (int)(_ground.Position.X * PPM), (int)(_ground.Position.Y * PPM), 600, 20);
            Graphics.Rectangle(DrawMode.Line, (int)(_ground1.Position.X * PPM), (int)(_ground1.Position.Y * PPM), 20, 400);
            Graphics.Rectangle(DrawMode.Line, (int)(_ground2.Position.X * PPM), (int)(_ground2.Position.Y * PPM), 20, 400);

            BodyCollection coll = _world.BodyList;

            return coll.Count;
        }
    }
}