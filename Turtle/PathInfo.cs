using System;

namespace Turtle
{
    /// <summary>
    /// A struct containing information about a path.
    /// </summary>
    public struct PathInfo
    {
        public bool Exists;
        public DateTime ModTime;
        public long Size;
        public FileType Type;
    }
}