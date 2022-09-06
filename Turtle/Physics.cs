using tainicom.Aether.Physics2D.Dynamics;
using tainicom.Aether.Physics2D.Common;

using System;
using System.Collections.Generic;

namespace Turtle
{
    public static class Physics
    {
        private static World _world = new World();
        private static List<Body> _balls = new();

        public static void CreateBall()
        {
            Body newBall = _world.CreateBody(new Vector2(Mouse.GetX(), Mouse.GetY()), 0, BodyType.Dynamic);
            Fixture fixture = newBall.CreateCircle(25, 1f);

            _balls.Add(newBall);
        }

        public static void Update(float dt)
        {
            if (_world is not null)
            {
                _world.Step(dt);
            }
        }

        public static void Draw()
        {
            foreach (Body ball in _balls)
            {
                Graphics.Circle(DrawMode.Line, (int)ball.Position.X, (int)ball.Position.Y, 25);
            }
        }
    }
}