using Turtle;

using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    class Game1 : Game
    {
        private enum Direction
        {
            Up,
            Down
        }

        public static List<Hearth> hearths = new();

        private Image? _turtle;
        private Image? _hearth;
        private int _baseY = 0;
        private float _y = 0;
        private Direction _direction = Direction.Up;
        private int _floatRange = 10;
        private float _floatSpeed = 50;
        private float _spawnTimer = 0;
        private float _spawnSpeed = 1f;

        protected override Config Conf()
        {
            Config conf = new();

            conf.icon = "assets/icon.png";
            conf.title = "Turtle 0.1.2 (LÖVEly Turtles)";

            return conf;
        }

        protected override void Load(string[] args)
        {
            _turtle = Graphics.NewImage("assets/turtle.png");
            _hearth = Graphics.NewImage("assets/hearth.png");

            if (_turtle is not null)
            {
                _baseY = Graphics.GetHeight() / 2 - _turtle.GetHeight() / 4;
                _y = _baseY;
            }

            Graphics.SetBackgroundColor(254.0f / 255, 171.0f / 255, 243.0f / 255);
        }

        protected override void Update(float dt)
        {
            _spawnTimer += dt;

            if (_direction == Direction.Up)
            {
                _y -= _floatSpeed * dt;
            }
            else if (_direction == Direction.Down)
            {
                _y += _floatSpeed * dt;
            }

            if (_y < _baseY - _floatRange)
            {
                _direction = Direction.Down;
            }
            else if (_y > _baseY + _floatRange)
            {
                _direction = Direction.Up;
            }

            if (_spawnTimer > _spawnSpeed)
            {
                _spawnTimer = 0;
                hearths.Add(new Hearth());
            }

            foreach (Hearth hearth in hearths.ToList())
            {
                hearth.Update(dt);
            }
        }

        protected override void Draw()
        {
            foreach (Hearth hearth in hearths.ToList())
            {
                hearth.Draw();
            }

            if (_turtle is not null)
            {
                Graphics.Draw(_turtle, Graphics.GetWidth() / 2 - _turtle.GetWidth() / 4, (int)_y, 0, 0.5f);
            }
        }
    }
}