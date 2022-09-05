using Raylib_cs;
using System.Collections.Generic;
using System.IO;

namespace Turtle
{
    /// <summary>
    /// Provides of audio interface for playback/recording sound.
    /// </summary>
    public static class Audio
    {
        private static List<Source> _loadedEffects = new();

        private static float _volume = 1.0f;

        internal static List<Source> GetLoadedEffects()
        {
            return _loadedEffects;
        }

        // Functions

        /// <summary>
        /// Gets the current number of simultaneously playing sources.
        /// </summary>
        /// <returns>The current number of simultaneously playing sources.</returns>
        public static int GetActiveSourceCount()
        {
            List<Source> activeEffects = new();

            foreach (Source source in _loadedEffects)
            {
                if (source.IsPlaying())
                {
                    activeEffects.Add(source);
                }
            }

            return activeEffects.Count;
        }

        /// <summary>
        /// Returns the master volume.
        /// </summary>
        /// <returns>The current master volume.</returns>
        public static float GetVolume()
        {
            return _volume;
        }

        /// <summary>
        /// Creates a new Source from a file.
        /// </summary>
        /// <param name="filename">The filepath to the audio file.</param>
        /// <param name="type">Streaming or static source.</param>
        /// <returns>A new Source that can play the specified audio.</returns>
        public static Source? NewSource(string filename, SourceType type)
        {
            if (File.Exists(filename))
            {
                switch (type)
                {
                    case SourceType.Static:
                        Source newStatic = new(Raylib.LoadSound(filename));
                        _loadedEffects.Add(newStatic);
                        return newStatic;
                    case SourceType.Stream:
                        Source newStream = new(Raylib.LoadSound(filename));
                        _loadedEffects.Add(newStream);
                        return newStream;
                }
            }
            else
            {
                Game.Error("Sound file does not exist.");
            }

            return null;
        }

        /// <summary>
        /// Pauses all currently active Sources and returns them.
        /// </summary>
        /// <returns>An array containing a list of Sources that were paused by this call.</returns>
        public static Source[] Pause()
        {
            List<Source> activeEffects = new();

            foreach (Source source in _loadedEffects)
            {
                if (source.IsPlaying())
                {
                    activeEffects.Add(source);
                    source.Pause();
                }
            }

            return activeEffects.ToArray();
        }

        /// <summary>
        /// Pauses the given Sources.
        /// </summary>
        /// <param name="sources">List of Sources to pause.</param>
        public static void Pause(params Source[] sources)
        {
            foreach (Source source in sources)
            {
                source.Pause();
            }
        }

        /// <summary>
        /// Starts playing one or multiple Sources simultaneously.
        /// </summary>
        /// <param name="sources">List of Sources to play.</param>
        public static void Play(params Source[] sources)
        {
            foreach (Source source in sources)
            {
                source.Play();
            }
        }

        /// <summary>
        /// Sets the master volume.
        /// </summary>
        /// <param name="volume">1.0 is max and 0.0 is off.</param>
        public static void SetVolume(float volume)
        {
            Raylib.SetMasterVolume(volume);
            _volume = volume;
        }

        /// <summary>
        /// This function will stop all currently active sources.
        /// </summary>
        public static void Stop()
        {
            foreach (Source source in _loadedEffects)
            {
                if (source.IsPlaying())
                {
                    source.Stop();
                }
            }
        }

        /// <summary>
        /// Stops one or multiple Sources simultaneously.
        /// </summary>
        /// <param name="sources">List of Sources to stop.</param>
        public static void Stop(params Source[] sources)
        {
            foreach (Source source in sources)
            {
                source.Stop();
            }
        }
    }
}