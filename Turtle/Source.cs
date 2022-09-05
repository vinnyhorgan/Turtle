using Raylib_cs;

namespace Turtle
{
    /// <summary>
    /// A Source represents audio you can play back.
    /// </summary>
    public class Source
    {
        private Sound _raySound;
        private Music _rayMusic;
        private SourceType _type;

        private bool _paused = false;
        private float _pitch = 1.0f;
        private float _volume = 1.0f;

        internal Source(Sound raySound)
        {
            _raySound = raySound;
        }

        internal Source(Music rayMusic)
        {
            _rayMusic = rayMusic;
        }

        internal Sound GetRaySound()
        {
            return _raySound;
        }

        internal Music GetRayMusic()
        {
            return _rayMusic;
        }

        // Functions

        /// <summary>
        /// Immediately destroys the object's reference.
        /// </summary>
        public void Release()
        {
            Audio.GetLoadedEffects().Remove(this);

            switch (_type)
            {
                case SourceType.Static:
                    Raylib.UnloadSound(_raySound);
                    break;
                case SourceType.Stream:
                    Raylib.UnloadMusicStream(_rayMusic);
                    break;
            }
        }

        /// <summary>
        /// Get the number of sounds playing in the multichannel.
        /// </summary>
        /// <returns>The number of sounds playing in the multichannel.</returns>
        public int GetChannelCount()
        {
            if (_type == SourceType.Static)
            {
                return Raylib.GetSoundsPlaying();
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets the duration of the Source.
        /// </summary>
        /// <returns>The duration of the Source, or -1 if it cannot be determined.</returns>
        public float GetDuration()
        {
            if (_type == SourceType.Stream)
            {
                return Raylib.GetMusicTimeLength(_rayMusic);
            }
            else
            {
                return -1.0f;
            }
        }

        /// <summary>
        /// Gets the current pitch of the Source.
        /// </summary>
        /// <returns>The pitch, where 1.0 is normal.</returns>
        public float GetPitch()
        {
            return _pitch;
        }

        /// <summary>
        /// Gets the type of the Source.
        /// </summary>
        /// <returns>The type of the source.</returns>
        public new SourceType GetType()
        {
            return _type;
        }

        /// <summary>
        /// Gets the current volume of the Source.
        /// </summary>
        /// <returns>The volume of the Source, where 1.0 is normal volume.</returns>
        public float GetVolume()
        {
            return _volume;
        }

        /// <summary>
        /// Returns whether the Source will loop.
        /// </summary>
        /// <returns>True if the Source will loop, false otherwise.</returns>
        public bool IsLooping()
        {
            if (_type == SourceType.Stream)
            {
                return _rayMusic.looping;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns whether the Source is playing.
        /// </summary>
        /// <returns>True if the Source is playing, false otherwise.</returns>
        public bool IsPlaying()
        {
            switch (_type)
            {
                case SourceType.Static:
                    return Raylib.IsSoundPlaying(_raySound);
                case SourceType.Stream:
                    return Raylib.IsMusicStreamPlaying(_rayMusic);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Pauses a source.
        /// </summary>
        public void Pause()
        {
            switch (_type)
            {
                case SourceType.Static:
                    Raylib.PauseSound(_raySound);
                    _paused = true;
                    break;
                case SourceType.Stream:
                    Raylib.PauseMusicStream(_rayMusic);
                    _paused = true;
                    break;
            }
        }

        /// <summary>
        /// Plays a source.
        /// </summary>
        public void Play()
        {
            if (_paused)
            {
                switch (_type)
                {
                    case SourceType.Static:
                        Raylib.ResumeSound(_raySound);
                        _paused = false;
                        break;
                    case SourceType.Stream:
                        Raylib.ResumeMusicStream(_rayMusic);
                        _paused = false;
                        break;
                }
            }
            else
            {
                switch (_type)
                {
                    case SourceType.Static:
                        Raylib.PlaySound(_raySound);
                        break;
                    case SourceType.Stream:
                        Raylib.PlayMusicStream(_rayMusic);
                        break;
                }
            }
        }

        /// <summary>
        /// Plays sound in the multi channel.
        /// </summary>
        public void Queue()
        {
            if (_type == SourceType.Static)
            {
                Raylib.PlaySoundMulti(_raySound);
            }
        }

        /// <summary>
        /// Sets the currently playing position of the Source.
        /// </summary>
        /// <param name="second">The position to seek to.</param>
        public void Seek(float second)
        {
            if (_type == SourceType.Stream)
            {
                Raylib.SeekMusicStream(_rayMusic, second);
            }
        }

        /// <summary>
        /// Sets whether the Source should loop.
        /// </summary>
        /// <param name="looping">True if the source should loop, false otherwise.</param>
        public void SetLooping(bool loop)
        {
            if (_type == SourceType.Stream)
            {
                _rayMusic.looping = loop;
            }
        }

        /// <summary>
        /// Sets the pitch of the Source.
        /// </summary>
        /// <param name="pitch">Calculated with regard to 1 being the base pitch.</param>
        public void SetPitch(float pitch)
        {
            switch (_type)
            {
                case SourceType.Static:
                    Raylib.SetSoundPitch(_raySound, pitch);
                    _pitch = pitch;
                    break;
                case SourceType.Stream:
                    Raylib.SetMusicPitch(_rayMusic, pitch);
                    _pitch = pitch;
                    break;
            }
        }

        /// <summary>
        /// Sets the current volume of the Source.
        /// </summary>
        /// <param name="volume">The volume for a Source, where 1.0 is normal volume.</param>
        public void SetVolume(float volume)
        {
            switch (_type)
            {
                case SourceType.Static:
                    Raylib.SetSoundVolume(_raySound, volume);
                    _volume = volume;
                    break;
                case SourceType.Stream:
                    Raylib.SetMusicVolume(_rayMusic, volume);
                    _volume = volume;
                    break;
            }
        }

        /// <summary>
        /// Stops a Source.
        /// </summary>
        public void Stop()
        {
            switch (_type)
            {
                case SourceType.Static:
                    Raylib.StopSound(_raySound);
                    Raylib.StopSoundMulti();
                    break;
                case SourceType.Stream:
                    Raylib.StopMusicStream(_rayMusic);
                    break;
            }
        }

        /// <summary>
        /// Gets the currently playing position of the Source.
        /// </summary>
        /// <returns>The currently playing position of the Source.</returns>
        public float Tell()
        {
            if (_type == SourceType.Stream)
            {
                return Raylib.GetMusicTimePlayed(_rayMusic);
            }
            else
            {
                return -1.0f;
            }
        }
    }
}