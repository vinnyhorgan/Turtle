using tainicom.Aether.Physics2D.Dynamics;
using tainicom.Aether.Physics2D.Common;

namespace Turtle
{
    public class Collider
    {
        private Body _aeBody;
        private Fixture _aeFixture;
        private ColliderType _colliderType;
        private BodyType _bodyType;
        private float _radius;
        private Vector2 _size;

        internal Body GetBody()
        {
            return _aeBody;
        }

        internal Fixture GetFixture()
        {
            return _aeFixture;
        }

        internal ColliderType GetColliderType()
        {
            return _colliderType;
        }

        internal void SetColliderType(ColliderType type)
        {
            _colliderType = type;
        }

        internal float GetRadius()
        {
            return _radius;
        }

        internal void SetRadius(float radius)
        {
            _radius = radius;
        }

        internal Vector2 GetSize()
        {
            return _size;
        }

        internal void SetSize(Vector2 size)
        {
            _size = size;
        }

        internal Collider(Body aeBody, Fixture aeFixture)
        {
            _aeBody = aeBody;
            _aeFixture = aeFixture;
        }

        public void SetType(BodyType type)
        {
            switch (type)
            {
                case BodyType.Dynamic:
                    _aeBody.BodyType = tainicom.Aether.Physics2D.Dynamics.BodyType.Dynamic;
                    _bodyType = type;
                    break;
                case BodyType.Static:
                    _aeBody.BodyType = tainicom.Aether.Physics2D.Dynamics.BodyType.Static;
                    _bodyType = type;
                    break;
            }
        }
    }
}