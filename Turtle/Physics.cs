using tainicom.Aether.Physics2D.Common;

namespace Turtle
{
    /// <summary>
    /// Can simulate 2D rigid bodies in a realistic manner.
    /// </summary>
    public static class Physics
    {
        private static float PPM = 64.0f;

        // Functions

        public static World NewWorld(float xg, float yg)
        {
            return new World(new tainicom.Aether.Physics2D.Dynamics.World(new Vector2(xg, yg)));
        }

        public static float GetMeter()
        {
            return PPM;
        }
    }
}