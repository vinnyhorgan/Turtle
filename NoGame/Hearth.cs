using Turtle;

using System.Numerics;

namespace Demo
{
    public class Hearth
    {
        public float Speed = 100;

        public float X;
        public int Y;
        public float Angle;

        private Image? _image;

        public Hearth()
        {
            X = Graphics.GetWidth() + 200;
            Y = Math.Random(Graphics.GetHeight());
            Angle = (float)Math.Random() * System.MathF.PI * 2;

            _image = Graphics.NewImage("assets/hearth.png");
        }

        public void Update(float dt)
        {
            X -= Speed * dt;

            if (X < -200)
            {
                if (_image is not null)
                {
                    _image.Release();

                    Game1.hearths.Remove(this);
                }
            }
        }

        public void Draw()
        {
            if (_image is not null)
            {
                Graphics.Draw(_image, (int)X, (int)Y, Angle, 0.5f);
            }
        }
    }
}