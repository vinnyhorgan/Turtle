using tainicom.Aether.Physics2D.Dynamics;
using tainicom.Aether.Physics2D.Common;

using Raylib_cs;

using System;
using System.Collections.Generic;

namespace Turtle
{
    public class World
    {
        private tainicom.Aether.Physics2D.Dynamics.World _aeWorld;
        private List<Collider> _colliders = new();

        internal List<Collider> GetColliders()
        {
            return _colliders;
        }

        internal World(tainicom.Aether.Physics2D.Dynamics.World aeWorld)
        {
            _aeWorld = aeWorld;
        }

        public void Update(float dt)
        {
            _aeWorld.Step(dt);
        }

        public void Draw()
        {
            foreach (Collider collider in _colliders)
            {
                Vector2 position = collider.GetBody().Position;
                float rotation = collider.GetBody().Rotation;

                switch (collider.GetColliderType())
                {
                    case ColliderType.Circle:
                        Graphics.Circle(DrawMode.Line, (int)(position.X * Physics.GetMeter()), (int)(position.Y * Physics.GetMeter()), collider.GetRadius());
                        break;
                    case ColliderType.Rectangle:
                        Raylib.DrawRectanglePro(
                            new Rectangle((int)(position.X * Physics.GetMeter()), (int)(position.Y * Physics.GetMeter()), (int)collider.GetSize().X, (int)collider.GetSize().Y),
                            new System.Numerics.Vector2(),

                            rotation * (180 / MathF.PI),
                            new Color(1, 1, 1).ToRayColor()
                        );
                        break;
                }
            }
        }

        public void Destroy()
        {

        }

        public void AddCollisionClass()
        {

        }

        public int GetBodyCount()
        {
            return _aeWorld.BodyList.Count;
        }

        public Collider NewCircleCollider(int x, int y, float radius)
        {
            Body newBody = _aeWorld.CreateBody(new Vector2(x / Physics.GetMeter(), y / Physics.GetMeter()));
            newBody.BodyType = tainicom.Aether.Physics2D.Dynamics.BodyType.Dynamic;

            Fixture newFixture = newBody.CreateCircle(radius / Physics.GetMeter(), 1.0f);
            newFixture.Restitution = 0.3f;
            newFixture.Friction = 0.5f;

            Collider newCollider = new(newBody, newFixture);
            newCollider.SetColliderType(ColliderType.Circle);
            newCollider.SetRadius(radius);

            _colliders.Add(newCollider);

            return newCollider;
        }

        public Collider NewRectangleCollider(int x, int y, int width, int height)
        {
            Body newBody = _aeWorld.CreateBody(new Vector2(x / Physics.GetMeter(), y / Physics.GetMeter()));
            newBody.BodyType = tainicom.Aether.Physics2D.Dynamics.BodyType.Dynamic;

            Fixture newFixture = newBody.CreateRectangle(width / Physics.GetMeter(), height / Physics.GetMeter(), 1.0f, new Vector2(width / Physics.GetMeter() / 2, height / Physics.GetMeter() / 2));
            newFixture.Restitution = 0.3f;
            newFixture.Friction = 0.5f;

            Collider newCollider = new(newBody, newFixture);
            newCollider.SetColliderType(ColliderType.Rectangle);
            newCollider.SetSize(new Vector2(width, height));

            _colliders.Add(newCollider);

            return newCollider;
        }
    }
}