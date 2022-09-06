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

        public static void Init()
        {
            _ground = _world.CreateBody(new Vector2(100 / PPM, 400 / PPM));
            Fixture f = _ground.CreateRectangle(600 / PPM, 100 / PPM, 1.0f, new Vector2(300 / PPM, 50 / PPM));

            f.Restitution = 0.3f;
            f.Friction = 0.5f;
        }

        public static void CreateBall()
        {
            Body newBall = _world.CreateBody(new Vector2(Mouse.GetX() / PPM, Mouse.GetY() / PPM), 0, BodyType.Dynamic);
            Fixture f = newBall.CreateCircle(25 / PPM, 1.0f);
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
                Graphics.Circle(DrawMode.Line, (int)(ball.Position.X * PPM), (int)(ball.Position.Y * PPM), 25);
            }

            Graphics.Rectangle(DrawMode.Line, (int)(_ground.Position.X * PPM), (int)(_ground.Position.Y * PPM), 600, 100);

            BodyCollection coll = _world.BodyList;

            return coll.Count;
        }
    }
}