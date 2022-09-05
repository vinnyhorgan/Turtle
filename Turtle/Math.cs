using System;

namespace Turtle
{
    public static class Math
    {
        private static FastNoiseLite _noise = new();

        // Functions

        /// <summary>
        /// Generates noise from 2 dimensions. 
        /// </summary>
        /// <param name="x">The first value of the 2-dimensional vector used to generate the noise value.</param>
        /// <param name="y">The second value of the 2-dimensional vector used to generate the noise value.</param>
        /// <param name="type">The noise algorithm to use.</param>
        /// <returns>The noise value in the range of [0, 1].</returns>
        public static float Noise(float x, float y, NoiseType type = NoiseType.Simplex)
        {
            switch (type)
            {
                case NoiseType.Perlin:
                    _noise.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
                    break;
                case NoiseType.Simplex:
                    _noise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
                    break;
                case NoiseType.Value:
                    _noise.SetNoiseType(FastNoiseLite.NoiseType.Value);
                    break;
            }

            return _noise.GetNoise(x, y);
        }

        /// <summary>
        /// Generates noise from 3 dimensions.
        /// </summary>
        /// <param name="x">The first value of the 3-dimensional vector used to generate the noise value.</param>
        /// <param name="y">The second value of the 3-dimensional vector used to generate the noise value.</param>
        /// <param name="z">The third value of the 3-dimensional vector used to generate the noise value.</param>
        /// <param name="type">The noise algorithm to use.</param>
        /// <returns>The noise value in the range of [0, 1].</returns>
        public static float Noise(float x, float y, float z, NoiseType type = NoiseType.Simplex)
        {
            switch (type)
            {
                case NoiseType.Perlin:
                    _noise.SetNoiseType(FastNoiseLite.NoiseType.Perlin);
                    break;
                case NoiseType.Simplex:
                    _noise.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
                    break;
                case NoiseType.Value:
                    _noise.SetNoiseType(FastNoiseLite.NoiseType.Value);
                    break;
            }

            return _noise.GetNoise(x, y, z);
        }

        /// <summary>
        /// Get uniformly distributed pseudo-random real number within [0, 1].
        /// </summary>
        /// <returns>The pseudo-random number.</returns>
        public static double Random()
        {
            Random random = new();

            return random.NextDouble();
        }

        /// <summary>
        /// Get a uniformly distributed pseudo-random integer within [0, max].
        /// </summary>
        /// <param name="max">The maximum possible value it should return.</param>
        /// <returns>The pseudo-random integer number.</returns>
        public static int Random(int max)
        {
            Random random = new();

            return random.Next(max);
        }

        /// <summary>
        /// Get uniformly distributed pseudo-random integer within [min, max].
        /// </summary>
        /// <param name="min">The minimum possible value it should return.</param>
        /// <param name="max">The maximum possible value it should return.</param>
        /// <returns>The pseudo-random integer number.</returns>
        public static int Random(int min, int max)
        {
            Random random = new();

            return random.Next(min, max);
        }

    }
}